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
            BarChartVertical barChartVertical = 
            JsonConvert.DeserializeObject<BarChartVertical>(
                File.ReadAllText("result.json"));
            barChartVertical.CalculateSizes();
            barChartVertical.Print();
        }
    }
}
