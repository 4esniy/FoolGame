using Durak.Interfaces;
using System;
using System.Configuration;

namespace Durak
{
    public class ConsoleReadWrap : IConsoleReadWrap
    {
        public string ConsoleReadLine()
        {
            return Console.ReadLine();
        }

        public string ReadAppSettings()
        {
            return ConfigurationManager.AppSettings["Message"];
        }

    }
}
