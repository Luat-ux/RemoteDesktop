using System;
using System.Windows.Forms;

namespace RemoteDesktop.Forms
{
    /// <summary>
    /// Form cài đặt: chất lượng JPEG, FPS mục tiêu, port mặc định.
    /// </summary>
    public partial class SettingsForm : Form
    {
        // ── Ánh xạ ComboBox index → giá trị quality JPEG ─────────────────
        private static readonly int[] QUALITY_VALUES = { 40, 65, 85 };

        // ── Properties trả về cho MainForm ───────────────────────────────
        public int JpegQuality     { get; private set; } = 65;
        public int FrameIntervalMs { get; private set; } = 50; // 1000ms / 20FPS
        public int DefaultPort     { get; private set; } = 9000;

        public SettingsForm()
        {
            InitializeComponent();
        }

        // ── TrackBar FPS thay đổi ─────────────────────────────────────────
        private void TrackFps_Scroll(object sender, EventArgs e)
        {
            lblFpsValue.Text = $"{trackFps.Value} FPS";
        }

        // ── Lưu cài đặt ──────────────────────────────────────────────────
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Port không hợp lệ (1 – 65535).", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPort.Focus();
                return;
            }

            JpegQuality     = QUALITY_VALUES[cboQuality.SelectedIndex];
            FrameIntervalMs = 1000 / trackFps.Value;
            DefaultPort     = port;

            DialogResult = DialogResult.OK;
            Close();
        }

        // ── Hủy ──────────────────────────────────────────────────────────
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
