using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp40.Operations
{
    public static class OperationOne
    {
        public static void ShowPorcesses()
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
    }
}
