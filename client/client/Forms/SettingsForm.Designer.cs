namespace RemoteDesktop.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblQuality = new Label();
            cboQuality = new ComboBox();
            lblQualityHint = new Label();
            lblFps = new Label();
            trackFps = new TrackBar();
            lblFpsValue = new Label();
            lblPort = new Label();
            txtPort = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)trackFps).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(45, 45, 48);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(426, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "  Cài đặt";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblQuality
            // 
            lblQuality.AutoSize = true;
            lblQuality.Location = new Point(23, 83);
            lblQuality.Name = "lblQuality";
            lblQuality.Size = new Size(158, 20);
            lblQuality.TabIndex = 1;
            lblQuality.Text = "Chất lượng ảnh (JPEG):";
            // 
            // cboQuality
            // 
            cboQuality.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboQuality.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuality.Items.AddRange(new object[] { "Thấp (40%)", "Trung bình (65%)", "Cao (85%)" });
            cboQuality.Location = new Point(23, 107);
            cboQuality.Margin = new Padding(3, 4, 3, 4);
            cboQuality.Name = "cboQuality";
            cboQuality.Size = new Size(224, 28);
            cboQuality.TabIndex = 2;
            // 
            // lblQualityHint
            // 
            lblQualityHint.AutoSize = true;
            lblQualityHint.ForeColor = Color.Gray;
            lblQualityHint.Location = new Point(23, 141);
            lblQualityHint.Name = "lblQualityHint";
            lblQualityHint.Size = new Size(363, 20);
            lblQualityHint.TabIndex = 3;
            lblQualityHint.Text = "Thấp = nhanh hơn, ít chi tiết. Cao = chậm hơn, rõ hơn.";
            // 
            // lblFps
            // 
            lblFps.AutoSize = true;
            lblFps.Location = new Point(23, 181);
            lblFps.Name = "lblFps";
            lblFps.Size = new Size(96, 20);
            lblFps.TabIndex = 4;
            lblFps.Text = "FPS mục tiêu:";
            // 
            // trackFps
            // 
            trackFps.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackFps.Location = new Point(23, 205);
            trackFps.Margin = new Padding(3, 4, 3, 4);
            trackFps.Maximum = 30;
            trackFps.Minimum = 5;
            trackFps.Name = "trackFps";
            trackFps.Size = new Size(313, 56);
            trackFps.TabIndex = 5;
            trackFps.TickFrequency = 5;
            trackFps.Value = 20;
            trackFps.Scroll += TrackFps_Scroll;
            // 
            // lblFpsValue
            // 
            lblFpsValue.Anchor = AnchorStyles.Right;
            lblFpsValue.AutoSize = true;
            lblFpsValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFpsValue.ForeColor = Color.FromArgb(0, 122, 204);
            lblFpsValue.Location = new Point(347, 216);
            lblFpsValue.Name = "lblFpsValue";
            lblFpsValue.Size = new Size(64, 23);
            lblFpsValue.TabIndex = 6;
            lblFpsValue.Text = "20 FPS";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(23, 280);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(103, 20);
            lblPort.TabIndex = 7;
            lblPort.Text = "Port mặc định:";
            // 
            // txtPort
            // 
            txtPort.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPort.Location = new Point(23, 304);
            txtPort.Margin = new Padding(3, 4, 3, 4);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(131, 27);
            txtPort.TabIndex = 8;
            txtPort.Text = "9000";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(208, 360);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(98, 43);
            btnSave.TabIndex = 9;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(318, 360);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(87, 43);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.Click += BtnCancel_Click;
            // 
            // SettingsForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(426, 427);
            Controls.Add(lblTitle);
            Controls.Add(lblQuality);
            Controls.Add(cboQuality);
            Controls.Add(lblQualityHint);
            Controls.Add(lblFps);
            Controls.Add(trackFps);
            Controls.Add(lblFpsValue);
            Controls.Add(lblPort);
            Controls.Add(txtPort);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cài đặt";
            ((System.ComponentModel.ISupportInitialize)trackFps).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblQuality;
        private System.Windows.Forms.ComboBox cboQuality;
        private System.Windows.Forms.Label    lblQualityHint;
        private System.Windows.Forms.Label    lblFps;
        private System.Windows.Forms.TrackBar trackFps;
        private System.Windows.Forms.Label    lblFpsValue;
        private System.Windows.Forms.Label    lblPort;
        private System.Windows.Forms.TextBox  txtPort;
        private System.Windows.Forms.Button   btnSave;
        private System.Windows.Forms.Button   btnCancel;
    }
}
