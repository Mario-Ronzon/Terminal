using System;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleBasicCharts
{
    class Program
    {
        /*
            Black = 0,
            DarkBlue = 1,
            DarkGreen = 2,
            DarkCyan = 3,
            DarkRed = 4,
            DarkMagenta = 5,
            DarkYellow = 6,
            Gray = 7,
            DarkGray = 8,
            Blue = 9,
            Green = 10,
            Cyan = 11,
            Red = 12,
            Magenta = 13,
            Yellow = 14,
            White = 15
        */
        static void Main(string[] args)
        {
            if(args is null)
            {
                Console.Write("...");
                return;
            }
            else if(args.Length < 1)
            {
                Console.WriteLine("no arguments were given");
                return;
            }
            else if(string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("path cant be empty");
                return;
            }
            else if(!File.Exists(args[0]))
            {
                Console.WriteLine("couldn't find file");
                return;
            }

            try
            {
                BarChartVertical barChartVertical = 
                JsonConvert.DeserializeObject<BarChartVertical>(
                    File.ReadAllText(args[0]));
                barChartVertical.CalculateSizes();
                barChartVertical.Print();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            
        }
    }
}
