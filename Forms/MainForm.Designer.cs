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
            this.pictureBoxScreen    = new System.Windows.Forms.PictureBox();
            this.panelToolbar        = new System.Windows.Forms.Panel();
            this.btnConnect          = new System.Windows.Forms.Button();
            this.btnDisconnect       = new System.Windows.Forms.Button();
            this.btnSendFile         = new System.Windows.Forms.Button();
            this.btnSettings         = new System.Windows.Forms.Button();
            this.statusStrip         = new System.Windows.Forms.StatusStrip();
            this.lblStatusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusPing       = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusFps        = new System.Windows.Forms.ToolStripStatusLabel();
            this.separatorStatus     = new System.Windows.Forms.ToolStripSeparator();
            this.separatorStatus2    = new System.Windows.Forms.ToolStripSeparator();

            // ── pictureBoxScreen ────────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            this.pictureBoxScreen.Anchor    = System.Windows.Forms.AnchorStyles.Top
                                            | System.Windows.Forms.AnchorStyles.Bottom
                                            | System.Windows.Forms.AnchorStyles.Left
                                            | System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxScreen.BackColor = System.Drawing.Color.Black;
            this.pictureBoxScreen.Location  = new System.Drawing.Point(0, 50);
            this.pictureBoxScreen.Name      = "pictureBoxScreen";
            this.pictureBoxScreen.Size      = new System.Drawing.Size(1200, 650);
            this.pictureBoxScreen.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxScreen.TabIndex  = 0;
            this.pictureBoxScreen.TabStop   = false;
            this.pictureBoxScreen.Cursor    = System.Windows.Forms.Cursors.Cross;
            // Events wire-up ở file logic
            this.pictureBoxScreen.MouseMove  += new System.Windows.Forms.MouseEventHandler(this.PictureBoxScreen_MouseMove);
            this.pictureBoxScreen.MouseDown  += new System.Windows.Forms.MouseEventHandler(this.PictureBoxScreen_MouseDown);
            this.pictureBoxScreen.MouseUp    += new System.Windows.Forms.MouseEventHandler(this.PictureBoxScreen_MouseUp);
            this.pictureBoxScreen.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PictureBoxScreen_MouseWheel);

            // ── panelToolbar ────────────────────────────────────────────────
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelToolbar.Controls.Add(this.btnConnect);
            this.panelToolbar.Controls.Add(this.btnDisconnect);
            this.panelToolbar.Controls.Add(this.btnSendFile);
            this.panelToolbar.Controls.Add(this.btnSettings);
            this.panelToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location  = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name      = "panelToolbar";
            this.panelToolbar.Size      = new System.Drawing.Size(1200, 50);
            this.panelToolbar.TabIndex  = 1;

            // ── btnConnect ──────────────────────────────────────────────────
            this.btnConnect.BackColor   = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnConnect.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor   = System.Drawing.Color.White;
            this.btnConnect.Location    = new System.Drawing.Point(12, 10);
            this.btnConnect.Name        = "btnConnect";
            this.btnConnect.Size        = new System.Drawing.Size(110, 30);
            this.btnConnect.TabIndex    = 0;
            this.btnConnect.Text        = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click      += new System.EventHandler(this.BtnConnect_Click);

            // ── btnDisconnect ───────────────────────────────────────────────
            this.btnDisconnect.BackColor  = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnDisconnect.Enabled    = false;
            this.btnDisconnect.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.ForeColor  = System.Drawing.Color.White;
            this.btnDisconnect.Location   = new System.Drawing.Point(134, 10);
            this.btnDisconnect.Name       = "btnDisconnect";
            this.btnDisconnect.Size       = new System.Drawing.Size(110, 30);
            this.btnDisconnect.TabIndex   = 1;
            this.btnDisconnect.Text       = "Ngắt kết nối";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click     += new System.EventHandler(this.BtnDisconnect_Click);

            // ── btnSendFile ─────────────────────────────────────────────────
            this.btnSendFile.BackColor   = System.Drawing.Color.FromArgb(16, 124, 16);
            this.btnSendFile.Enabled     = false;
            this.btnSendFile.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.ForeColor   = System.Drawing.Color.White;
            this.btnSendFile.Location    = new System.Drawing.Point(256, 10);
            this.btnSendFile.Name        = "btnSendFile";
            this.btnSendFile.Size        = new System.Drawing.Size(110, 30);
            this.btnSendFile.TabIndex    = 2;
            this.btnSendFile.Text        = "Gửi file";
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click      += new System.EventHandler(this.BtnSendFile_Click);

            // ── btnSettings ─────────────────────────────────────────────────
            this.btnSettings.BackColor   = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnSettings.FlatStyle   = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor   = System.Drawing.Color.White;
            this.btnSettings.Location    = new System.Drawing.Point(378, 10);
            this.btnSettings.Name        = "btnSettings";
            this.btnSettings.Size        = new System.Drawing.Size(90, 30);
            this.btnSettings.TabIndex    = 3;
            this.btnSettings.Text        = "Cài đặt";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click      += new System.EventHandler(this.BtnSettings_Click);

            // ── statusStrip ─────────────────────────────────────────────────
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblStatusConnection,
                this.separatorStatus,
                this.lblStatusPing,
                this.separatorStatus2,
                this.lblStatusFps
            });
            this.statusStrip.Location   = new System.Drawing.Point(0, 728);
            this.statusStrip.Name       = "statusStrip";
            this.statusStrip.Size       = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex   = 2;

            this.lblStatusConnection.Name = "lblStatusConnection";
            this.lblStatusConnection.Text = "Chưa kết nối";
            this.lblStatusConnection.ForeColor = System.Drawing.Color.Gray;

            this.separatorStatus.Name   = "separatorStatus";

            this.lblStatusPing.Name     = "lblStatusPing";
            this.lblStatusPing.Text     = "Ping: --";

            this.separatorStatus2.Name  = "separatorStatus2";

            this.lblStatusFps.Name      = "lblStatusFps";
            this.lblStatusFps.Text      = "FPS: --";

            // ── MainForm ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ClientSize          = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pictureBoxScreen);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.statusStrip);
            this.KeyPreview          = true;
            this.MinimumSize         = new System.Drawing.Size(800, 500);
            this.Name                = "MainForm";
            this.Text                = "Remote Desktop Client";
            this.WindowState         = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown            += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp              += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
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
