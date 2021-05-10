using System;
using System.Collections.Generic;
using System.Text;

namespace DogeHODLTrader
{
    public class Coin
    {

        private string name;
        private double price;
        private string currency;
        
        public Coin(string name, string currency)
        {
            this.name = name;
            this.currency = currency;
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public double GetPrice()
        {
            return price;
        }
        public void SetPrice(double price)
        {
            this.price = price;
        }
        public string GetCurrency()
        {
            return currency;
        }
        public void SetCurrency(string currency)
        {
            this.currency = currency;
        }
    }
}
