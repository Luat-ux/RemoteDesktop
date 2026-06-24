using System.Net;
using System.Net.Sockets;

namespace RemoteDesktop.Services
{
    /// <summary>
    /// TCP Server — lắng nghe kết nối, mỗi client → Task riêng.
    /// </summary>
    public class TcpServer
    {
        private Socket?           _serverSocket;
        private bool              _isRunning;
        private readonly ServerConfig _config;

        public int  ConnectedClientCount { get; private set; }
        public event Action<string>? OnClientConnected;
        public event Action<string>? OnClientDisconnected;
        public event Action<string>? OnStatusChanged;

        public TcpServer(ServerConfig config)
        {
            _config = config;
        }

        // ── Bắt đầu lắng nghe ────────────────────────────────────────────
        public async Task StartAsync(int port)
        {
            // socket() — tạo socket TCP
            _serverSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            // bind() — gắn vào port
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));

            // listen() — bắt đầu lắng nghe, tối đa 10 client chờ
            _serverSocket.Listen(10);

            _isRunning = true;
            Logger.Info($"Server đang lắng nghe trên port {port}...");
            OnStatusChanged?.Invoke($"Đang chạy — Port {port}");

            await AcceptClientsAsync();
        }

        // ── Chấp nhận client liên tục ─────────────────────────────────────
        private async Task AcceptClientsAsync()
        {
            while (_isRunning)
            {
                try
                {
                    // accept() — chờ client kết nối
                    Socket clientSocket = await Task.Run(() => _serverSocket!.Accept());

                    string clientAddress = clientSocket.RemoteEndPoint?.ToString() ?? "unknown";
                    ConnectedClientCount++;
                    OnClientConnected?.Invoke(clientAddress);
                    Logger.Info($"Chấp nhận kết nối từ: {clientAddress}");

                    // Mỗi client chạy trên Task riêng — không block AcceptLoop
                    _ = Task.Run(async () =>
                    {
                        var handler = new ClientHandler(clientSocket, _config);
                        handler.OnDisconnected += addr =>
                        {
                            ConnectedClientCount--;
                            OnClientDisconnected?.Invoke(addr);
                        };
                        await handler.HandleAsync();
                    });
                }
                catch (SocketException) when (!_isRunning)
                {
                    // Đây là lỗi BÌNH THƯỜNG khi bấm nút Dừng — Accept() đang block
                    // thì bị Close() ngắt ngang. Không phải bug, chỉ cần log nhẹ.
                    Logger.Info("Server dừng lắng nghe (do người dùng bấm Dừng).");
                }
                catch (ObjectDisposedException) when (!_isRunning)
                {
                    // Cùng nguyên nhân — socket đã bị Dispose trong lúc Accept() đang chạy
                    Logger.Info("Server dừng lắng nghe (socket đã đóng).");
                }
                catch (Exception ex) when (_isRunning)
                {
                    // Chỉ coi là lỗi thật khi server KHÔNG chủ động dừng
                    Logger.Error("Lỗi accept client.", ex);
                }
            }
        }

        // ── Dừng server ───────────────────────────────────────────────────
        public void Stop()
        {
            _isRunning = false;
            _serverSocket?.Close();
            _serverSocket = null;
            Logger.Info("Server đã dừng.");
            OnStatusChanged?.Invoke("Đã dừng");
        }
    }
}
