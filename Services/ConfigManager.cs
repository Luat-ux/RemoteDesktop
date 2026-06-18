using System;
using System.IO;
using System.Text.Json;
using RemoteDesktop.Models;

namespace RemoteDesktop.Services
{
    /// <summary>
    /// Đọc/ghi cấu hình ConnectionSettings từ file JSON.
    /// </summary>
    public static class ConfigManager
    {
        private static readonly string CONFIG_FILE = "settings.json";

        // ── Tải cấu hình từ file (dùng giá trị mặc định nếu chưa có file) ──
        public static ConnectionSettings LoadSettings()
        {
            try
            {
                if (!File.Exists(CONFIG_FILE))
                    return new ConnectionSettings();

                string json = File.ReadAllText(CONFIG_FILE);
                return JsonSerializer.Deserialize<ConnectionSettings>(json)
                       ?? new ConnectionSettings();
            }
            catch (Exception ex)
            {
                Logger.Error("Không đọc được settings.json, dùng mặc định.", ex);
                return new ConnectionSettings();
            }
        }

        // ── Lưu cấu hình ra file JSON ─────────────────────────────────────
        public static void SaveSettings(ConnectionSettings settings)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(CONFIG_FILE, JsonSerializer.Serialize(settings, options));
            }
            catch (Exception ex)
            {
                Logger.Error("Không ghi được settings.json.", ex);
            }
        }
    }
}
