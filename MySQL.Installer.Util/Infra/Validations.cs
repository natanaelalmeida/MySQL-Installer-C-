using Microsoft.Win32;
using System.Linq;

namespace MySQL.Installer.Util.Infra
{
    public class Validations
    {
        public static bool IsProgramInstalled(string program)
        {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                bool exists = false;
                key.GetSubKeyNames().ToList().ForEach(s =>
                {                    
                    if ((key.OpenSubKey(s).GetValue("DisplayName") ?? new object()).ToString() == program)
                        exists = true;                    
                });

                return exists;
            }
        }
    }
}
