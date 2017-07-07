using MySQL.Installer.Util.Configuration;

namespace MySQL.Installer.Util.Tasks
{
    public class MySQLInstallerTask
    {
        private string _path;
        private string _fileName;

        public MySQLInstallerTask(string path, string fileName)
        {
            _path = path;
            _fileName = fileName;
        }

        public void Install() => CommandLine.Run($"{ Actions.Cd(_path) } && { Actions.MsiExec(_fileName) }");
    }
}
