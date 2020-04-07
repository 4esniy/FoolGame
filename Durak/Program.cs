using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace Durak
{
    class Program
    {

        static void Main(string[] args)
        {
            //setConfigFileAtRuntime(args);
            Table GameTable = new Table();
            GameTable.RunTheGame();
            
        }

    }

}

