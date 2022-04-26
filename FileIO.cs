using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DogeHODLTrader
{

    public class FileIO
    {

        public FileIO()
        {

        }

        public string[] ReadFromFile(string fileName)
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

