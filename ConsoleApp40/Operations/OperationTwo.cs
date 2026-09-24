using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp40.Operations
{
    public static class OperationTwo
    {
        public static void StartProcess()
        {
            Write("Write a name of process: ");
            string? nameOfProcess = ReadLine();

            try
            {
                Process.Start(nameOfProcess);
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Started succesfully");
                ResetColor();
                ReadKey(true);
            }
            catch (Exception ex)
            {
                WriteLine($"\n\u001b[31mThe process couldn't start: \u001b[0m{ex.Message}");
                ReadKey(true);
            }
        }
    }
}
