using System;

namespace MySQL.Installer.Util.Configuration
{
    public class InstallStatus
    {
        private readonly Action<string> _status;

        public InstallStatus(Action<string> status) =>  _status = status;

        public void Write(string value) => _status(value);
    }
}
