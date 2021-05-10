using System;
using System.Collections.Generic;
using System.Text;

namespace DogeHODLTrader
{
    public class UserInterface
    {

        private int menuTicker;
        private int menuTracker;

        public UserInterface()
        {
            menuTicker = Constants.FIRST_OPTION;
            menuTracker = Constants.MAIN_MENU;

            Console.CursorVisible = false;
        }

        public void PreInterface()
        {
            Console.WriteLine("Starting...\n");
        }
        public void ProcessInput(int selection)
        {
            if (selection != Constants.OPTION_ENTER)
            {
                menuTicker += selection;

                if (menuTicker > Constants.MAIN_MENU_OPTIONS.Length)
                {
                    menuTicker--;
                }
                else if (menuTicker < Constants.FIRST_OPTION)
                {
                    menuTicker++;
                }
            }
            else
            {
                // User Pressed Enter, Load next screen
            }
        }

        public void UpdateScreen(Coin[] coins)
        {
            Console.Clear();
            Visuals.PrintTitle();

            for (int i = 0; i < Constants.MAIN_MENU_OPTIONS.Length; i++)
            {
                if (i == menuTicker)
                {
                    Console.Write("\t\t-> ");
                }
                else
                {
                    Console.Write("    \t\t");
                }
                Console.WriteLine(Constants.MAIN_MENU_OPTIONS[i]);
            }
            Console.Write("\n\n\n\n\t\tCoin  Cost (USD)\n");
            Console.Write("\t\t-----------------------\n");
            for (int j = 0; j < coins.Length; j++)
            {
                if (coins[j] == null) break;
                Console.WriteLine("\t\t" + coins[j].GetName() + " -> " + coins[j].GetPrice() + " [" + coins[j].GetCurrency() + "]");
            }
        }
    }
}

