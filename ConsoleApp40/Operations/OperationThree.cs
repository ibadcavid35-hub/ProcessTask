using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp40.Operations
{
    public static class OperationThree
    {
        public static void StopProcess()
        {
            Write("Write a name of process to stop: ");
            string? nameOfProcess = ReadLine();

            var processes = Process.GetProcessesByName(nameOfProcess);

            try
            {
                foreach (Process process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                    process.Dispose();
                }

                ForegroundColor = ConsoleColor.Green;
                WriteLine("Stoped succesfully");
                ResetColor();
                ReadKey(true);
            }
            catch (Exception ex)
            {
                WriteLine($"\n\u001b[31mThe process couldn't stop: \u001b[0m{ex.Message}");
                ReadKey(true);
            }
        }
    }
}
