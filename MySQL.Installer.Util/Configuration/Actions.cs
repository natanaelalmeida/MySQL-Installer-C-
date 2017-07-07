namespace MySQL.Installer.Util.Configuration
{
    public class Actions
    {
        public static string MsiExec(string fileName) => $"msiexec /i { fileName } /q";
        public static string Cd(string path) => $"cd \"{ path }\"";
    }
}