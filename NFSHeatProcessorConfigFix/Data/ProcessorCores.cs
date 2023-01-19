namespace NFSHeatProcessorConfigFix.Data;

internal struct ProcessorCores
{
    internal byte Physical { get; }
    internal byte Logical { get; }
    internal bool Hyperthreaded => Logical > Physical;

    internal ProcessorCores(byte physical, byte logical)
    {
        Physical = physical;
        Logical = logical;
    }
}
