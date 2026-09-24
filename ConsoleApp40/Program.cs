using ConsoleApp40.Operations;
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
                        OperationOne.ShowPorcesses();
                    }
                    else if (select == 1)
                    {
                        OperationTwo.StartProcess();
                    }
                    else if (select == options.Count - 1)
                    {
                        OperationThree.StopProcess();
                    }
                }
            }
        }
    }
}

//Asembly - bizim yazdigimiz kod compile olunandan sonra yaranir, iki fayl yaranir .exe ve .dll.
//Module - Asssembly daxilindeki hissesidir. Meselen .dll daxilinde olan module-ler ola biler.
//Ve her modeule daxilinde class,method ve s. saxlayir.