namespace RemoteDesktop.Services
{
    /// <summary>
    /// Dùng chung với phía Client — phải giữ nguyên các hằng số này.
    /// Format: [PacketType: 4 bytes][PayloadLength: 4 bytes][Payload: N bytes]
    /// </summary>
    public static class Protocol
    {
        public const int HEADER_SIZE    = 8;

        // Loại gói tin — phải khớp với Protocol.cs bên Client
        public const int AUTH_REQUEST   = 1;
        public const int AUTH_RESPONSE  = 2;
        public const int REQUEST_FRAME  = 3;
        public const int FRAME_DATA     = 4;
        public const int INPUT_MOUSE    = 5;
        public const int INPUT_KEY      = 6;
        public const int FILE_HEADER    = 7;
        public const int FILE_CHUNK     = 8;
        public const int FILE_END       = 9;
        public const int FILE_CANCEL    = 10;
        public const int DISCONNECT     = 11;

        // Kết quả AUTH
        public const byte AUTH_SUCCESS  = 1;
        public const byte AUTH_FAILED   = 0;

        public const int DEFAULT_PORT   = 9000;
        public const int FILE_CHUNK_SIZE = 64 * 1024; // 64 KB mỗi chunk
        public static byte[] BuildHeader(int packetType, int payloadLength)
        {
            byte[] header = new byte[HEADER_SIZE];
            BitConverter.GetBytes(packetType).CopyTo(header, 0);
            BitConverter.GetBytes(payloadLength).CopyTo(header, 4);
            return header;
        }

        public static (int packetType, int payloadLength) ParseHeader(byte[] header)
        {
            return (BitConverter.ToInt32(header, 0), BitConverter.ToInt32(header, 4));
        }
    }
}
