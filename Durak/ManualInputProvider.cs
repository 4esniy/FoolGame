using System;
using System.Configuration;
using Durak.Interfaces;

namespace Durak
{
    public class ManualInputProvider : IManualInputProvider
    {
        public string message { get; }
        public IConsoleReadWrap _consoleReadWrap { get; }

        public ManualInputProvider(IConsoleReadWrap consoleReadWrap)
        {
            _consoleReadWrap = consoleReadWrap;
            message = consoleReadWrap.ReadAppSettings();
        }

        public int ReturnLanguageTypeInputValue()
        {
            Console.WriteLine($"{message}"); //Choose language and press Enter: 1- English, 2 - Русский
            var input = _consoleReadWrap.ConsoleReadLine();
            int.TryParse(input, out int languageType);
            if (languageType != 1 && languageType != 2)
                ReturnLanguageTypeInputValue();
            return languageType;
        }
    }
}
