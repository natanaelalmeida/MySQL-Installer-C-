using System.Collections.Generic;
using System.Diagnostics;

namespace MySQL.Installer.Util.Configuration
{
    public class CommandLine
    {                
        private readonly string _code;       

		public static void Run(string code)
        {
            new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    Arguments = $"/c { code }"
                }
            }.Start();                        
        }
    }
}
