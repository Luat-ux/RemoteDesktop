namespace RemoteDesktop.Forms
{
    partial class FileTransferForm
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
            lblFilePath = new Label();
            txtFilePath = new TextBox();
            btnChooseFile = new Button();
            lblProgress = new Label();
            progressBar = new ProgressBar();
            lblProgressText = new Label();
            lblStatus = new Label();
            btnSend = new Button();
            btnCancel = new Button();
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
            lblTitle.Size = new Size(547, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "  Gửi file tới Server";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(23, 83);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(124, 20);
            lblFilePath.TabIndex = 1;
            lblFilePath.Text = "Chọn file cần gửi:";
            // 
            // txtFilePath
            // 
            txtFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFilePath.Location = new Point(28, 105);
            txtFilePath.Margin = new Padding(3, 4, 3, 4);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(388, 27);
            txtFilePath.TabIndex = 2;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChooseFile.FlatStyle = FlatStyle.Flat;
            btnChooseFile.Location = new Point(436, 101);
            btnChooseFile.Margin = new Padding(3, 4, 3, 4);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(90, 32);
            btnChooseFile.TabIndex = 3;
            btnChooseFile.Text = "Duyệt...";
            btnChooseFile.Click += BtnChooseFile_Click;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(23, 163);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(74, 20);
            lblProgress.TabIndex = 4;
            lblProgress.Text = "Tiến trình:";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(28, 187);
            progressBar.Margin = new Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(496, 29);
            progressBar.TabIndex = 5;
            // 
            // lblProgressText
            // 
            lblProgressText.AutoSize = true;
            lblProgressText.ForeColor = Color.Gray;
            lblProgressText.Location = new Point(23, 224);
            lblProgressText.Name = "lblProgressText";
            lblProgressText.Size = new Size(83, 20);
            lblProgressText.TabIndex = 6;
            lblProgressText.Text = "0 KB / 0 KB";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(23, 253);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(107, 20);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Chưa chọn file.";
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(16, 124, 16);
            btnSend.Enabled = false;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(320, 288);
            btnSend.Margin = new Padding(3, 4, 3, 4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(96, 43);
            btnSend.TabIndex = 8;
            btnSend.Text = "Gửi file";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += BtnSend_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(426, 288);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 43);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Đóng";
            btnCancel.Click += BtnCancel_Click;
            // 
            // FileTransferForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 355);
            Controls.Add(lblTitle);
            Controls.Add(lblFilePath);
            Controls.Add(txtFilePath);
            Controls.Add(btnChooseFile);
            Controls.Add(lblProgress);
            Controls.Add(progressBar);
            Controls.Add(lblProgressText);
            Controls.Add(lblStatus);
            Controls.Add(btnSend);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FileTransferForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gửi file";
            FormClosing += FileTransferForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label       lblTitle;
        private System.Windows.Forms.Label       lblFilePath;
        private System.Windows.Forms.TextBox     txtFilePath;
        private System.Windows.Forms.Button      btnChooseFile;
        private System.Windows.Forms.Label       lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label       lblProgressText;
        private System.Windows.Forms.Label       lblStatus;
        private System.Windows.Forms.Button      btnSend;
        private System.Windows.Forms.Button      btnCancel;
    }
}
