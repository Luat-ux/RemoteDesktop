using System.Net;
using System.Net.Sockets;
using RemoteDesktop.Services;

namespace RemoteDesktop.Forms
{
    public partial class ServerForm : Form
    {
        private TcpServer?    _tcpServer;
        private ServerConfig  _config = null!;

        public ServerForm()
        {
            InitializeComponent();
            LoadInitialData();

            // Kết nối Logger vào ListBox log
            Logger.OnLog += AppendLog;
        }

        // ── Khởi tạo dữ liệu hiển thị ────────────────────────────────────
        private void LoadInitialData()
        {
            _config          = ConfigManager.LoadConfig();
            lblIpAddress.Text = GetLocalIpAddress();
            Logger.Info("Server khởi động. Mật khẩu mặc định: 123456");
            Logger.Info($"IP máy này: {GetLocalIpAddress()} — Port mặc định: 9000");
        }

        // ── Nút Khởi động Server ─────────────────────────────────────────
        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Port không hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _config    = ConfigManager.LoadConfig();
            _tcpServer = new TcpServer(_config);

            _tcpServer.OnClientConnected    += addr => Invoke(() =>
            {
                lblClientCount.Text      = _tcpServer.ConnectedClientCount.ToString();
                lblClientCount.ForeColor = System.Drawing.Color.LimeGreen;
            });
            _tcpServer.OnClientDisconnected += addr => Invoke(() =>
            {
                lblClientCount.Text      = _tcpServer.ConnectedClientCount.ToString();
                lblClientCount.ForeColor = _tcpServer.ConnectedClientCount > 0
                    ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
            });
            _tcpServer.OnStatusChanged += status => Invoke(() =>
            {
                lblStatus.Text      = status;
                lblStatus.ForeColor = status.Contains("chạy") || status.Contains("Port")
                    ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Gray;
            });

            btnStart.Enabled = false;
            btnStop.Enabled  = true;
            txtPort.Enabled  = false;

            try
            {
                // StartAsync chạy vòng lặp accept() không block UI
                await _tcpServer.StartAsync(port);
            }
            catch (Exception ex)
            {
                Logger.Error("Không thể khởi động server.", ex);
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi khởi động",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetServerState();
            }
        }

        // ── Nút Dừng ─────────────────────────────────────────────────────
        private void BtnStop_Click(object sender, EventArgs e)
        {
            _tcpServer?.Stop();
            ResetServerState();
        }

        // ── Nút Đổi mật khẩu ─────────────────────────────────────────────
        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            string? newPassword = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập mật khẩu mới:", "Đổi mật khẩu", "");

            if (string.IsNullOrWhiteSpace(newPassword)) return;

            ConfigManager.ChangePassword(newPassword);
            _config = ConfigManager.LoadConfig();
            Logger.Info("Đã đổi mật khẩu. Client kết nối mới sẽ dùng mật khẩu này.");
            MessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Xóa log ──────────────────────────────────────────────────────
        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        // ── Đóng form ────────────────────────────────────────────────────
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tcpServer?.Stop();
        }

        // ── Thêm dòng vào log (thread-safe) ─────────────────────────────
        private void AppendLog(string message)
        {
            if (lstLog.InvokeRequired)
            {
                lstLog.Invoke(() => AppendLog(message));
                return;
            }
            lstLog.Items.Add(message);
            lstLog.TopIndex = lstLog.Items.Count - 1; // auto scroll xuống
        }

        private void ResetServerState()
        {
            btnStart.Enabled    = true;
            btnStop.Enabled     = false;
            txtPort.Enabled     = true;
            lblClientCount.Text = "0";
        }

        // ── Lấy IP LAN của máy ────────────────────────────────────────────
        private static string GetLocalIpAddress()
        {
            try
            {
                var host    = Dns.GetHostEntry(Dns.GetHostName());
                var localIp = host.AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                return localIp?.ToString() ?? "Không xác định";
            }
            catch { return "Không xác định"; }
        }
    }
}
