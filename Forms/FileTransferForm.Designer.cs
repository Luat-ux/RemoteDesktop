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
            this.lblTitle        = new System.Windows.Forms.Label();
            this.lblFilePath     = new System.Windows.Forms.Label();
            this.txtFilePath     = new System.Windows.Forms.TextBox();
            this.btnChooseFile   = new System.Windows.Forms.Button();
            this.lblProgress     = new System.Windows.Forms.Label();
            this.progressBar     = new System.Windows.Forms.ProgressBar();
            this.lblProgressText = new System.Windows.Forms.Label();
            this.lblStatus       = new System.Windows.Forms.Label();
            this.btnSend         = new System.Windows.Forms.Button();
            this.btnCancel       = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblTitle.Location  = new System.Drawing.Point(0, 0);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(460, 44);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "  Gửi file tới Server";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblFilePath
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(20, 62);
            this.lblFilePath.Name     = "lblFilePath";
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.Text     = "Chọn file cần gửi:";

            // txtFilePath
            this.txtFilePath.Location  = new System.Drawing.Point(20, 80);
            this.txtFilePath.Name      = "txtFilePath";
            this.txtFilePath.ReadOnly  = true;
            this.txtFilePath.Size      = new System.Drawing.Size(340, 23);
            this.txtFilePath.TabIndex  = 2;

            // btnChooseFile
            this.btnChooseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseFile.Location  = new System.Drawing.Point(370, 79);
            this.btnChooseFile.Name      = "btnChooseFile";
            this.btnChooseFile.Size      = new System.Drawing.Size(72, 25);
            this.btnChooseFile.TabIndex  = 3;
            this.btnChooseFile.Text      = "Duyệt...";
            this.btnChooseFile.Click    += new System.EventHandler(this.BtnChooseFile_Click);

            // lblProgress
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(20, 122);
            this.lblProgress.Name     = "lblProgress";
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text     = "Tiến trình:";

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(20, 140);
            this.progressBar.Name     = "progressBar";
            this.progressBar.Size     = new System.Drawing.Size(420, 22);
            this.progressBar.TabIndex = 5;

            // lblProgressText (hiển thị "X KB / Y KB")
            this.lblProgressText.AutoSize  = true;
            this.lblProgressText.ForeColor = System.Drawing.Color.Gray;
            this.lblProgressText.Location  = new System.Drawing.Point(20, 168);
            this.lblProgressText.Name      = "lblProgressText";
            this.lblProgressText.TabIndex  = 6;
            this.lblProgressText.Text      = "0 KB / 0 KB";

            // lblStatus
            this.lblStatus.AutoSize  = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location  = new System.Drawing.Point(20, 190);
            this.lblStatus.Name      = "lblStatus";
            this.lblStatus.TabIndex  = 7;
            this.lblStatus.Text      = "Chưa chọn file.";

            // btnSend
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(16, 124, 16);
            this.btnSend.Enabled   = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location  = new System.Drawing.Point(260, 220);
            this.btnSend.Name      = "btnSend";
            this.btnSend.Size      = new System.Drawing.Size(86, 32);
            this.btnSend.TabIndex  = 8;
            this.btnSend.Text      = "Gửi file";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click    += new System.EventHandler(this.BtnSend_Click);

            // btnCancel
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location  = new System.Drawing.Point(356, 220);
            this.btnCancel.Name      = "btnCancel";
            this.btnCancel.Size      = new System.Drawing.Size(84, 32);
            this.btnCancel.TabIndex  = 9;
            this.btnCancel.Text      = "Đóng";
            this.btnCancel.Click    += new System.EventHandler(this.BtnCancel_Click);

            // FileTransferForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(460, 270);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblProgressText);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "FileTransferForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Gửi file";
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.FileTransferForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
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
