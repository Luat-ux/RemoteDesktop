using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace RemoteDesktop.Services
{
    public class ServerConfig
    {
        public string PasswordHash { get; set; } = string.Empty;
        public int    Port         { get; set; } = 9000;
        public int    JpegQuality  { get; set; } = 65;
    }

    public static class ConfigManager
    {
        private const string CONFIG_FILE = "server_config.json";

        public static ServerConfig LoadConfig()
        {
            try
            {
                if (!File.Exists(CONFIG_FILE))
                {
                    // Tạo config mặc định: mật khẩu "123456"
                    var defaultConfig = new ServerConfig
                    {
                        PasswordHash = HashPassword("123456"),
                        Port         = 9000,
                        JpegQuality  = 65
                    };
                    SaveConfig(defaultConfig);
                    Logger.Info("Tạo config mặc định — mật khẩu: 123456");
                    return defaultConfig;
                }

                string json = File.ReadAllText(CONFIG_FILE);
                return JsonSerializer.Deserialize<ServerConfig>(json) ?? new ServerConfig();
            }
            catch (Exception ex)
            {
                Logger.Error("Không đọc được config.", ex);
                return new ServerConfig();
            }
        }

        public static void SaveConfig(ServerConfig config)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(CONFIG_FILE, JsonSerializer.Serialize(config, options));
        }

        /// <summary>Đổi mật khẩu — hash SHA-256 rồi lưu vào config.</summary>
        public static void ChangePassword(string newPassword)
        {
            var config = LoadConfig();
            config.PasswordHash = HashPassword(newPassword);
            SaveConfig(config);
            Logger.Info("Đã đổi mật khẩu thành công.");
        }

        /// <summary>Hash mật khẩu SHA-256 — giống hệt phía Client.</summary>
        public static string HashPassword(string password)
            => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
    }
}
