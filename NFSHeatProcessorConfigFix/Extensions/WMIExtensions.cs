using System.Management;

namespace NFSHeatProcessorConfigFix.Extensions;

internal static class WMIExtension
{
    internal static string GetAsString(this ManagementBaseObject managementBaseObject, string name)
    {
        return managementBaseObject[name].ToString();
    }
}
