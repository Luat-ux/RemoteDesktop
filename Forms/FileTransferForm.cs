using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktop.Forms
{
    /// <summary>
    /// Form gửi file tới server với thanh tiến trình (Demo chính số 3).
    /// Gửi theo chunk 64KB, cập nhật ProgressBar sau mỗi chunk.
    /// </summary>
    public partial class FileTransferForm : Form
    {
        private const int CHUNK_SIZE       = 64 * 1024; // 64 KB
        private const int PACKET_TYPE_FILE_HEADER = 5;
        private const int PACKET_TYPE_FILE_CHUNK  = 6;
        private const int PACKET_TYPE_FILE_END    = 7;
        private const int PACKET_TYPE_FILE_CANCEL = 8;

        private readonly NetworkStream      _serverStream;
        private          CancellationTokenSource? _cancelSource;
        private          bool               _isSending;
        private          string             _selectedFilePath = string.Empty;

        public FileTransferForm(NetworkStream serverStream)
        {
            InitializeComponent();
            _serverStream = serverStream;
        }

        // ── Chọn file ────────────────────────────────────────────────────
        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title  = "Chọn file cần gửi",
                Filter = "Tất cả file (*.*)|*.*"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            _selectedFilePath  = dialog.FileName;
            txtFilePath.Text   = _selectedFilePath;
            btnSend.Enabled    = true;
            lblStatus.Text     = $"Đã chọn: {Path.GetFileName(_selectedFilePath)}";
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            ResetProgress();
        }

        // ── Gửi file ─────────────────────────────────────────────────────
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedFilePath)) return;

            _cancelSource = new CancellationTokenSource();
            SetSendingState(isSending: true);

            try
            {
                await SendFileAsync(_selectedFilePath, _cancelSource.Token);
                SetStatus("Gửi file hoàn thành!", System.Drawing.Color.LimeGreen);
            }
            catch (OperationCanceledException)
            {
                await SendCancelPacketAsync();
                SetStatus("Đã hủy gửi file.", System.Drawing.Color.Orange);
                ResetProgress();
            }
            catch (Exception ex)
            {
                SetStatus($"Lỗi: {ex.Message}", System.Drawing.Color.Tomato);
            }
            finally
            {
                SetSendingState(isSending: false);
            }
        }

        // ── Hủy / Đóng ───────────────────────────────────────────────────
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_isSending)
                _cancelSource?.Cancel();
            else
                Close();
        }

        private void FileTransferForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isSending)
            {
                e.Cancel = true; // chặn đóng khi đang gửi
                _cancelSource?.Cancel();
            }
        }

        // ── Logic gửi file theo chunk ─────────────────────────────────────
        private async Task SendFileAsync(string filePath, CancellationToken cancelToken)
        {
            var fileInfo   = new FileInfo(filePath);
            long fileSize  = fileInfo.Length;
            string fileName = fileInfo.Name;

            // 1. Gửi FILE_HEADER: [FileName UTF8 bytes (256 max)][FileSize 8 bytes]
            await SendFileHeaderAsync(fileName, fileSize);

            // 2. Gửi từng chunk 64KB
            long bytesSent = 0;
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] chunkBuffer   = new byte[CHUNK_SIZE];

            while (bytesSent < fileSize)
            {
                cancelToken.ThrowIfCancellationRequested();

                int bytesRead = await fileStream.ReadAsync(
                    chunkBuffer.AsMemory(0, CHUNK_SIZE), cancelToken);

                if (bytesRead == 0) break;

                await SendFileChunkAsync(chunkBuffer, bytesRead);

                bytesSent += bytesRead;
                UpdateProgress(bytesSent, fileSize);
            }

            // 3. Gửi FILE_END
            await SendPacketAsync(PACKET_TYPE_FILE_END, []);
        }

        // ── Gửi FILE_HEADER packet ────────────────────────────────────────
        private async Task SendFileHeaderAsync(string fileName, long fileSize)
        {
            byte[] nameBytes     = Encoding.UTF8.GetBytes(fileName.PadRight(256)[..256]);
            byte[] sizeBytes     = BitConverter.GetBytes(fileSize);
            byte[] payload       = [.. nameBytes, .. sizeBytes];
            await SendPacketAsync(PACKET_TYPE_FILE_HEADER, payload);
        }

        // ── Gửi FILE_CHUNK packet ─────────────────────────────────────────
        private async Task SendFileChunkAsync(byte[] chunkData, int length)
        {
            byte[] payload = chunkData[..length];
            await SendPacketAsync(PACKET_TYPE_FILE_CHUNK, payload);
        }

        // ── Gửi FILE_CANCEL packet ────────────────────────────────────────
        private async Task SendCancelPacketAsync()
        {
            await SendPacketAsync(PACKET_TYPE_FILE_CANCEL, []);
        }

        // ── Gửi packet theo format: [Type 4B][Length 4B][Payload] ─────────
        private async Task SendPacketAsync(int packetType, byte[] payload)
        {
            byte[] header = new byte[8];
            BitConverter.GetBytes(packetType).CopyTo(header, 0);
            BitConverter.GetBytes(payload.Length).CopyTo(header, 4);

            await _serverStream.WriteAsync(header);
            if (payload.Length > 0)
                await _serverStream.WriteAsync(payload);
        }

        // ── Cập nhật UI ──────────────────────────────────────────────────
        private void UpdateProgress(long bytesSent, long totalBytes)
        {
            if (InvokeRequired) { Invoke(() => UpdateProgress(bytesSent, totalBytes)); return; }

            int percent = (int)((double)bytesSent / totalBytes * 100);
            progressBar.Value      = Math.Min(percent, 100);
            lblProgressText.Text   = $"{bytesSent / 1024:N0} KB / {totalBytes / 1024:N0} KB  ({percent}%)";
        }

        private void ResetProgress()
        {
            progressBar.Value    = 0;
            lblProgressText.Text = "0 KB / 0 KB";
        }

        private void SetStatus(string message, System.Drawing.Color color)
        {
            if (InvokeRequired) { Invoke(() => SetStatus(message, color)); return; }
            lblStatus.Text      = message;
            lblStatus.ForeColor = color;
        }

        private void SetSendingState(bool isSending)
        {
            if (InvokeRequired) { Invoke(() => SetSendingState(isSending)); return; }
            _isSending             = isSending;
            btnSend.Enabled        = !isSending;
            btnChooseFile.Enabled  = !isSending;
            btnCancel.Text         = isSending ? "Hủy gửi" : "Đóng";
        }
    }
}
