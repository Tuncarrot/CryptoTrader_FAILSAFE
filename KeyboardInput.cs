using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DogeHODLTrader
{
    public class KeyboardInput
    {
        public KeyboardInput()
        {

        }

        public int Listen()
        {
            int value = 0;
            
            var key = Console.ReadKey(false).Key;

            switch(key)
            {
                case ConsoleKey.UpArrow:
                    value = Constants.OPTION_UP;
                    break;
                case ConsoleKey.DownArrow:
                    value = Constants.OPTION_DOWN;
                    break;
                case ConsoleKey.Enter:
                    value = Constants.OPTION_ENTER;
                    break;
            }

            return value;
        }

    }

}
