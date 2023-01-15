using NFSHeatProcessorConfigFix.Data;

namespace NFSHeatProcessorConfigFix;

internal class FileConfig
{
    internal const string FileName = "user";
    internal const string BackupFileName = $"{FileName} (backup)";
    internal const string FileExtension = ".cfg";

    public string Location { get; }

    internal FileConfig(string location = null)
    {
        Location = string.IsNullOrWhiteSpace(location) ? Directory.GetCurrentDirectory() : location;
    }

    internal void CreateFile(ProcessorCores processorCores)
    {
        File.WriteAllLines($"{Location}\\{FileName}{FileExtension}", new[] {
            $"Thread.ProcessorCount {processorCores.Physical}",
            $"Thread.MaxProcessorCount {processorCores.Physical}",
            $"Thread.MinFreeProcessorCount 0",
            $"Thread.JobThreadPriority 0",
            @$"GstRender.Thread.MaxProcessorCount {processorCores.Logical}""" //Double quotes at line end intentional
        });
    }

    internal void BackupExistingFile()
    {
        if (FileExists())
        {
            File.Move($"{Location}\\{FileName}{FileExtension}", $"{BackupFileName}{FileExtension}", true);
        }
    }

    internal bool FileExists()
    {
        return File.Exists($"{Location}\\{FileName}{FileExtension}");
    }
}
