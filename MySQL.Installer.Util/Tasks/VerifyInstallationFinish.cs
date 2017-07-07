using System.Threading;
using MySQL.Installer.Util.Infra;
using MySQL.Installer.Util.Configuration;

namespace MySQL.Installer.Util.Tasks
{
    internal class VerifyInstallationFinish 
    {         
        public void Run(out bool result)
        {
            result = false;            
            while (!result)            
                result = Validations.IsProgramInstalled("MySQL Installer - Community");                              
        }

        public delegate void IsInstalled(out bool result);
    }
}
