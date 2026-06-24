
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
            lblTitle = new Label();
            lblIp = new Label();
            txtIp = new TextBox();
            lblPort = new Label();
            txtPort = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnConnect = new Button();
            btnCancel = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(45, 45, 48);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(473, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "  Kết nối tới Server";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIp
            // 
            lblIp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblIp.AutoSize = true;
            lblIp.Location = new Point(26, 76);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(74, 20);
            lblIp.TabIndex = 1;
            lblIp.Text = "Địa chỉ IP:";
            // 
            // txtIp
            // 
            txtIp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtIp.Location = new Point(27, 101);
            txtIp.Margin = new Padding(3, 4, 3, 4);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(308, 27);
            txtIp.TabIndex = 2;
            txtIp.Text = "192.168.1.";
            // 
            // lblPort
            // 
            lblPort.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblPort.AutoSize = true;
            lblPort.Location = new Point(372, 75);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(38, 20);
            lblPort.TabIndex = 3;
            lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtPort.Location = new Point(373, 99);
            txtPort.Margin = new Padding(3, 4, 3, 4);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(79, 27);
            txtPort.TabIndex = 4;
            txtPort.Text = "9000";
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(26, 151);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Mật khẩu:";
            lblPassword.Click += lblPassword_Click;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(27, 176);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(427, 27);
            txtPassword.TabIndex = 6;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConnect.BackColor = Color.FromArgb(0, 122, 204);
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(240, 246);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(103, 43);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "Kết nối";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(353, 246);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 43);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Hủy";
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Tomato;
            lblError.Location = new Point(27, 243);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 7;
            lblError.Visible = false;
            // 
            // ConnectionForm
            // 
            AcceptButton = btnConnect;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(473, 313);
            Controls.Add(txtIp);
            Controls.Add(lblTitle);
            Controls.Add(lblIp);
            Controls.Add(lblPort);
            Controls.Add(txtPort);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblError);
            Controls.Add(btnConnect);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConnectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kết nối Remote Desktop";
            ResumeLayout(false);
            PerformLayout();
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
