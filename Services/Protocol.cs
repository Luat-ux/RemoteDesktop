namespace RemoteDesktop.Services
{
    /// <summary>
    /// Định nghĩa toàn bộ hằng số giao thức TCP dùng chung Client và Server.
    ///
    /// Format mỗi gói tin:
    ///   [PacketType : 4 bytes] [PayloadLength : 4 bytes] [Payload : N bytes]
    /// </summary>
    public static class Protocol
    {
        // ── Kích thước header cố định ──────────────────────────────────────
        public const int HEADER_SIZE = 8;

        // ── Loại gói tin (PacketType) ─────────────────────────────────────
        public const int AUTH_REQUEST   = 1;  // Client → Server: gửi hash mật khẩu
        public const int AUTH_RESPONSE  = 2;  // Server → Client: kết quả xác thực
        public const int REQUEST_FRAME  = 3;  // Client → Server: yêu cầu frame mới
        public const int FRAME_DATA     = 4;  // Server → Client: dữ liệu JPEG frame
        public const int INPUT_MOUSE    = 5;  // Client → Server: sự kiện chuột
        public const int INPUT_KEY      = 6;  // Client → Server: sự kiện bàn phím
        public const int FILE_HEADER    = 7;  // Client → Server: thông tin file (tên + kích thước)
        public const int FILE_CHUNK     = 8;  // Client → Server: một đoạn dữ liệu file
        public const int FILE_END       = 9;  // Client → Server: báo gửi file xong
        public const int FILE_CANCEL    = 10; // Client → Server: hủy gửi file giữa chừng
        public const int DISCONNECT     = 11; // Client → Server: ngắt kết nối sạch

        // ── Kết quả xác thực (AUTH_RESPONSE payload[0]) ───────────────────
        public const byte AUTH_SUCCESS  = 1;
        public const byte AUTH_FAILED   = 0;

        // ── Cấu hình mặc định ─────────────────────────────────────────────
        public const int DEFAULT_PORT   = 9000;
        public const int FILE_CHUNK_SIZE = 64 * 1024; // 64 KB mỗi chunk

        // ── Helper: tạo header 8 bytes ────────────────────────────────────
        public static byte[] BuildHeader(int packetType, int payloadLength)
        {
            byte[] header = new byte[HEADER_SIZE];
            BitConverter.GetBytes(packetType).CopyTo(header, 0);
            BitConverter.GetBytes(payloadLength).CopyTo(header, 4);
            return header;
        }

        // ── Helper: đọc type và length từ header ──────────────────────────
        public static (int packetType, int payloadLength) ParseHeader(byte[] header)
        {
            int packetType    = BitConverter.ToInt32(header, 0);
            int payloadLength = BitConverter.ToInt32(header, 4);
            return (packetType, payloadLength);
        }
    }
}
