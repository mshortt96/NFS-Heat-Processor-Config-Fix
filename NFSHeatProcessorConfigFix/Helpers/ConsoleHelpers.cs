using X = System.Console;

namespace NFSHeatProcessorConfigFix;

internal static partial class Helpers
{
    internal static class Console
    {
        internal static bool WaitOnConfirmation()
        {
            X.WriteLine(@"Press ""Y"" for Yes or ""N"" for No.");

            ConsoleKeyInfo keyPress;
            do
            {
                keyPress = X.ReadKey();
            } 
            
            while (keyPress.Key != ConsoleKey.Y && keyPress.Key != ConsoleKey.N);

            return keyPress.Key == ConsoleKey.Y;
        }

        internal static void WriteEmptyLine(uint total = 1)
        {
            if(total == 0)
            {
                throw new ArgumentException("Cannot be less than 1.", nameof(total));
            }

            for (int i = 0; i < total; i++)
            {
                X.WriteLine(string.Empty);
            }
        }
    }
}