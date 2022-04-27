using System;
using System.Collections.Generic;
using System.Text;

namespace DogeHODLTrader
{
    public class UserInterface
    {

        private bool programActive;

        public UserInterface()
        {
            programActive = false;
            Console.CursorVisible = false;
        }

        public void PreInterface()
        {
            Console.WriteLine("Starting...\n");
        }
        public void ProcessInput(int selection)
        {
            if (selection == Constants.OPTION_ENTER)
            {
                programActive = !programActive;
            }
        }

        public void UpdateScreen(Coin[] coins, bool status)
        {
            Console.Clear();
            Visuals.PrintTitle();
            Visuals.PrintServerStatus(status);

            Console.Write("\t");
            if (programActive)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ~ PROGRAM ACTIVE ~ ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(" ~ NOT ACTIVE ~ ");
            }
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write("\n\n\tCoin\tCost (USD)\tChange % (24h)\n");
            Console.Write("\t-----------------------------------\n");
            for (int j = 0; j < coins.Length; j++)
            {
                if (coins[j] == null) break;
                Console.Write("\n\t" + coins[j].GetName() + "\t" + coins[j].GetPrice() + "\t\t[");
                
                if (coins[j].GetChange() > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(coins[j].GetChange());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]");

            }
        }
    }
}

