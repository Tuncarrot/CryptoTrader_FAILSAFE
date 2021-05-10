using System;
using System.Collections.Generic;
using System.Text;

namespace DogeHODLTrader
{
    public class CoinManagement
    {

        public CoinManagement()
        {

        }

        public double GetPrice(dynamic JSONObject)
        {
            string format = (JSONObject.price).ToString();

            return Convert.ToDouble(format);
        }
        
        public Dictionary<string, string> ParseResponse(string[] allowedCoins)
        {
            Dictionary<string, string> coinData = new Dictionary<string, string>();
            
            for (int i=0;i<allowedCoins.Length;i++)
            {
                string data = allowedCoins[i];
                string[] coinExtract = data.Split(",");

                coinData.Add(coinExtract[0], coinExtract[1]);
            }

            return coinData;
        }
    }
}


