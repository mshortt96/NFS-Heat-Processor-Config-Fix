using System.Diagnostics;

namespace NFSHeatProcessorConfigFix;

internal static class Logger
{
    public static void CreateErrorLog(Exception exception)
    {
        using (Process app = Process.GetCurrentProcess())
        {
            string appName = app.ProcessName;
            string currentDirectory = Directory.GetCurrentDirectory();

            File.WriteAllLines($"{currentDirectory}\\{appName} Error.txt", new string[]
            {
                $"Error: {exception.Message}",
                $"Location: {exception.StackTrace.Substring(6)}" //Remove leading white space and "at " from stack trace.
            });
        }
    }
}
