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
        private double OneDayChange;
        
        public Coin(string name)
        {
            this.name = name;
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
            return Math.Round(price, 2);
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

        public void SetChange(double change)
        {
            this.OneDayChange = change;
        }

        public double GetChange()
        {
            return Math.Round(OneDayChange, 2);
        }
    }
}


