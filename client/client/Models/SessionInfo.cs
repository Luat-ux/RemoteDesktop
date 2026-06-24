namespace RemoteDesktop.Models
{
    /// <summary>
    /// Thông tin phiên kết nối đang hoạt động.
    /// </summary>
    public class SessionInfo
    {
        public string  ServerIp          { get; set; } = string.Empty;
        public int     ServerPort        { get; set; }
        public bool    IsAuthenticated   { get; set; }
        public int     RemoteScreenWidth { get; set; }
        public int     RemoteScreenHeight{ get; set; }
        public DateTime ConnectedAt      { get; set; } = DateTime.Now;
    }
}
