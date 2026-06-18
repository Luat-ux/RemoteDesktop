using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RemoteDesktop.Forms
{
    /// <summary>
    /// Form nhập thông tin kết nối: IP, Port, Password.
    /// Trả về DialogResult.OK nếu người dùng nhấn Kết nối và dữ liệu hợp lệ.
    /// </summary>
    public partial class ConnectionForm : Form
    {
        // ── Properties trả về cho MainForm ───────────────────────────────
        public string ServerIp       { get; private set; } = string.Empty;
        public int    ServerPort     { get; private set; }
        public string PasswordHash   { get; private set; } = string.Empty;

        public ConnectionForm()
        {
            InitializeComponent();
        }

        // ── Nhấn Kết nối ─────────────────────────────────────────────────
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            ServerIp     = txtIp.Text.Trim();
            ServerPort   = int.Parse(txtPort.Text.Trim());
            PasswordHash = HashPassword(txtPassword.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        // ── Nhấn Hủy ─────────────────────────────────────────────────────
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // ── Validate đầu vào ─────────────────────────────────────────────
        private bool ValidateInputs()
        {
            HideError();

            if (string.IsNullOrWhiteSpace(txtIp.Text))
            {
                ShowError("Vui lòng nhập địa chỉ IP.");
                txtIp.Focus();
                return false;
            }

            if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
            {
                ShowError("Port không hợp lệ (1 – 65535).");
                txtPort.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowError("Vui lòng nhập mật khẩu.");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        // ── Hash mật khẩu SHA-256 trước khi gửi qua mạng ────────────────
        private static string HashPassword(string password)
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hashBytes); // 64 ký tự hex
        }

        private void ShowError(string message)
        {
            lblError.Text    = message;
            lblError.Visible = true;
        }

        private void HideError()
        {
            lblError.Text    = string.Empty;
            lblError.Visible = false;
        }
    }
}
