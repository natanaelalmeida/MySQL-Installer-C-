using MySQL.Installer.Util.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Installer.Util.Install
{
    public abstract class InstallAbstract 
    {
        protected readonly InstallStatus _installStatus;

        public InstallAbstract(string fileName, InstallStatus installStatus)
        {
            if (!IsValidMSI(fileName))
                throw new IOException("Invalid extension. The selected file must be an .msi");

            _installStatus = installStatus;
        }

        public virtual void Init()
        {

        }

        protected bool IsValidMSI(string value) => Path.GetExtension(value).ToLower() == ".msi";

        protected void WriteStatus(string value)
        {
            if (_installStatus != null)
                _installStatus.Write(value);
        }
    }
}
