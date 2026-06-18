using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace RemoteDesktop.Services
{
    public class ConnectionService : IDisposable
    {
        private Socket? _socket;
        private bool _isDisposed;

        public bool IsConnected => _socket?.Connected ?? false;

        // ── Kết nối tới Server ───────────────────────────────────────────
        public async Task ConnectAsync(string serverIp, int serverPort)
        {
            await Task.Run(() =>
            {
                _socket = new Socket(AddressFamily.InterNetwork,
                                     SocketType.Stream,
                                     ProtocolType.Tcp);

                IPAddress ip = IPAddress.Parse(serverIp);
                IPEndPoint endpoint = new IPEndPoint(ip, serverPort);

                _socket.Connect(endpoint);   // socket() + connect() như thầy dạy
            });
        }

        // ── Gửi packet ───────────────────────────────────────────────────
        public async Task SendPacketAsync(int packetType, byte[] payload)
        {
            EnsureConnected();

            byte[] header = Protocol.BuildHeader(packetType, payload.Length);
            byte[] packet = new byte[header.Length + payload.Length];
            header.CopyTo(packet, 0);
            payload.CopyTo(packet, header.Length);

            await Task.Run(() =>
            {
                _socket!.Send(packet);       // send() như thầy dạy
            });
        }

        // ── Nhận packet ──────────────────────────────────────────────────
        public async Task<(int packetType, byte[] payload)> ReceivePacketAsync()
        {
            EnsureConnected();

            // Đọc header 8 bytes trước
            byte[] header = await Task.Run(() =>
            {
                return ReceiveExactBytes(Protocol.HEADER_SIZE);  // recv() như thầy dạy
            });

            var (packetType, payloadLength) = Protocol.ParseHeader(header);

            // Đọc payload theo đúng length trong header
            byte[] payload = payloadLength > 0
                ? await Task.Run(() => ReceiveExactBytes(payloadLength))
                : [];

            return (packetType, payload);
        }

        // ── Ngắt kết nối ─────────────────────────────────────────────────
        public async Task DisconnectAsync()
        {
            if (!IsConnected) return;
            try
            {
                await SendPacketAsync(Protocol.DISCONNECT, []);
            }
            catch { }
            finally
            {
                await Task.Run(() =>
                {
                    _socket?.Shutdown(SocketShutdown.Both);
                    _socket?.Close();        // close() như thầy dạy
                    _socket = null;
                });
            }
        }

        // ── Đọc đúng N bytes — TCP có thể chia nhỏ gói ──────────────────
        // Đây là hàm quan trọng nhất — giống receivefrom() trong slide thầy
        private byte[] ReceiveExactBytes(int byteCount)
        {
            byte[] buffer = new byte[byteCount];
            int totalRead = 0;

            while (totalRead < byteCount)
            {
                int bytesRead = _socket!.Receive(
                    buffer,
                    totalRead,
                    byteCount - totalRead,
                    SocketFlags.None);       // recv() như thầy dạy

                if (bytesRead == 0)
                    throw new IOException("Server đóng kết nối.");

                totalRead += bytesRead;
            }
            return buffer;
        }

        private void EnsureConnected()
        {
            if (_socket == null || !IsConnected)
                throw new InvalidOperationException("Chưa kết nối tới server.");
        }

        public void Dispose()
        {
            if (_isDisposed) return;
            _socket?.Close();
            _isDisposed = true;
        }
    }
}