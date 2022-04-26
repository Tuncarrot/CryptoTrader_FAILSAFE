using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;

namespace DogeHODLTrader
{
    public class QueryManagement
    {
        public QueryManagement()
        {

        }

        public string GetApiHealth()
        {
            return "health-check";
        }

        public string GetPrices(string list)
        {
            return Constants.LATEST_PRICE + "?symbol=" + list;
        }

        public string GetPrice(string symbol, string currency)
        {
            return Constants.GET_AVG_PRICE + "?symbol=" + symbol + currency;
        }

        public string GetWalletData(string type, long timestamp)
        {
            return Constants.GET_ACCOUNT_SNAP + "?type=" + type + "&timestamp=" + timestamp;
        }

        public string GetAccountInformation()
        {
            long datetime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            string query = "timestamp=" + datetime.ToString();
            string hashedKey = GenerateHash("XXX", query);

            return Constants.GET_ACCOUNT_INFORMATION + "?" + query + "&signature=" + hashedKey;
        }

        // Good reference
        // https://github.com/binance-exchange/BinanceDotNet/blob/master/BinanceExchange.API/RequestClient.cs
        public string GenerateHash(string key, string values)
        {
            var messageBytes = Encoding.UTF8.GetBytes(values);
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var hash = new HMACSHA256(keyBytes);
            var computedHash = hash.ComputeHash(messageBytes);
            return BitConverter.ToString(computedHash).Replace("-", "").ToLower();
        }
    }
}

