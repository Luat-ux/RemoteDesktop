namespace RemoteDesktop.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pictureBoxScreen = new PictureBox();
            panelToolbar = new Panel();
            btnConnect = new Button();
            btnDisconnect = new Button();
            btnSendFile = new Button();
            btnSettings = new Button();
            statusStrip = new StatusStrip();
            lblStatusConnection = new ToolStripStatusLabel();
            separatorStatus = new ToolStripSeparator();
            lblStatusPing = new ToolStripStatusLabel();
            separatorStatus2 = new ToolStripSeparator();
            lblStatusFps = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScreen).BeginInit();
            panelToolbar.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxScreen
            // 
            pictureBoxScreen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxScreen.BackColor = Color.Black;
            pictureBoxScreen.Cursor = Cursors.Cross;
            pictureBoxScreen.Location = new Point(0, 67);
            pictureBoxScreen.Margin = new Padding(3, 4, 3, 4);
            pictureBoxScreen.Name = "pictureBoxScreen";
            pictureBoxScreen.Size = new Size(1371, 867);
            pictureBoxScreen.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxScreen.TabIndex = 0;
            pictureBoxScreen.TabStop = false;
            pictureBoxScreen.MouseDown += PictureBoxScreen_MouseDown;
            pictureBoxScreen.MouseMove += PictureBoxScreen_MouseMove;
            pictureBoxScreen.MouseUp += PictureBoxScreen_MouseUp;
            pictureBoxScreen.MouseWheel += PictureBoxScreen_MouseWheel;
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.FromArgb(45, 45, 48);
            panelToolbar.Controls.Add(btnConnect);
            panelToolbar.Controls.Add(btnDisconnect);
            panelToolbar.Controls.Add(btnSendFile);
            panelToolbar.Controls.Add(btnSettings);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 0);
            panelToolbar.Margin = new Padding(3, 4, 3, 4);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(1371, 72);
            panelToolbar.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(0, 122, 204);
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(14, 13);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(126, 40);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Kết nối";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.BackColor = Color.FromArgb(200, 60, 60);
            btnDisconnect.Enabled = false;
            btnDisconnect.FlatStyle = FlatStyle.Flat;
            btnDisconnect.ForeColor = Color.White;
            btnDisconnect.Location = new Point(153, 13);
            btnDisconnect.Margin = new Padding(3, 4, 3, 4);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(126, 40);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Ngắt kết nối";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += BtnDisconnect_Click;
            // 
            // btnSendFile
            // 
            btnSendFile.BackColor = Color.FromArgb(16, 124, 16);
            btnSendFile.Enabled = false;
            btnSendFile.FlatStyle = FlatStyle.Flat;
            btnSendFile.ForeColor = Color.White;
            btnSendFile.Location = new Point(293, 13);
            btnSendFile.Margin = new Padding(3, 4, 3, 4);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(126, 40);
            btnSendFile.TabIndex = 2;
            btnSendFile.Text = "Gửi file";
            btnSendFile.UseVisualStyleBackColor = false;
            btnSendFile.Click += BtnSendFile_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(80, 80, 80);
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(432, 13);
            btnSettings.Margin = new Padding(3, 4, 3, 4);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(103, 40);
            btnSettings.TabIndex = 3;
            btnSettings.Text = "Cài đặt";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += BtnSettings_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatusConnection, separatorStatus, lblStatusPing, separatorStatus2, lblStatusFps });
            statusStrip.Location = new Point(0, 974);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1371, 26);
            statusStrip.TabIndex = 2;
            // 
            // lblStatusConnection
            // 
            lblStatusConnection.ForeColor = Color.Gray;
            lblStatusConnection.Name = "lblStatusConnection";
            lblStatusConnection.Size = new Size(92, 20);
            lblStatusConnection.Text = "Chưa kết nối";
            // 
            // separatorStatus
            // 
            separatorStatus.Name = "separatorStatus";
            separatorStatus.Size = new Size(6, 26);
            // 
            // lblStatusPing
            // 
            lblStatusPing.Name = "lblStatusPing";
            lblStatusPing.Size = new Size(57, 20);
            lblStatusPing.Text = "Ping: --";
            // 
            // separatorStatus2
            // 
            separatorStatus2.Name = "separatorStatus2";
            separatorStatus2.Size = new Size(6, 26);
            // 
            // lblStatusFps
            // 
            lblStatusFps.Name = "lblStatusFps";
            lblStatusFps.Size = new Size(51, 20);
            lblStatusFps.Text = "FPS: --";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1371, 1000);
            Controls.Add(pictureBoxScreen);
            Controls.Add(panelToolbar);
            Controls.Add(statusStrip);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 651);
            Name = "MainForm";
            Text = "Remote Desktop Client";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBoxScreen).EndInit();
            panelToolbar.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ── Controls khai báo ──────────────────────────────────────────────
        private System.Windows.Forms.PictureBox         pictureBoxScreen;
        private System.Windows.Forms.Panel              panelToolbar;
        private System.Windows.Forms.Button             btnConnect;
        private System.Windows.Forms.Button             btnDisconnect;
        private System.Windows.Forms.Button             btnSendFile;
        private System.Windows.Forms.Button             btnSettings;
        private System.Windows.Forms.StatusStrip        statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusConnection;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusPing;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusFps;
        private System.Windows.Forms.ToolStripSeparator   separatorStatus;
        private System.Windows.Forms.ToolStripSeparator   separatorStatus2;
    }
}
