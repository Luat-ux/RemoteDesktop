namespace RemoteDesktop.Forms
{
    partial class ConnectionForm
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
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblIp          = new System.Windows.Forms.Label();
            this.txtIp          = new System.Windows.Forms.TextBox();
            this.lblPort        = new System.Windows.Forms.Label();
            this.txtPort        = new System.Windows.Forms.TextBox();
            this.lblPassword    = new System.Windows.Forms.Label();
            this.txtPassword    = new System.Windows.Forms.TextBox();
            this.btnConnect     = new System.Windows.Forms.Button();
            this.btnCancel      = new System.Windows.Forms.Button();
            this.lblError       = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(380, 48);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "  Kết nối tới Server";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblIp
            this.lblIp.AutoSize  = true;
            this.lblIp.Location  = new System.Drawing.Point(24, 72);
            this.lblIp.Name      = "lblIp";
            this.lblIp.Size      = new System.Drawing.Size(80, 15);
            this.lblIp.TabIndex  = 1;
            this.lblIp.Text      = "Địa chỉ IP:";

            // txtIp
            this.txtIp.Location  = new System.Drawing.Point(24, 90);
            this.txtIp.Name      = "txtIp";
            this.txtIp.Size      = new System.Drawing.Size(230, 23);
            this.txtIp.TabIndex  = 2;
            this.txtIp.Text      = "192.168.1.";

            // lblPort
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(268, 72);
            this.lblPort.Name     = "lblPort";
            this.lblPort.Size     = new System.Drawing.Size(30, 15);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text     = "Port:";

            // txtPort
            this.txtPort.Location  = new System.Drawing.Point(268, 90);
            this.txtPort.Name      = "txtPort";
            this.txtPort.Size      = new System.Drawing.Size(88, 23);
            this.txtPort.TabIndex  = 4;
            this.txtPort.Text      = "9000";

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(24, 128);
            this.lblPassword.Name     = "lblPassword";
            this.lblPassword.Size     = new System.Drawing.Size(70, 15);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text     = "Mật khẩu:";

            // txtPassword
            this.txtPassword.Location     = new System.Drawing.Point(24, 146);
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size         = new System.Drawing.Size(332, 23);
            this.txtPassword.TabIndex     = 6;

            // lblError
            this.lblError.AutoSize  = true;
            this.lblError.ForeColor = System.Drawing.Color.Tomato;
            this.lblError.Location  = new System.Drawing.Point(24, 182);
            this.lblError.Name      = "lblError";
            this.lblError.Size      = new System.Drawing.Size(0, 15);
            this.lblError.TabIndex  = 7;
            this.lblError.Text      = "";
            this.lblError.Visible   = false;

            // btnConnect
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location  = new System.Drawing.Point(170, 210);
            this.btnConnect.Name      = "btnConnect";
            this.btnConnect.Size      = new System.Drawing.Size(90, 32);
            this.btnConnect.TabIndex  = 8;
            this.btnConnect.Text      = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click    += new System.EventHandler(this.BtnConnect_Click);

            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location     = new System.Drawing.Point(270, 210);
            this.btnCancel.Name         = "btnCancel";
            this.btnCancel.Size         = new System.Drawing.Size(86, 32);
            this.btnCancel.TabIndex     = 9;
            this.btnCancel.Text         = "Hủy";
            this.btnCancel.Click       += new System.EventHandler(this.BtnCancel_Click);

            // ConnectionForm
            this.AcceptButton        = this.btnConnect;
            this.CancelButton        = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(380, 260);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "ConnectionForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Kết nối Remote Desktop";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblIp;
        private System.Windows.Forms.TextBox  txtIp;
        private System.Windows.Forms.Label    lblPort;
        private System.Windows.Forms.TextBox  txtPort;
        private System.Windows.Forms.Label    lblPassword;
        private System.Windows.Forms.TextBox  txtPassword;
        private System.Windows.Forms.Label    lblError;
        private System.Windows.Forms.Button   btnConnect;
        private System.Windows.Forms.Button   btnCancel;
    }
}
