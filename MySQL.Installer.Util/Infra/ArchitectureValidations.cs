using System;
using System.Linq;
using System.Management;

namespace MySQL.Installer.Util.Infra
{
    public class ArchitectureValidations
    {
        public static bool IsValidWindows10() => new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem")
                .Get().Cast<ManagementBaseObject>()
                .Select(p => p.Properties).First()["Caption"].Value.ToString().Contains("Windows 10");

        public static bool IsValid64Process() => Environment.Is64BitOperatingSystem;
    }
}
