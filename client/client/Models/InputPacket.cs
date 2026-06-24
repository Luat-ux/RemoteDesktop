namespace RemoteDesktop.Models
{
    /// <summary>
    /// Gói tin chứa thao tác chuột hoặc bàn phím gửi từ Client lên Server.
    /// </summary>
    public class InputPacket
    {
        public InputType Type    { get; set; }
        public int       X       { get; set; }  // tọa độ X (chỉ dùng khi Type = Mouse)
        public int       Y       { get; set; }  // tọa độ Y (chỉ dùng khi Type = Mouse)
        public string    Button  { get; set; } = string.Empty; // LEFT / RIGHT / MIDDLE / WHEEL
        public int       Delta   { get; set; }  // scroll delta
        public int       KeyCode { get; set; }  // mã phím (chỉ dùng khi Type = Keyboard)
        public bool      IsKeyDown { get; set; }
    }

    public enum InputType
    {
        Mouse    = 1,
        Keyboard = 2
    }
}
