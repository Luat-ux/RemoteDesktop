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
            this.lblTitle         = new System.Windows.Forms.Label();
            this.lblQuality       = new System.Windows.Forms.Label();
            this.cboQuality       = new System.Windows.Forms.ComboBox();
            this.lblQualityHint   = new System.Windows.Forms.Label();
            this.lblFps           = new System.Windows.Forms.Label();
            this.trackFps         = new System.Windows.Forms.TrackBar();
            this.lblFpsValue      = new System.Windows.Forms.Label();
            this.lblPort          = new System.Windows.Forms.Label();
            this.txtPort          = new System.Windows.Forms.TextBox();
            this.btnSave          = new System.Windows.Forms.Button();
            this.btnCancel        = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackFps)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(360, 44);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "  Cài đặt";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblQuality
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(20, 62);
            this.lblQuality.Name     = "lblQuality";
            this.lblQuality.TabIndex = 1;
            this.lblQuality.Text     = "Chất lượng ảnh (JPEG):";

            // cboQuality
            this.cboQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuality.Items.AddRange(new object[] { "Thấp (40%)", "Trung bình (65%)", "Cao (85%)" });
            this.cboQuality.Location      = new System.Drawing.Point(20, 80);
            this.cboQuality.Name          = "cboQuality";
            this.cboQuality.Size          = new System.Drawing.Size(200, 23);
            this.cboQuality.TabIndex      = 2;
            this.cboQuality.SelectedIndex = 1;

            // lblQualityHint
            this.lblQualityHint.AutoSize  = true;
            this.lblQualityHint.ForeColor = System.Drawing.Color.Gray;
            this.lblQualityHint.Location  = new System.Drawing.Point(20, 106);
            this.lblQualityHint.Name      = "lblQualityHint";
            this.lblQualityHint.TabIndex  = 3;
            this.lblQualityHint.Text      = "Thấp = nhanh hơn, ít chi tiết. Cao = chậm hơn, rõ hơn.";

            // lblFps
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(20, 136);
            this.lblFps.Name     = "lblFps";
            this.lblFps.TabIndex = 4;
            this.lblFps.Text     = "FPS mục tiêu:";

            // trackFps
            this.trackFps.Location    = new System.Drawing.Point(20, 154);
            this.trackFps.Maximum     = 30;
            this.trackFps.Minimum     = 5;
            this.trackFps.Name        = "trackFps";
            this.trackFps.Size        = new System.Drawing.Size(260, 45);
            this.trackFps.TabIndex    = 5;
            this.trackFps.TickFrequency = 5;
            this.trackFps.Value       = 20;
            this.trackFps.Scroll     += new System.EventHandler(this.TrackFps_Scroll);

            // lblFpsValue
            this.lblFpsValue.AutoSize  = true;
            this.lblFpsValue.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFpsValue.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.lblFpsValue.Location  = new System.Drawing.Point(290, 162);
            this.lblFpsValue.Name      = "lblFpsValue";
            this.lblFpsValue.TabIndex  = 6;
            this.lblFpsValue.Text      = "20 FPS";

            // lblPort
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(20, 210);
            this.lblPort.Name     = "lblPort";
            this.lblPort.TabIndex = 7;
            this.lblPort.Text     = "Port mặc định:";

            // txtPort
            this.txtPort.Location  = new System.Drawing.Point(20, 228);
            this.txtPort.Name      = "txtPort";
            this.txtPort.Size      = new System.Drawing.Size(100, 23);
            this.txtPort.TabIndex  = 8;
            this.txtPort.Text      = "9000";

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location  = new System.Drawing.Point(168, 270);
            this.btnSave.Name      = "btnSave";
            this.btnSave.Size      = new System.Drawing.Size(86, 32);
            this.btnSave.TabIndex  = 9;
            this.btnSave.Text      = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click    += new System.EventHandler(this.BtnSave_Click);

            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location     = new System.Drawing.Point(264, 270);
            this.btnCancel.Name         = "btnCancel";
            this.btnCancel.Size         = new System.Drawing.Size(76, 32);
            this.btnCancel.TabIndex     = 10;
            this.btnCancel.Text         = "Hủy";
            this.btnCancel.Click       += new System.EventHandler(this.BtnCancel_Click);

            // SettingsForm
            this.AcceptButton        = this.btnSave;
            this.CancelButton        = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(360, 320);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.cboQuality);
            this.Controls.Add(this.lblQualityHint);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.trackFps);
            this.Controls.Add(this.lblFpsValue);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "SettingsForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Cài đặt";
            ((System.ComponentModel.ISupportInitialize)(this.trackFps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
