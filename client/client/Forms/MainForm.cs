using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteDesktop.Forms;
using RemoteDesktop.Services;

namespace RemoteDesktop.Forms
{
    public partial class MainForm : Form
    {
        // ── Fields ────────────────────────────────────────────────────────
        private ConnectionService _connectionService = new();
        private bool _isConnected;
        private bool _isConnecting;

        private int _lastImageWidth;
        private int _lastImageHeight;

        // Cho phép hủy kết nối đang treo (timeout hoặc người dùng bấm Hủy)
        private CancellationTokenSource? _connectCancelSource;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectFromServer();
        }

        // ── Nút Kết nối ──────────────────────────────────────────────────
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            using var connectionForm = new ConnectionForm();
            if (connectionForm.ShowDialog() != DialogResult.OK) return;

            ConnectAsync(
                connectionForm.ServerIp,
                connectionForm.ServerPort,
                connectionForm.PasswordHash
            );
        }

        // ── Nút Ngắt kết nối — GIỜ CŨNG DÙNG ĐỂ HỦY KẾT NỐI ĐANG TREO ────
        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            if (_isConnecting)
            {
                // Đang trong lúc Connect/Auth bị treo (VD sai IP, timeout)
                // → hủy ngay, không cần chờ hết timeout hay tắt app
                _connectCancelSource?.Cancel();
                return;
            }

            DisconnectFromServer();
        }

        // ── Nút "Gửi file" ───────────────────────────────────────────────
        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                MessageBox.Show("Vui lòng kết nối tới Server trước khi gửi file.",
                    "Chưa kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var fileTransferForm = new FileTransferForm(_connectionService);
            fileTransferForm.ShowDialog(this);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            using var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        // ── Nút "Chụp màn hình" ──────────────────────────────────────────
        private async void BtnScreenshot_Click(object sender, EventArgs e)
        {
            if (!_isConnected) return;

            btnScreenshot.Enabled = false;
            btnScreenshot.Text = "Đang chụp...";

            try
            {
                await _connectionService.SendPacketAsync(Protocol.REQUEST_FRAME, []);
                var (_, jpegBytes) = await _connectionService.ReceivePacketAsync();

                if (jpegBytes.Length == 0)
                {
                    MessageBox.Show("Không nhận được ảnh từ Server.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Image screenImage = DecodeJpegFrame(jpegBytes);
                UpdateScreenDisplay(screenImage);

                string savedPath = SaveScreenshotToDisk(jpegBytes);

                MessageBox.Show(
                    $"Đã chụp màn hình thành công!\n\nLưu tại:\n{savedPath}\n\n" +
                    "Bây giờ bạn có thể di chuột / gõ phím ngay trên ảnh này để điều khiển Server.",
                    "Chụp màn hình",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chụp màn hình: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnScreenshot.Enabled = true;
                btnScreenshot.Text = "📷 Chụp màn hình";
            }
        }

        private static string SaveScreenshotToDisk(byte[] jpegBytes)
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                "RemoteDesktopCaptures");

            Directory.CreateDirectory(folder);

            string fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
            string fullPath = Path.Combine(folder, fileName);

            File.WriteAllBytes(fullPath, jpegBytes);

            return fullPath;
        }

        // ══════════════════════════════════════════════════════════════════
        // KẾT NỐI — đã thêm: timeout 8 giây + khả năng hủy giữa chừng
        // ══════════════════════════════════════════════════════════════════
        private async void ConnectAsync(string serverIp, int serverPort, string passwordHash)
        {
            _isConnecting = true;
            _connectCancelSource = new CancellationTokenSource();

            SetConnectionStatus(isConnecting: true);

            try
            {
                // Timeout 8 giây — nếu IP sai/không phản hồi, tự động hủy
                // thay vì treo vô thời hạn
                using var timeoutSource = new CancellationTokenSource(TimeSpan.FromSeconds(8));
                using var linkedSource = CancellationTokenSource.CreateLinkedTokenSource(
                    _connectCancelSource.Token, timeoutSource.Token);

                await ConnectWithCancellationAsync(serverIp, serverPort, linkedSource.Token);

                bool isAuthenticated = await AuthenticateAsync(passwordHash);
                if (!isAuthenticated)
                {
                    MessageBox.Show("Sai mật khẩu. Kết nối bị từ chối.",
                        "Xác thực thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await _connectionService.DisconnectAsync();
                    ResetToDisconnectedState();
                    return;
                }

                _isConnected = true;
                _isConnecting = false;
                SetConnectionStatus(isConnecting: false, isConnected: true);

                MessageBox.Show(
                    "Kết nối thành công!\n\n" +
                    "Bước tiếp theo:\n" +
                    "1. Bấm \"Chụp màn hình\" để xem màn hình Server\n" +
                    "2. Di chuột / gõ phím ngay trên ảnh đó để điều khiển\n" +
                    "3. Bấm \"Gửi file\" để truyền file sang Server",
                    "Đã kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                // Người dùng bấm "Hủy" hoặc hết 8 giây timeout — không phải lỗi nghiêm trọng
                MessageBox.Show(
                    "Không thể kết nối tới Server.\n\n" +
                    "Kiểm tra lại:\n" +
                    "• Địa chỉ IP có đúng không\n" +
                    "• Server đã bật chưa\n" +
                    "• 2 máy có cùng mạng LAN không",
                    "Kết nối thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetToDisconnectedState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetToDisconnectedState();
            }
            finally
            {
                _connectCancelSource?.Dispose();
                _connectCancelSource = null;
            }
        }

        // ── Kết nối có hỗ trợ hủy — bọc ConnectAsync gốc ──────────────────
        private async Task ConnectWithCancellationAsync(
            string serverIp, int serverPort, CancellationToken cancelToken)
        {
            var connectTask = _connectionService.ConnectAsync(serverIp, serverPort);

            // Race giữa việc kết nối xong và việc bị hủy/timeout
            var cancelTask = Task.Delay(Timeout.Infinite, cancelToken);

            var completedTask = await Task.WhenAny(connectTask, cancelTask);

            if (completedTask == cancelTask)
            {
                // Bị hủy — dọn dẹp socket đang treo dở
                try { await _connectionService.DisconnectAsync(); } catch { }
                cancelToken.ThrowIfCancellationRequested();
            }

            await connectTask; // ném lại exception thật nếu connectTask lỗi
        }

        // ── Reset UI về trạng thái sẵn sàng kết nối lại ──────────────────
        private void ResetToDisconnectedState()
        {
            _isConnected = false;
            _isConnecting = false;
            SetConnectionStatus(isConnected: false);
        }

        // ── Xác thực ─────────────────────────────────────────────────────
        private async Task<bool> AuthenticateAsync(string passwordHash)
        {
            byte[] hashBytes = Encoding.UTF8.GetBytes(passwordHash);
            await _connectionService.SendPacketAsync(Protocol.AUTH_REQUEST, hashBytes);
            var (_, payload) = await _connectionService.ReceivePacketAsync();
            return payload.Length > 0 && payload[0] == Protocol.AUTH_SUCCESS;
        }

        // ── Ngắt kết nối ─────────────────────────────────────────────────
        private async void DisconnectFromServer()
        {
            _isConnected = false;
            _isConnecting = false;

            await _connectionService.DisconnectAsync();

            SetConnectionStatus(isConnected: false);
            UpdateScreenDisplay(null);
            _lastImageWidth = 0;
            _lastImageHeight = 0;
        }

        private static Image DecodeJpegFrame(byte[] jpegBytes)
        {
            using var ms = new MemoryStream(jpegBytes);
            using var temp = Image.FromStream(ms);
            return new Bitmap(temp);
        }

        private void UpdateScreenDisplay(Image? screenImage)
        {
            if (pictureBoxScreen.InvokeRequired)
            {
                pictureBoxScreen.Invoke(() => UpdateScreenDisplay(screenImage));
                return;
            }

            pictureBoxScreen.Image?.Dispose();
            pictureBoxScreen.Image = screenImage;

            if (screenImage != null)
            {
                _lastImageWidth = screenImage.Width;
                _lastImageHeight = screenImage.Height;
            }
        }

        // ── Chuột ────────────────────────────────────────────────────────
        private void PictureBoxScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isConnected || pictureBoxScreen.Image == null) return;
            SendMousePacket(e.X, e.Y, "MOVE", 0);
        }

        private void PictureBoxScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_isConnected || pictureBoxScreen.Image == null) return;
            string button = e.Button == MouseButtons.Left ? "LEFT" :
                            e.Button == MouseButtons.Right ? "RIGHT" : "MIDDLE";
            SendMousePacket(e.X, e.Y, $"DOWN_{button}", 0);
        }

        private void PictureBoxScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isConnected || pictureBoxScreen.Image == null) return;
            string button = e.Button == MouseButtons.Left ? "LEFT" :
                            e.Button == MouseButtons.Right ? "RIGHT" : "MIDDLE";
            SendMousePacket(e.X, e.Y, $"UP_{button}", 0);
        }

        private void PictureBoxScreen_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_isConnected || pictureBoxScreen.Image == null) return;
            SendMousePacket(e.X, e.Y, "WHEEL", e.Delta);
        }

        private async void SendMousePacket(int mouseX, int mouseY, string eventType, int delta)
        {
            try
            {
                int scaledX = ScaleCoordinateX(mouseX);
                int scaledY = ScaleCoordinateY(mouseY);

                byte[] eventBytes = Encoding.ASCII.GetBytes(eventType.PadRight(10));
                byte[] payload = [
                    .. eventBytes,
                    .. BitConverter.GetBytes(scaledX),
                    .. BitConverter.GetBytes(scaledY),
                    .. BitConverter.GetBytes(delta)
                ];

                await _connectionService.SendPacketAsync(Protocol.INPUT_MOUSE, payload);
            }
            catch { }
        }

        // ── Bàn phím ─────────────────────────────────────────────────────
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_isConnected) return;
            SendKeyPacket((int)e.KeyCode, isKeyDown: true);
            e.Handled = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!_isConnected) return;
            SendKeyPacket((int)e.KeyCode, isKeyDown: false);
        }

        private async void SendKeyPacket(int keyCode, bool isKeyDown)
        {
            try
            {
                byte[] payload = [
                    .. BitConverter.GetBytes(keyCode),
                    (byte)(isKeyDown ? 1 : 0)
                ];

                await _connectionService.SendPacketAsync(Protocol.INPUT_KEY, payload);
            }
            catch { }
        }

        // ── Helpers ───────────────────────────────────────────────────────
        private int ScaleCoordinateX(int pictureBoxX)
        {
            if (_lastImageWidth == 0 || pictureBoxScreen.Width == 0) return pictureBoxX;

            var (drawX, drawWidth) = GetZoomDrawRect(
                pictureBoxScreen.Width, pictureBoxScreen.Height,
                _lastImageWidth, _lastImageHeight, isHorizontal: true);

            int relativeX = pictureBoxX - drawX;
            if (relativeX < 0 || relativeX > drawWidth) return -1;

            return (int)((double)relativeX / drawWidth * _lastImageWidth);
        }

        private int ScaleCoordinateY(int pictureBoxY)
        {
            if (_lastImageHeight == 0 || pictureBoxScreen.Height == 0) return pictureBoxY;

            var (drawY, drawHeight) = GetZoomDrawRect(
                pictureBoxScreen.Width, pictureBoxScreen.Height,
                _lastImageWidth, _lastImageHeight, isHorizontal: false);

            int relativeY = pictureBoxY - drawY;
            if (relativeY < 0 || relativeY > drawHeight) return -1;

            return (int)((double)relativeY / drawHeight * _lastImageHeight);
        }

        private static (int offset, int size) GetZoomDrawRect(
            int boxWidth, int boxHeight, int imgWidth, int imgHeight, bool isHorizontal)
        {
            double boxRatio = (double)boxWidth / boxHeight;
            double imgRatio = (double)imgWidth / imgHeight;

            if (imgRatio > boxRatio)
            {
                int drawHeight = (int)(boxWidth / imgRatio);
                int offsetY = (boxHeight - drawHeight) / 2;
                return isHorizontal ? (0, boxWidth) : (offsetY, drawHeight);
            }
            else
            {
                int drawWidth = (int)(boxHeight * imgRatio);
                int offsetX = (boxWidth - drawWidth) / 2;
                return isHorizontal ? (offsetX, drawWidth) : (0, boxHeight);
            }
        }

        // ── Cập nhật trạng thái UI ───────────────────────────────────────
        // Khi đang Connecting: nút Disconnect ĐƯỢC BẬT để dùng làm nút Hủy
        private void SetConnectionStatus(bool isConnecting = false, bool isConnected = false)
        {
            if (InvokeRequired) { Invoke(() => SetConnectionStatus(isConnecting, isConnected)); return; }

            if (isConnecting)
            {
                lblStatusConnection.Text = "Đang kết nối...";
                lblStatusConnection.ForeColor = System.Drawing.Color.Yellow;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;     // BẬT — dùng để Hủy kết nối đang treo
                btnDisconnect.Text = "Hủy";
                btnSendFile.Enabled = false;
                btnScreenshot.Enabled = false;
            }
            else if (isConnected)
            {
                lblStatusConnection.Text = "Đã kết nối";
                lblStatusConnection.ForeColor = System.Drawing.Color.LimeGreen;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnDisconnect.Text = "Ngắt kết nối";
                btnSendFile.Enabled = true;
                btnScreenshot.Enabled = true;
            }
            else
            {
                lblStatusConnection.Text = "Chưa kết nối";
                lblStatusConnection.ForeColor = System.Drawing.Color.Gray;
                lblStatusPing.Text = "Ping: --";
                lblStatusFps.Text = "FPS: --";
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                btnDisconnect.Text = "Ngắt kết nối";
                btnSendFile.Enabled = false;
                btnScreenshot.Enabled = false;
            }
        }
    }
}