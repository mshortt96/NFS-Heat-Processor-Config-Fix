using Microsoft.Win32;

namespace NFSHeatProcessorConfigFix;

internal class GameConfig
{
    internal string GetInstallationLocation()
    {
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\EA Games\\Need For Speed Heat\\");
        return registryKey?.GetValue("Install Dir")?.ToString();
    }
}
