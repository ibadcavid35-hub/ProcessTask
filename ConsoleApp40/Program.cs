using System.Diagnostics;
using static System.Console;
namespace ConsoleApp40
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int select = 0;
            bool isRun = true;
            List<string> options = new List<string> { "Show Processes", "Start Process", "Stop Process" };

            while (isRun)
            {
                Clear();
                for (int i = 0; i < options.Count; i++)
                {
                    if (select == i)
                    {
                        BackgroundColor = ConsoleColor.White;
                        ForegroundColor = ConsoleColor.Black;
                        WriteLine($">>  {options[i]}");
                        ResetColor();
                    }
                    else
                    {
                        WriteLine($"    {options[i]}");
                    }
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    isRun = false;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    select--;
                    if (select < 0)
                    {
                        select = options.Count - 1;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    select++;
                    if (select >= options.Count)
                    {
                        select = 0;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (select == 0)
                    {
                        ShowProcesses();
                    }
                    else if (select == 1)
                    {
                        StartProcess();
                    }
                    else if (select == options.Count - 1)
                    {
                        StopProcess();
                    }
                }
            }
        }

        static void ShowProcesses()
        {
            Clear();
            foreach (Process process in Process.GetProcesses())
            {
                WriteLine();
                WriteLine($"\u001b[33mProcess Id:\u001b[0m {process.Id}");
                WriteLine($"\u001b[32mProcess Name:\u001b[0m {process.ProcessName}");
                WriteLine($"\u001b[32mHandle Count:\u001b[0m {process.HandleCount}");
                WriteLine($"\u001b[32mThreads Count:\u001b[0m {process.Threads.Count}");
                WriteLine($"\u001b[32mMachine Name:\u001b[0m {process.MachineName}");
                WriteLine();
            }
            ReadKey(true);
        }

        static void StartProcess()
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
            catch(Exception ex) 
            {
                WriteLine($"\n\u001b[31mThe process couldn't start: \u001b[0m{ex.Message}");
                ReadKey(true);
            }
        }

        static void StopProcess()
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