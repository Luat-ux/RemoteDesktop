namespace RemoteDesktop.Services
{
    public static class Logger
    {
        private static readonly string LOG_PATH = "server.log";
        private static readonly object _lock    = new();
        public static event Action<string>? OnLog;

        public static void Info(string msg)    => Write("INFO ", msg);
        public static void Warning(string msg) => Write("WARN ", msg);
        public static void Error(string msg)   => Write("ERROR", msg);
        public static void Error(string msg, Exception ex)
            => Write("ERROR", $"{msg} | {ex.GetType().Name}: {ex.Message}");

        private static void Write(string level, string msg)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] [{level}] {msg}";
            lock (_lock)
            {
                Console.WriteLine(line);
                OnLog?.Invoke(line);
                try { File.AppendAllText(LOG_PATH, line + Environment.NewLine); } catch { }
            }
        }
    }
}
