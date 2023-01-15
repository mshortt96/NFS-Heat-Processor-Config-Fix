using NFSHeatProcessorConfigFix.Data;
using System.Runtime.InteropServices;

namespace NFSHeatProcessorConfigFix;

internal class Program
{
    internal const string Name = "NFS Heat Processor Config Fix";

    internal static void Main()
    {
        try
        {
            Console.Title = Name;

            Console.WriteLine("NFS Heat Processor Config Fix");
            Console.WriteLine("=============================");
            Helpers.Console.WriteEmptyLine();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string workingDirectory = DetermineFileCreationLocation();

                Console.WriteLine($@"Press any key to create your ""{FileConfig.FileName}{FileConfig.FileExtension}"" file. If one already exists, it will be backed up.");
                Console.ReadKey();
                Helpers.Console.WriteEmptyLine(2);

                CreateFile(workingDirectory);

                Helpers.Console.WriteEmptyLine();
                Console.WriteLine("Press any key to close.");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Sorry, currently this application can only be run on a Windows machine.");
                Console.ReadKey();
            }
        }

        catch(Exception ex)
        {
            Logger.CreateErrorLog(ex);

            Console.Clear();
            Console.WriteLine("An unexpected error occurred.");
            Console.ReadKey();
        }
    }

    private static string DetermineFileCreationLocation()
    {
        GameConfig gameConfig = new();

        string installationDirectory = gameConfig.GetInstallationLocation();
        if(string.IsNullOrWhiteSpace(installationDirectory))
        {
            Console.WriteLine("Need For Speed Heat installation location could not be determined.");
        }

        else
        {
            Console.WriteLine(@$"I have determined that your game is installed at ""{installationDirectory}."" Is this correct?");

            bool installationDirectoryConfirmed = Helpers.Console.WaitOnConfirmation();
            Helpers.Console.WriteEmptyLine(2);
            if (!installationDirectoryConfirmed)
            {
                installationDirectory = null;
            }
        }

        if (string.IsNullOrWhiteSpace(installationDirectory))
        {
            Console.WriteLine($@"The ""{FileConfig.FileName}{FileConfig.FileExtension}"" file will be created in the current directory.");
        }

        return installationDirectory;
    }

    private static void CreateFile(string location)
    {
        Console.WriteLine("Please wait...");

        ProcessorScanner processorScanner = new();
        ProcessorCores processorCores = processorScanner.GetCores();

        FileConfig configFileCreator = new(location);
        configFileCreator.BackupExistingFile();
        configFileCreator.CreateFile(processorCores);

        Helpers.Console.WriteEmptyLine();
        Console.WriteLine("Done!");
    }
}