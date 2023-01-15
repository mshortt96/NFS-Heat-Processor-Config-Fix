namespace NFSHeatProcessorConfigFix.Data;

internal struct ProcessorCores : IEquatable<ProcessorCores>
{
    public byte Physical { get; }
    public byte Logical { get; }
    public bool Hyperthreaded => Logical > Physical;

    public ProcessorCores(byte physical, byte logical)
    {
        Physical = physical;
        Logical = logical;
    }

    public bool Equals(ProcessorCores other)
    {
        return Physical == other.Physical 
            && Logical == other.Logical;
    }
}
