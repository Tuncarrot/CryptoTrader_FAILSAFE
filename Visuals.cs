using System;
using System.Collections.Generic;
using System.Text;

namespace DogeHODLTrader
{
    static class Visuals
    {
        static public void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n");
            Console.WriteLine("\t /$$$$$$$$       /$$ /$$  /$$$$$$   /$$$$$$  /$$$$$$$$ /$$$$$$$$");
            Console.WriteLine("\t| $$_____/      |__/| $$ /$$__  $$ /$$__  $$| $$_____/| $$_____/");
            Console.WriteLine("\t| $$    /$$$$$$  /$$| $$| $$  \\__/| $$  \\ $$| $$      | $$      ");
            Console.WriteLine("\t| $$$$$|____  $$| $$| $$|  $$$$$$ | $$$$$$$$| $$$$$   | $$$$$   ");
            Console.WriteLine("\t| $$__/ /$$$$$$$| $$| $$ \\____  $$| $$__  $$| $$__/   | $$__/   ");
            Console.WriteLine("\t| $$   /$$__  $$| $$| $$ /$$  \\ $$| $$  | $$| $$      | $$      ");
            Console.WriteLine("\t| $$  |  $$$$$$$| $$| $$|  $$$$$$/| $$  | $$| $$      | $$$$$$$$");
            Console.WriteLine("\t|__/   \\_______/|__/|__/ \\______/ |__/  |__/|__/      |________/");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public void PrintServerStatus(bool status)
        {
            Console.Write("\n\t SERVER STATUS : ");
            if (status)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ONLINE");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("OFFLINE");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }
    }
}

