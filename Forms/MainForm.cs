using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
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
        private System.Windows.Forms.Timer _frameTimer = null;
        private int _remoteScreenWidth;
        private int _remoteScreenHeight;

        public MainForm()
        {
            InitializeComponent();
            InitializeFrameTimer();
        }

        private void InitializeFrameTimer()
        {
            _frameTimer = new System.Windows.Forms.Timer();
            _frameTimer.Interval = 50;
            _frameTimer.Tick += FrameTimer_Tick;
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

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
        }

        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            if (!_isConnected) return;
            // FileTransferForm dùng ConnectionService
            MessageBox.Show("Chức năng gửi file — kết nối với Linh để tích hợp.");
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            using var settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() != DialogResult.OK) return;
            _frameTimer.Interval = settingsForm.FrameIntervalMs;
        }

        // ── Kết nối — Task.Run bọc Socket.Connect() ──────────────────────
        private async void ConnectAsync(string serverIp, int serverPort, string passwordHash)
        {
            try
            {
                SetConnectionStatus(isConnecting: true);

                // socket() + connect() chạy trên background thread
                await _connectionService.ConnectAsync(serverIp, serverPort);

                // Xác thực mật khẩu SHA-256
                bool isAuthenticated = await AuthenticateAsync(passwordHash);
                if (!isAuthenticated)
                {
                    MessageBox.Show("Sai mật khẩu. Kết nối bị từ chối.",
                        "Xác thực thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DisconnectFromServer();
                    return;
                }

                _isConnected = true;
                SetConnectionStatus(isConnecting: false, isConnected: true);
                _frameTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisconnectFromServer();
            }
        }

        // ── Xác thực — send() + recv() trên background thread ────────────
        private async Task<bool> AuthenticateAsync(string passwordHash)
        {
            byte[] hashBytes = Encoding.UTF8.GetBytes(passwordHash);

            // send() — gửi AUTH_REQUEST
            await _connectionService.SendPacketAsync(Protocol.AUTH_REQUEST, hashBytes);

            // recv() — nhận AUTH_RESPONSE
            var (_, payload) = await _connectionService.ReceivePacketAsync();

            return payload.Length > 0 && payload[0] == Protocol.AUTH_SUCCESS;
        }

        // ── Ngắt kết nối — close() ───────────────────────────────────────
        private async void DisconnectFromServer()
        {
            _frameTimer.Stop();
            _isConnected = false;

            await _connectionService.DisconnectAsync();

            SetConnectionStatus(isConnected: false);
            UpdateScreenDisplay(null);
        }

        // ── Timer — send(REQUEST_FRAME) + recv(JPEG) liên tục ────────────
        private async void FrameTimer_Tick(object? sender, EventArgs e)
        {
            if (!_isConnected) return;

            try
            {
                // send() — yêu cầu frame mới
                await _connectionService.SendPacketAsync(Protocol.REQUEST_FRAME, []);

                // recv() — nhận JPEG bytes
                var (_, jpegBytes) = await _connectionService.ReceivePacketAsync();

                Image screenImage = DecodeJpegFrame(jpegBytes);
                UpdateScreenDisplay(screenImage);
            }
            catch
            {
                Invoke(() => DisconnectFromServer());
            }
        }

        // ── Decode JPEG → Image ──────────────────────────────────────────
        private static Image DecodeJpegFrame(byte[] jpegBytes)
        {
            using var ms = new MemoryStream(jpegBytes);
            return Image.FromStream(ms);
        }

        // ── Cập nhật PictureBox (thread-safe) ────────────────────────────
        private void UpdateScreenDisplay(Image? screenImage)
        {
            if (pictureBoxScreen.InvokeRequired)
            {
                pictureBoxScreen.Invoke(() => UpdateScreenDisplay(screenImage));
                return;
            }
            pictureBoxScreen.Image?.Dispose();
            pictureBoxScreen.Image = screenImage;
        }

        // ── Chuột — send() InputPacket ────────────────────────────────────
        private void PictureBoxScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isConnected) return;
            SendMousePacket(e.X, e.Y, "MOVE", 0);
        }

        private void PictureBoxScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_isConnected) return;
            string button = e.Button == MouseButtons.Left ? "LEFT" :
                            e.Button == MouseButtons.Right ? "RIGHT" : "MIDDLE";
            SendMousePacket(e.X, e.Y, $"DOWN_{button}", 0);
        }

        private void PictureBoxScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isConnected) return;
            string button = e.Button == MouseButtons.Left ? "LEFT" :
                            e.Button == MouseButtons.Right ? "RIGHT" : "MIDDLE";
            SendMousePacket(e.X, e.Y, $"UP_{button}", 0);
        }

        private void PictureBoxScreen_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_isConnected) return;
            SendMousePacket(e.X, e.Y, "WHEEL", e.Delta);
        }

        // ── send() MousePacket — Task.Run để không block UI ──────────────
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

                // send() trên background thread
                await _connectionService.SendPacketAsync(Protocol.INPUT_MOUSE, payload);
            }
            catch { }
        }

        // ── Bàn phím — send() KeyPacket ───────────────────────────────────
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

        // ── send() KeyPacket — Task.Run để không block UI ─────────────────
        private async void SendKeyPacket(int keyCode, bool isKeyDown)
        {
            try
            {
                byte[] payload = [
                    .. BitConverter.GetBytes(keyCode),
                    (byte)(isKeyDown ? 1 : 0)
                ];

                // send() trên background thread
                await _connectionService.SendPacketAsync(Protocol.INPUT_KEY, payload);
            }
            catch { }
        }

        // ── Helpers ───────────────────────────────────────────────────────
        private int ScaleCoordinateX(int x)
        {
            if (_remoteScreenWidth == 0 || pictureBoxScreen.Width == 0) return x;
            return (int)((double)x / pictureBoxScreen.Width * _remoteScreenWidth);
        }

        private int ScaleCoordinateY(int y)
        {
            if (_remoteScreenHeight == 0 || pictureBoxScreen.Height == 0) return y;
            return (int)((double)y / pictureBoxScreen.Height * _remoteScreenHeight);
        }

        private void SetConnectionStatus(bool isConnecting = false, bool isConnected = false)
        {
            if (InvokeRequired) { Invoke(() => SetConnectionStatus(isConnecting, isConnected)); return; }

            if (isConnecting)
            {
                lblStatusConnection.Text = "Đang kết nối...";
                lblStatusConnection.ForeColor = System.Drawing.Color.Yellow;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = false;
            }
            else if (isConnected)
            {
                lblStatusConnection.Text = "Đã kết nối";
                lblStatusConnection.ForeColor = System.Drawing.Color.LimeGreen;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnSendFile.Enabled = true;
            }
            else
            {
                lblStatusConnection.Text = "Chưa kết nối";
                lblStatusConnection.ForeColor = System.Drawing.Color.Gray;
                lblStatusPing.Text = "Ping: --";
                lblStatusFps.Text = "FPS: --";
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                btnSendFile.Enabled = false;
            }
        }
    }
}