namespace RemoteDesktop.Models
{
    /// <summary>
    /// Lưu thông tin cấu hình kết nối do người dùng nhập.
    /// </summary>
    public class ConnectionSettings
    {
        public string ServerIp       { get; set; } = "127.0.0.1";
        public int    ServerPort     { get; set; } = 9000;
        public string PasswordHash   { get; set; } = string.Empty;
        public int    JpegQuality    { get; set; } = 65;
        public int    FrameIntervalMs{ get; set; } = 50;
    }
}
