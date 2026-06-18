using System;
using System.IO;

namespace RemoteDesktop.Services
{
    /// <summary>
    /// Ghi log ra console và file log.txt — dùng chung toàn bộ project.
    /// </summary>
    public static class Logger
    {
        private static readonly string LOG_FILE_PATH = "remote_desktop.log";
        private static readonly object _lock         = new();

        public static void Info(string message)    => WriteLog("INFO ", message);
        public static void Warning(string message) => WriteLog("WARN ", message);
        public static void Error(string message)   => WriteLog("ERROR", message);

        public static void Error(string message, Exception ex)
            => WriteLog("ERROR", $"{message} | {ex.GetType().Name}: {ex.Message}");

        private static void WriteLog(string level, string message)
        {
            string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";

            lock (_lock)
            {
                Console.WriteLine(logLine);
                try { File.AppendAllText(LOG_FILE_PATH, logLine + Environment.NewLine); }
                catch { /* không throw nếu không ghi được file */ }
            }
        }
    }
}
