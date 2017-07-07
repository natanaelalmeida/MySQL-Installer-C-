using MySQL.Installer.Util.Configuration;
using MySQL.Installer.Util.Tasks;
using System;
using System.IO;
using System.Threading;
using static MySQL.Installer.Util.Tasks.VerifyInstallationFinish;

namespace MySQL.Installer.Util.Install
{
    public class MySQLInstaller : InstallAbstract, IDisposable
    {
        private readonly string _path;
        private readonly string _fileName;        

        private Thread _mysqlInstallerTask;

        public MySQLInstaller(string fileName, InstallStatus installStatus = null) : base(fileName, installStatus)
        {                 
            _path = $@"{ Directory.GetCurrentDirectory() }\mysql";
            _fileName = fileName;
        }

        public override void Init()
        {
            //CommandLine.Run($"{ Actions.Cd(_path) } && { Actions.MsiExec(_fileName) }");                

            WriteStatus("Iniciando instalação do MySQL Installer - Community...");
            _mysqlInstallerTask = new Thread(new MySQLInstallerTask(_path, _fileName).Install);
            _mysqlInstallerTask.Start();
        }         

        public bool IsSuccessInstallation()
        {
            bool status = false;

            VerifyInstallationFinish verifyInstallation = new VerifyInstallationFinish();
            IsInstalled installed = new IsInstalled(verifyInstallation.Run);

            IAsyncResult result = installed.BeginInvoke(out status, null, null);

            installed.EndInvoke(out status, result);
            result.AsyncWaitHandle.Close();

            return status;
        }

        public void Dispose() => _mysqlInstallerTask.Interrupt(); 
    }
}
