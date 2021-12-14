using System;

namespace ConsolePrintTerminalColors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("██ Black       : " + ((int)ConsoleColor.Black).ToString());
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("██ DarkBlue    : " + ((int)ConsoleColor.DarkBlue).ToString());
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("██ DarkGreen   : " +  ((int)ConsoleColor.DarkGreen).ToString());
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("██ DarkCyan    : " + ((int)ConsoleColor.DarkCyan).ToString());
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("██ DarkRed     : " + ((int)ConsoleColor.DarkRed).ToString());
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("██ DarkMagenta : " + ((int)ConsoleColor.DarkMagenta).ToString());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("██ DarkYellow  : " + ((int)ConsoleColor.DarkYellow).ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("██ Gray        : " + ((int)ConsoleColor.Gray).ToString());
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("██ DarkGray    : " + ((int)ConsoleColor.DarkGray).ToString());
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("██ Blue        : " + ((int)ConsoleColor.Blue).ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("██ Green       : " + ((int)ConsoleColor.Green).ToString());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("██ Cyan        : " + ((int)ConsoleColor.Cyan).ToString());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("██ Red         : " + ((int)ConsoleColor.Red).ToString());
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("██ Magenta     : " + ((int)ConsoleColor.Magenta).ToString());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("██ Yellow      : " + ((int)ConsoleColor.Yellow).ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("██ White       : " + ((int)ConsoleColor.White).ToString());
            Console.ResetColor();
            Console.WriteLine("██ Default     : " + Console.ForegroundColor.ToString());
        }
    }
}
