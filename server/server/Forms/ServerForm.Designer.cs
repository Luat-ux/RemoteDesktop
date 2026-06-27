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
            panelToolbar = new Panel();
            btnStart = new Button();
            btnStop = new Button();
            lblPortLabel = new Label();
            txtPort = new TextBox();
            btnChangePass = new Button();
            panelInfo = new Panel();
            panel5 = new Panel();
            label4 = new Label();
            panel6 = new Panel();
            lblClientLabel = new Label();
            lblClientCount = new Label();
            panel3 = new Panel();
            lblStatusLabel = new Label();
            lblStatus = new Label();
            panel2 = new Panel();
            lblIpLabel = new Label();
            lblIpAddress = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            lblPassLabel = new Label();
            lblPassHint = new Label();
            panelLog = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lstLog = new ListBox();
            btnClearLog = new Button();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panelLog.SuspendLayout();
            SuspendLayout();
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.FromArgb(45, 45, 48);
            panelToolbar.Location = new Point(0, 0);
            panelToolbar.Margin = new Padding(3, 4, 3, 4);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(800, 96);
            panelToolbar.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(22, 101, 52);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(11, 528);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 40);
            btnStart.TabIndex = 0;
            btnStart.Text = "▶  Khởi động";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(127, 29, 29);
            btnStop.Enabled = false;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(11, 588);
            btnStop.Margin = new Padding(3, 4, 3, 4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(150, 40);
            btnStop.TabIndex = 1;
            btnStop.Text = "■  Dừng";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += BtnStop_Click;
            // 
            // lblPortLabel
            // 
            lblPortLabel.AutoSize = true;
            lblPortLabel.Font = new Font("Segoe UI", 9F);
            lblPortLabel.ForeColor = Color.LightGray;
            lblPortLabel.Location = new Point(12, 480);
            lblPortLabel.Name = "lblPortLabel";
            lblPortLabel.Size = new Size(38, 20);
            lblPortLabel.TabIndex = 2;
            lblPortLabel.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Segoe UI", 9F);
            txtPort.Location = new Point(88, 477);
            txtPort.Margin = new Padding(3, 4, 3, 4);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(68, 27);
            txtPort.TabIndex = 3;
            txtPort.Text = "9000";
            // 
            // btnChangePass
            // 
            btnChangePass.BackColor = Color.FromArgb(80, 80, 80);
            btnChangePass.FlatAppearance.BorderSize = 0;
            btnChangePass.FlatStyle = FlatStyle.Flat;
            btnChangePass.Font = new Font("Segoe UI", 9F);
            btnChangePass.ForeColor = Color.White;
            btnChangePass.Location = new Point(13, 646);
            btnChangePass.Margin = new Padding(3, 4, 3, 4);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(150, 40);
            btnChangePass.TabIndex = 4;
            btnChangePass.Text = "🔑  Đổi mật khẩu";
            btnChangePass.UseVisualStyleBackColor = false;
            btnChangePass.Click += BtnChangePass_Click;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.FromArgb(28, 28, 30);
            panelInfo.Location = new Point(0, 96);
            panelInfo.Margin = new Padding(3, 4, 3, 4);
            panelInfo.Name = "panelInfo";
            panelInfo.Padding = new Padding(10);
            panelInfo.Size = new Size(800, 96);
            panelInfo.TabIndex = 1;
            panelInfo.Paint += panelInfo_Paint;
            // 
            // panel5
            // 
            panel5.Controls.Add(label4);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(lblClientLabel);
            panel5.Controls.Add(lblClientCount);
            panel5.Location = new Point(9, 199);
            panel5.Name = "panel5";
            panel5.Size = new Size(198, 55);
            panel5.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(118, 20);
            label4.Name = "label4";
            label4.Size = new Size(17, 20);
            label4.TabIndex = 4;
            label4.Text = "0";
            // 
            // panel6
            // 
            panel6.Location = new Point(92, 90);
            panel6.Name = "panel6";
            panel6.Size = new Size(193, 76);
            panel6.TabIndex = 0;
            // 
            // lblClientLabel
            // 
            lblClientLabel.AutoSize = true;
            lblClientLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClientLabel.ForeColor = Color.White;
            lblClientLabel.Location = new Point(20, 21);
            lblClientLabel.Name = "lblClientLabel";
            lblClientLabel.Size = new Size(98, 20);
            lblClientLabel.TabIndex = 2;
            lblClientLabel.Text = "👥 CLIENTS:";
            // 
            // lblClientCount
            // 
            lblClientCount.AutoSize = true;
            lblClientCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClientCount.ForeColor = Color.Gray;
            lblClientCount.Location = new Point(103, 21);
            lblClientCount.Name = "lblClientCount";
            lblClientCount.Size = new Size(18, 20);
            lblClientCount.TabIndex = 3;
            lblClientCount.Text = "0";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblStatusLabel);
            panel3.Controls.Add(lblStatus);
            panel3.Location = new Point(9, 122);
            panel3.Name = "panel3";
            panel3.Size = new Size(198, 57);
            panel3.TabIndex = 10;
            // 
            // lblStatusLabel
            // 
            lblStatusLabel.AutoSize = true;
            lblStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusLabel.ForeColor = Color.DarkGray;
            lblStatusLabel.Location = new Point(7, 6);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(123, 20);
            lblStatusLabel.TabIndex = 0;
            lblStatusLabel.Text = "● TRẠNG THÁI :";
            lblStatusLabel.Click += lblStatusLabel_Click_1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.Transparent;
            lblStatus.Location = new Point(10, 33);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(77, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Chưa chạy";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblIpLabel);
            panel2.Controls.Add(lblIpAddress);
            panel2.Location = new Point(9, 273);
            panel2.Name = "panel2";
            panel2.Size = new Size(198, 65);
            panel2.TabIndex = 0;
            panel2.Paint += panel2_Paint;
            // 
            // lblIpLabel
            // 
            lblIpLabel.AutoSize = true;
            lblIpLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIpLabel.ForeColor = Color.White;
            lblIpLabel.Location = new Point(18, 14);
            lblIpLabel.Name = "lblIpLabel";
            lblIpLabel.Size = new Size(121, 20);
            lblIpLabel.TabIndex = 4;
            lblIpLabel.Text = "🌐IP MÁY NÀY ";
            lblIpLabel.Click += lblIpLabel_Click_1;
            // 
            // lblIpAddress
            // 
            lblIpAddress.AutoSize = true;
            lblIpAddress.Font = new Font("Segoe UI", 9F);
            lblIpAddress.ForeColor = Color.LightSkyBlue;
            lblIpAddress.Location = new Point(23, 34);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new Size(18, 20);
            lblIpAddress.TabIndex = 5;
            lblIpAddress.Text = "...";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(lblPassLabel);
            panel1.Controls.Add(lblPassHint);
            panel1.Location = new Point(10, 359);
            panel1.Name = "panel1";
            panel1.Size = new Size(197, 75);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // panel4
            // 
            panel4.Location = new Point(92, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(193, 76);
            panel4.TabIndex = 0;
            // 
            // lblPassLabel
            // 
            lblPassLabel.AutoSize = true;
            lblPassLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassLabel.ForeColor = Color.White;
            lblPassLabel.Location = new Point(22, 20);
            lblPassLabel.Name = "lblPassLabel";
            lblPassLabel.Size = new Size(112, 20);
            lblPassLabel.TabIndex = 6;
            lblPassLabel.Text = "🔐MẬT KHẨU";
            lblPassLabel.Click += lblPassLabel_Click;
            // 
            // lblPassHint
            // 
            lblPassHint.AutoSize = true;
            lblPassHint.Font = new Font("Segoe UI", 9F);
            lblPassHint.ForeColor = Color.DarkGray;
            lblPassHint.Location = new Point(17, 43);
            lblPassHint.Name = "lblPassHint";
            lblPassHint.Size = new Size(168, 20);
            lblPassHint.TabIndex = 7;
            lblPassHint.Text = "(xem server_config.json)";
            lblPassHint.Click += lblPassHint_Click;
            // 
            // panelLog
            // 
            panelLog.Controls.Add(label3);
            panelLog.Controls.Add(label2);
            panelLog.Controls.Add(label1);
            panelLog.Controls.Add(panel1);
            panelLog.Controls.Add(panel5);
            panelLog.Controls.Add(btnChangePass);
            panelLog.Controls.Add(panel2);
            panelLog.Controls.Add(panel3);
            panelLog.Controls.Add(txtPort);
            panelLog.Controls.Add(lblPortLabel);
            panelLog.Controls.Add(btnStop);
            panelLog.Controls.Add(btnStart);
            panelLog.Controls.Add(lstLog);
            panelLog.Controls.Add(btnClearLog);
            panelLog.Dock = DockStyle.Fill;
            panelLog.Location = new Point(0, 0);
            panelLog.Margin = new Padding(3, 4, 3, 4);
            panelLog.Name = "panelLog";
            panelLog.Size = new Size(800, 733);
            panelLog.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(254, 82);
            label3.Name = "label3";
            label3.Size = new Size(172, 28);
            label3.TabIndex = 13;
            label3.Text = "Nhật kí hoạt động";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(152, 21);
            label2.Name = "label2";
            label2.Size = new Size(518, 50);
            label2.TabIndex = 12;
            label2.Text = "🖥REMOTE DESKTOP SERVER ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(13, 82);
            label1.Name = "label1";
            label1.Size = new Size(187, 28);
            label1.TabIndex = 11;
            label1.Text = "THÔNG TIN SERVER";
            // 
            // lstLog
            // 
            lstLog.BackColor = Color.FromArgb(18, 18, 18);
            lstLog.BorderStyle = BorderStyle.None;
            lstLog.Font = new Font("Consolas", 9F);
            lstLog.ForeColor = Color.LightGreen;
            lstLog.Location = new Point(224, 123);
            lstLog.Margin = new Padding(3, 4, 3, 4);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(576, 522);
            lstLog.TabIndex = 0;
            lstLog.SelectedIndexChanged += lstLog_SelectedIndexChanged;
            // 
            // btnClearLog
            // 
            btnClearLog.BackColor = Color.FromArgb(35, 35, 35);
            btnClearLog.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
            btnClearLog.FlatStyle = FlatStyle.Flat;
            btnClearLog.Font = new Font("Segoe UI", 8.5F);
            btnClearLog.ForeColor = Color.Gray;
            btnClearLog.Location = new Point(224, 652);
            btnClearLog.Margin = new Padding(3, 4, 3, 4);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(576, 77);
            btnClearLog.TabIndex = 1;
            btnClearLog.Text = "Xóa log";
            btnClearLog.UseVisualStyleBackColor = false;
            btnClearLog.Click += BtnClearLog_Click;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 29, 35);
            ClientSize = new Size(800, 733);
            Controls.Add(panelLog);
            Controls.Add(panelInfo);
            Controls.Add(panelToolbar);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(637, 544);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Remote Desktop — Server";
            FormClosing += ServerForm_FormClosing;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelLog.ResumeLayout(false);
            panelLog.PerformLayout();
            ResumeLayout(false);
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
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
    }
}