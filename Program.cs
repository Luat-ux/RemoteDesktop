using RemoteDesktop.Forms;

namespace RemoteDesktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            if (args.Length > 0 && args[0] == "server")
                Application.Run(new ServerForm());
            else
                Application.Run(new MainForm());
        }
    }
}