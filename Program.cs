using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;
using System.Timers;


namespace DogeHODLTrader
{
    public delegate void UpdatePriceData();
    class Program
    {
        static void Main(string[] args)
        {
            CoinManagement  CM        = new CoinManagement();
            WebRequest      Web_NEW   = new WebRequest("https://api.newton.co/v1/");            // Newton Client
            WebRequest      Web_CMC   = new WebRequest("https://pro-api.coinmarketcap.com");    // CoinMarketCap Client
            QueryManagement QM        = new QueryManagement();
            UserInterface   UI        = new UserInterface();
            KeyboardInput   Input     = new KeyboardInput();
            FileIO          IO        = new FileIO();

            bool serverStatus = false;

            // File cryptos to track
            const string crypto_file;

            // File containing cryto API keys
            const string crypto_api;

            // Read from files
            string[] allowedCoins = IO.ReadFromFile(crypto_file);
            string[] API_Data = IO.ReadFromFile(crypto_api);

            // List of coins
            Coin[] Symbols = new Coin[allowedCoins.Length];

            // Initialize coins that will be used
            for (int i = 0; i < allowedCoins.Length; i++)
            {
                Symbols[i] = new Coin(allowedCoins[i]);
            }

            // Check Server Status first on Newton
            HttpResponseMessage response = Web_NEW.SendRequest(QM.GetApiHealth());
            serverStatus = Web_NEW.CheckServerStatus(response);

            string crypto_list = CM.GetListCoins(Symbols);

            // Set up CoinMarketCap API
            Web_CMC.AddAPIData(API_Data[0], API_Data[1]);

            // This train has no brakes
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += (sender, e) => UpdatePriceData(sender, e, Web_CMC, QM, CM, Symbols, crypto_list);
            timer.Elapsed += (sender, e) => UpdateVisuals(sender, e, UI, Symbols, serverStatus);
            timer.Start();

            while (true)
            {
                UI.ProcessInput(Input.Listen());
            }

        }

        static void UpdatePriceData(object sender, ElapsedEventArgs e, WebRequest Web_CMC, QueryManagement QM, CoinManagement CM, Coin[] Symbols, string crypto_list)
        {
            HttpResponseMessage crypto_prices = Web_CMC.SendRequest(QM.GetPrices(crypto_list));
            dynamic JSONObject = Web_CMC.CheckResponse(crypto_prices);
            CM.ParseResponse(JSONObject, Symbols);
        }

        static void UpdateVisuals(object sender, ElapsedEventArgs e, UserInterface UI, Coin[] Symbols, bool serverStatus)
        {
            UI.UpdateScreen(Symbols, serverStatus);
        }
    } 
}

