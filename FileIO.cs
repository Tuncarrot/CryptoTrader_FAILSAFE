using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DogeHODLTrader
{

    public class FileIO
    {
        private const string fileName = @"C:\Users\Home Computer\Desktop\CRYPTO_COINS_ALLOWED.txt";

        public FileIO()
        {

        }

        public string[] ReadFromFile()
        {
            string[] symbols = { };

            if(File.Exists(fileName))
            {
                symbols = File.ReadAllLines(fileName);
            }

            return symbols;
        }

    }


}
