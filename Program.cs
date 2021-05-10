using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;


namespace DogeHODLTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            CoinManagement  CM        = new CoinManagement();
            WebRequest      Web       = new WebRequest();
            QueryManagement QM        = new QueryManagement();
            UserInterface   UI        = new UserInterface();
            KeyboardInput   Input     = new KeyboardInput();
            FileIO          IO        = new FileIO();

            Coin[]          Symbols   = new Coin[Constants.MAX_COINS];

            Dictionary<string, string> coinData = new Dictionary<string, string>();

            string[] allowedCoins = IO.ReadFromFile();
            coinData = CM.ParseResponse(allowedCoins);

            for (int i=0;i<allowedCoins.Length;i++)
            {
                Symbols[i] = new Coin(coinData.Keys.ElementAt(i), coinData.Values.ElementAt(i));
                HttpResponseMessage msg = Web.SendRequest(QM.GetPrice(Symbols[i].GetName(), Symbols[i].GetCurrency()));
                dynamic JSONObject = Web.CheckResponse(msg);
                Symbols[i].SetPrice(CM.GetPrice(JSONObject));
            }

            HttpResponseMessage walletData = Web.SendRequest(QM.GetAccountInformation());
            dynamic JSONObjectWallet = Web.CheckResponse(walletData);

            Console.WriteLine("");
            while (true)
            {
                UI.UpdateScreen(Symbols);
                UI.ProcessInput(Input.Listen());
            }

        }
    } 
}
