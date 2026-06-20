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
                catch (Exception ex) when (_isRunning)
                {
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
