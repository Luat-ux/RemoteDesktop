namespace RemoteDesktop.Forms
{
    partial class ServerForm
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
            this.components = new System.ComponentModel.Container();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.lblPortLabel = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblClientLabel = new System.Windows.Forms.Label();
            this.lblClientCount = new System.Windows.Forms.Label();
            this.lblIpLabel = new System.Windows.Forms.Label();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.lblPassLabel = new System.Windows.Forms.Label();
            this.lblPassHint = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.panelToolbar.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.SuspendLayout();

            // ────────────────────────────────────────────────────────────
            // panelToolbar
            // ────────────────────────────────────────────────────────────
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelToolbar.Controls.Add(this.btnStart);
            this.panelToolbar.Controls.Add(this.btnStop);
            this.panelToolbar.Controls.Add(this.lblPortLabel);
            this.panelToolbar.Controls.Add(this.txtPort);
            this.panelToolbar.Controls.Add(this.btnChangePass);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(700, 54);
            this.panelToolbar.TabIndex = 0;

            // ────────────────────────────────────────────────────────────
            // btnStart
            // ────────────────────────────────────────────────────────────
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(16, 124, 16);
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "▶  Khởi động";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);

            // ────────────────────────────────────────────────────────────
            // btnStop
            // ────────────────────────────────────────────────────────────
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(134, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 30);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "■  Dừng";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);

            // ────────────────────────────────────────────────────────────
            // lblPortLabel
            // ────────────────────────────────────────────────────────────
            this.lblPortLabel.AutoSize = true;
            this.lblPortLabel.ForeColor = System.Drawing.Color.LightGray;
            this.lblPortLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPortLabel.Location = new System.Drawing.Point(240, 19);
            this.lblPortLabel.Name = "lblPortLabel";
            this.lblPortLabel.Size = new System.Drawing.Size(29, 15);
            this.lblPortLabel.TabIndex = 2;
            this.lblPortLabel.Text = "Port:";

            // ────────────────────────────────────────────────────────────
            // txtPort
            // ────────────────────────────────────────────────────────────
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPort.Location = new System.Drawing.Point(276, 16);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(60, 23);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "9000";

            // ────────────────────────────────────────────────────────────
            // btnChangePass
            // ────────────────────────────────────────────────────────────
            this.btnChangePass.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnChangePass.FlatAppearance.BorderSize = 0;
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChangePass.ForeColor = System.Drawing.Color.White;
            this.btnChangePass.Location = new System.Drawing.Point(354, 12);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(120, 30);
            this.btnChangePass.TabIndex = 4;
            this.btnChangePass.Text = "🔑  Đổi mật khẩu";
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Click += new System.EventHandler(this.BtnChangePass_Click);

            // ────────────────────────────────────────────────────────────
            // panelInfo
            // ────────────────────────────────────────────────────────────
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.panelInfo.Controls.Add(this.lblStatusLabel);
            this.panelInfo.Controls.Add(this.lblStatus);
            this.panelInfo.Controls.Add(this.lblClientLabel);
            this.panelInfo.Controls.Add(this.lblClientCount);
            this.panelInfo.Controls.Add(this.lblIpLabel);
            this.panelInfo.Controls.Add(this.lblIpAddress);
            this.panelInfo.Controls.Add(this.lblPassLabel);
            this.panelInfo.Controls.Add(this.lblPassHint);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 54);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(700, 76);
            this.panelInfo.TabIndex = 1;

            // lblStatusLabel
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.White;
            this.lblStatusLabel.Location = new System.Drawing.Point(16, 12);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(63, 15);
            this.lblStatusLabel.TabIndex = 0;
            this.lblStatusLabel.Text = "Trạng thái:";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(88, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Chưa chạy";

            // lblClientLabel
            this.lblClientLabel.AutoSize = true;
            this.lblClientLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientLabel.ForeColor = System.Drawing.Color.White;
            this.lblClientLabel.Location = new System.Drawing.Point(240, 12);
            this.lblClientLabel.Name = "lblClientLabel";
            this.lblClientLabel.Size = new System.Drawing.Size(46, 15);
            this.lblClientLabel.TabIndex = 2;
            this.lblClientLabel.Text = "Clients:";

            // lblClientCount
            this.lblClientCount.AutoSize = true;
            this.lblClientCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientCount.ForeColor = System.Drawing.Color.Gray;
            this.lblClientCount.Location = new System.Drawing.Point(292, 12);
            this.lblClientCount.Name = "lblClientCount";
            this.lblClientCount.Size = new System.Drawing.Size(13, 15);
            this.lblClientCount.TabIndex = 3;
            this.lblClientCount.Text = "0";

            // lblIpLabel
            this.lblIpLabel.AutoSize = true;
            this.lblIpLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIpLabel.ForeColor = System.Drawing.Color.White;
            this.lblIpLabel.Location = new System.Drawing.Point(16, 42);
            this.lblIpLabel.Name = "lblIpLabel";
            this.lblIpLabel.Size = new System.Drawing.Size(66, 15);
            this.lblIpLabel.TabIndex = 4;
            this.lblIpLabel.Text = "IP máy này:";

            // lblIpAddress
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIpAddress.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblIpAddress.Location = new System.Drawing.Point(88, 42);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(16, 15);
            this.lblIpAddress.TabIndex = 5;
            this.lblIpAddress.Text = "...";

            // lblPassLabel
            this.lblPassLabel.AutoSize = true;
            this.lblPassLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassLabel.ForeColor = System.Drawing.Color.White;
            this.lblPassLabel.Location = new System.Drawing.Point(240, 42);
            this.lblPassLabel.Name = "lblPassLabel";
            this.lblPassLabel.Size = new System.Drawing.Size(63, 15);
            this.lblPassLabel.TabIndex = 6;
            this.lblPassLabel.Text = "Mật khẩu:";

            // lblPassHint
            this.lblPassHint.AutoSize = true;
            this.lblPassHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassHint.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPassHint.Location = new System.Drawing.Point(310, 42);
            this.lblPassHint.Name = "lblPassHint";
            this.lblPassHint.Size = new System.Drawing.Size(148, 15);
            this.lblPassHint.TabIndex = 7;
            this.lblPassHint.Text = "(xem server_config.json)";

            // ────────────────────────────────────────────────────────────
            // panelLog  (chứa lstLog + btnClearLog)
            // ────────────────────────────────────────────────────────────
            this.panelLog.Controls.Add(this.lstLog);
            this.panelLog.Controls.Add(this.btnClearLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(0, 130);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(700, 420);
            this.panelLog.TabIndex = 2;

            // ────────────────────────────────────────────────────────────
            // lstLog
            // ────────────────────────────────────────────────────────────
            this.lstLog.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstLog.ForeColor = System.Drawing.Color.LightGreen;
            this.lstLog.Location = new System.Drawing.Point(0, 0);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(700, 394);
            this.lstLog.TabIndex = 0;

            // ────────────────────────────────────────────────────────────
            // btnClearLog
            // ────────────────────────────────────────────────────────────
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
            this.btnClearLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClearLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btnClearLog.FlatAppearance.BorderSize = 1;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnClearLog.ForeColor = System.Drawing.Color.Gray;
            this.btnClearLog.Location = new System.Drawing.Point(0, 394);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(700, 26);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Xóa log";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);

            // ────────────────────────────────────────────────────────────
            // ServerForm
            // ────────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.ClientSize = new System.Drawing.Size(700, 550);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelToolbar);
            this.MinimumSize = new System.Drawing.Size(560, 420);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Desktop — Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelLog.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // ── Khai báo controls ────────────────────────────────────────────
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Label lblPortLabel;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblClientLabel;
        private System.Windows.Forms.Label lblClientCount;
        private System.Windows.Forms.Label lblIpLabel;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Label lblPassLabel;
        private System.Windows.Forms.Label lblPassHint;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnClearLog;
    }
}