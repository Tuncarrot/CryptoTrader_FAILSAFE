using System;
using System.Collections.Generic;
using System.Text;

namespace DogeHODLTrader
{
    public static class Constants
    {
        // Keyboard Constants
        public static readonly int OPTION_ENTER = 0;
        public static readonly int OPTION_UP = -1;
        public static readonly int OPTION_DOWN = 1;

        // Menu Constants
        public static readonly int MAIN_MENU = 0;

        // Menu Ticker Options
        public static readonly int FIRST_OPTION = 0;

        // Menu Selection Options
        public static readonly string[] MAIN_MENU_OPTIONS = { "Start", "Exit" };

        // Coin Constants
        public static readonly int MAX_COINS = 20;

        // Binance REST API Calls
        public static readonly string GET_TICKER_24_HR = "/api/v3/ticker/24hr";
        public static readonly string GET_AVG_PRICE = "/api/v3/avgPrice";
        public static readonly string GET_ACCOUNT_SNAP = "/sapi/v1/accountSnapshot";
        public static readonly string GET_ACCOUNT_INFORMATION = "/api/v3/account";

        // Binance Account Types
        public static readonly string SPOT = "SPOT";

        // Crypto Currencies
        public static readonly string BTC = "BTC";
        public static readonly string USD = "USDT";

        // Data Extraction Constants
        public static readonly int NUM_OF_FIELDS = 2;

    }
}
