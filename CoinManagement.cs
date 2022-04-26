using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
        
        public string GetListCoins(Coin[] symbols)
        {
            string list = "";

            for (int i=0;i<symbols.Length;i++)
            {
                list += symbols[i].GetName();

                if (i != symbols.Length-1)
                {
                    list += ",";
                }
            }

            return list;
        }

        public void ParseResponse(dynamic JSONResponse, Coin[] Symbols)
        {
            for (int i=0;i<Symbols.Length;i++)
            {
                string jsonPriceData        = "data." + Symbols[i].GetName() + "[0].quote.USD.price";
                string jsonPricePercent24h  = "data." + Symbols[i].GetName() + "[0].quote.USD.percent_change_24h";

                string crypto_price = JSONResponse.SelectToken(jsonPriceData);
                string crypto_24h_change_price = JSONResponse.SelectToken(jsonPricePercent24h);

                crypto_price.Trim(new Char[] { '{', '}' });
                crypto_24h_change_price.Trim(new Char[] { '{', '}' });

                Symbols[i].SetPrice(Convert.ToDouble(crypto_price));
                Symbols[i].SetChange(Convert.ToDouble(crypto_24h_change_price));
            }
        }
    }
}


