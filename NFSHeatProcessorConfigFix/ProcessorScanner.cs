using NFSHeatProcessorConfigFix.Data;
using NFSHeatProcessorConfigFix.Extensions;
using System.Management;

namespace NFSHeatProcessorConfigFix;

internal class ProcessorScanner
{
    internal ProcessorCores GetCores()
    {
        byte physical = 0;
        byte logical = 0;

        ManagementObjectSearcher processors = GetProcessors();
        foreach (ManagementBaseObject item in processors.Get())
        {
            physical += GetPhysicalCores(item);
            logical += GetLogicalCores(item);
        }

        return new(physical, logical);
    }

    private byte GetPhysicalCores(ManagementBaseObject processorInformation)
    {
        string physicalCoresString = processorInformation.GetAsString("NumberOfCores");
        return byte.Parse(physicalCoresString);
    }

    private byte GetLogicalCores(ManagementBaseObject processorInformation)
    {
        string logicalCoresString = processorInformation.GetAsString("NumberOfLogicalProcessors");
        return byte.Parse(logicalCoresString);
    }

    private ManagementObjectSearcher GetProcessors()
    {
        return new("SELECT * FROM Win32_Processor");
    }
}
