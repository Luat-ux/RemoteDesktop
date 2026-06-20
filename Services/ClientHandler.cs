using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace RemoteDesktop.Services
{
    /// <summary>
    /// Xử lý 1 Client kết nối — chạy trên Task riêng.
    /// Gồm: xác thực SHA-256, chụp màn hình theo yêu cầu, thực thi input chuột/phím.
    ///
    /// LƯU Ý QUAN TRỌNG: Server CHỈ chụp màn hình khi nhận đúng 1 gói
    /// REQUEST_FRAME từ Client (khi người dùng bấm nút "Chụp màn hình").
    /// Không có vòng lặp tự động nào chụp liên tục — tránh treo máy
    /// và giống đúng cách hoạt động của remote-shutdown demo gốc.
    /// </summary>
    public class ClientHandler
    {
        // ── P/Invoke — user32.dll ─────────────────────────────────────────
        [DllImport("user32.dll")] static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")] static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [DllImport("user32.dll")] static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        [DllImport("user32.dll")] static extern int GetSystemMetrics(int nIndex);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;

        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        private const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const uint MOUSEEVENTF_WHEEL = 0x0800;

        private const uint KEYEVENTF_KEYDOWN = 0x0000;
        private const uint KEYEVENTF_KEYUP = 0x0002;

        // Giới hạn kích thước ảnh khi gửi — vẫn cần để không bị nặng dù chỉ chụp 1 lần
        private const int MAX_FRAME_WIDTH = 1280;

        private readonly Socket _clientSocket;
        private readonly ServerConfig _config;
        private readonly string _clientAddress;
        public event Action<string>? OnDisconnected;

        public ClientHandler(Socket clientSocket, ServerConfig config)
        {
            _clientSocket = clientSocket;
            _config = config;
            _clientAddress = clientSocket.RemoteEndPoint?.ToString() ?? "unknown";
        }

        public async Task HandleAsync()
        {
            Logger.Info($"Client kết nối: {_clientAddress}");

            try
            {
                bool isAuthenticated = await AuthenticateClientAsync();
                if (!isAuthenticated)
                {
                    Logger.Warning($"Client {_clientAddress} sai mật khẩu — từ chối.");
                    return;
                }

                Logger.Info($"Client {_clientAddress} xác thực thành công.");
                await ProcessClientCommandsAsync();
            }
            catch (IOException ex)
            {
                Logger.Warning($"Client {_clientAddress} mất kết nối: {ex.Message}");
            }
            catch (SocketException ex)
            {
                Logger.Warning($"Client {_clientAddress} lỗi socket: {ex.Message}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Lỗi xử lý client {_clientAddress}.", ex);
            }
            finally
            {
                _clientSocket.Close();
                OnDisconnected?.Invoke(_clientAddress);
                Logger.Info($"Client {_clientAddress} ngắt kết nối.");
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // CHỨC NĂNG DEMO SỐ 2 — Xác thực mật khẩu SHA-256
        // ══════════════════════════════════════════════════════════════════
        private async Task<bool> AuthenticateClientAsync()
        {
            try
            {
                byte[] header = await Task.Run(() => ReceiveExactBytes(Protocol.HEADER_SIZE));
                (int packetType, int payloadLength) = Protocol.ParseHeader(header);

                if (packetType != Protocol.AUTH_REQUEST)
                {
                    Logger.Warning("Gói đầu tiên không phải AUTH_REQUEST.");
                    return false;
                }

                byte[] hashBytes = await Task.Run(() => ReceiveExactBytes(payloadLength));
                string receivedHash = Encoding.UTF8.GetString(hashBytes).Trim().ToUpper();

                Logger.Info($"Nhận hash từ client: {receivedHash[..8]}...");

                bool isMatch = string.Equals(
                    receivedHash,
                    _config.PasswordHash.ToUpper(),
                    StringComparison.OrdinalIgnoreCase);

                byte[] responsePayload = [isMatch ? Protocol.AUTH_SUCCESS : Protocol.AUTH_FAILED];
                await SendPacketAsync(Protocol.AUTH_RESPONSE, responsePayload);

                return isMatch;
            }
            catch (Exception ex)
            {
                Logger.Error("Lỗi xác thực.", ex);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // Vòng lặp nhận lệnh từ Client — đứng chờ, KHÔNG tự chụp gì cả
        // cho tới khi nhận đúng gói REQUEST_FRAME (người dùng bấm nút)
        // ══════════════════════════════════════════════════════════════════
        private async Task ProcessClientCommandsAsync()
        {
            while (true)
            {
                byte[] header = await Task.Run(() => ReceiveExactBytes(Protocol.HEADER_SIZE));
                (int packetType, int payloadLength) = Protocol.ParseHeader(header);

                byte[] payload = payloadLength > 0
                    ? await Task.Run(() => ReceiveExactBytes(payloadLength))
                    : [];

                switch (packetType)
                {
                    case Protocol.REQUEST_FRAME:
                        // CHỈ chụp đúng 1 lần tại đây — không lặp, không timer
                        Logger.Info($"Client {_clientAddress} yêu cầu chụp màn hình.");
                        await SendScreenFrameAsync();
                        break;

                    case Protocol.INPUT_MOUSE:
                        await Task.Run(() => ExecuteMouseInput(payload));
                        break;

                    case Protocol.INPUT_KEY:
                        await Task.Run(() => ExecuteKeyboardInput(payload));
                        break;

                    case Protocol.FILE_HEADER:
                        await ReceiveFileAsync(payload);
                        break;

                    case Protocol.DISCONNECT:
                        Logger.Info($"Client {_clientAddress} ngắt kết nối chủ động.");
                        return;

                    default:
                        Logger.Warning($"Packet không xác định: type={packetType}");
                        break;
                }
            }
        }

        // ── Chụp 1 lần, gửi về Client — không lặp lại tự động ─────────────
        private async Task SendScreenFrameAsync()
        {
            try
            {
                byte[] jpegBytes = await Task.Run(CaptureScreenAsJpeg);
                await SendPacketAsync(Protocol.FRAME_DATA, jpegBytes);
                Logger.Info($"Đã gửi ảnh chụp màn hình tới {_clientAddress} ({jpegBytes.Length / 1024} KB)");
            }
            catch (Exception ex)
            {
                Logger.Error("Lỗi chụp/gửi màn hình.", ex);
                await SendPacketAsync(Protocol.FRAME_DATA, []);
            }
        }

        // ── Chụp màn hình → resize → nén JPEG → byte[] ────────────────────
        private byte[] CaptureScreenAsJpeg()
        {
            int realWidth = GetSystemMetrics(SM_CXSCREEN);
            int realHeight = GetSystemMetrics(SM_CYSCREEN);

            using Bitmap fullBitmap = new(realWidth, realHeight, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(fullBitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(realWidth, realHeight), CopyPixelOperation.SourceCopy);
            }

            // Resize nếu màn hình quá lớn — vẫn giữ chất lượng tốt vì chỉ chụp 1 lần
            int targetWidth = Math.Min(MAX_FRAME_WIDTH, realWidth);
            int targetHeight = (int)((double)realHeight / realWidth * targetWidth);

            using Bitmap resizedBitmap = new(targetWidth, targetHeight, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(fullBitmap, 0, 0, targetWidth, targetHeight);
            }

            var jpegEncoder = GetJpegEncoder();
            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.Quality, (long)_config.JpegQuality);

            using var ms = new MemoryStream();
            resizedBitmap.Save(ms, jpegEncoder, encoderParams);
            return ms.ToArray();
        }

        private static ImageCodecInfo GetJpegEncoder()
        {
            return ImageCodecInfo.GetImageDecoders()
                .First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
        }

        // ══════════════════════════════════════════════════════════════════
        // CHỨC NĂNG DEMO SỐ 1 — Thực thi lệnh chuột (P/Invoke)
        // ══════════════════════════════════════════════════════════════════
        private void ExecuteMouseInput(byte[] payload)
        {
            if (payload.Length < 22) return;

            string eventType = Encoding.ASCII.GetString(payload, 0, 10).Trim();
            int x = BitConverter.ToInt32(payload, 10);
            int y = BitConverter.ToInt32(payload, 14);
            int delta = BitConverter.ToInt32(payload, 18);

            switch (eventType)
            {
                case "MOVE":
                    SetCursorPos(x, y);
                    break;
                case "DOWN_LEFT":
                    SetCursorPos(x, y);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                    break;
                case "UP_LEFT":
                    mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                    break;
                case "DOWN_RIGHT":
                    SetCursorPos(x, y);
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
                    break;
                case "UP_RIGHT":
                    mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
                    break;
                case "DOWN_MIDDLE":
                    SetCursorPos(x, y);
                    mouse_event(MOUSEEVENTF_MIDDLEDOWN, x, y, 0, 0);
                    break;
                case "UP_MIDDLE":
                    mouse_event(MOUSEEVENTF_MIDDLEUP, x, y, 0, 0);
                    break;
                case "WHEEL":
                    mouse_event(MOUSEEVENTF_WHEEL, 0, 0, delta, 0);
                    break;
            }
        }

        private void ExecuteKeyboardInput(byte[] payload)
        {
            if (payload.Length < 5) return;

            int keyCode = BitConverter.ToInt32(payload, 0);
            bool isKeyDown = payload[4] == 1;

            byte vk = (byte)(keyCode & 0xFF);
            uint flags = isKeyDown ? KEYEVENTF_KEYDOWN : KEYEVENTF_KEYUP;

            keybd_event(vk, 0, flags, 0);
        }

        private async Task ReceiveFileAsync(byte[] headerPayload)
        {
            string fileName = Encoding.UTF8.GetString(headerPayload, 0, 256).TrimEnd('\0', ' ');
            long fileSize = BitConverter.ToInt64(headerPayload, 256);

            string downloadsFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            Directory.CreateDirectory(downloadsFolder);
            string savePath = Path.Combine(downloadsFolder, fileName);

            Logger.Info($"Nhận file: {fileName} ({fileSize / 1024} KB) → {savePath}");

            long bytesReceived = 0;
            using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write);

            while (true)
            {
                byte[] chunkHeader = await Task.Run(() => ReceiveExactBytes(Protocol.HEADER_SIZE));
                (int chunkType, int chunkLength) = Protocol.ParseHeader(chunkHeader);

                if (chunkType == Protocol.FILE_END)
                {
                    Logger.Info($"Nhận file xong: {fileName} ({bytesReceived / 1024} KB)");
                    break;
                }

                if (chunkType == Protocol.FILE_CANCEL)
                {
                    Logger.Warning($"Client hủy gửi file: {fileName}");
                    fileStream.Close();
                    File.Delete(savePath);
                    return;
                }

                if (chunkType == Protocol.FILE_CHUNK)
                {
                    byte[] chunkData = await Task.Run(() => ReceiveExactBytes(chunkLength));
                    await fileStream.WriteAsync(chunkData);
                    bytesReceived += chunkLength;
                }
            }
        }

        private async Task SendPacketAsync(int packetType, byte[] payload)
        {
            byte[] header = Protocol.BuildHeader(packetType, payload.Length);
            byte[] packet = new byte[header.Length + payload.Length];
            header.CopyTo(packet, 0);
            payload.CopyTo(packet, header.Length);

            await Task.Run(() => _clientSocket.Send(packet));
        }

        private byte[] ReceiveExactBytes(int byteCount)
        {
            byte[] buffer = new byte[byteCount];
            int totalRead = 0;

            while (totalRead < byteCount)
            {
                int bytesRead = _clientSocket.Receive(
                    buffer, totalRead, byteCount - totalRead, SocketFlags.None);

                if (bytesRead == 0)
                    throw new IOException("Client đóng kết nối.");

                totalRead += bytesRead;
            }
            return buffer;
        }
    }
}