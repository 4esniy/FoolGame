using System;
using System.Configuration;
using Durak.Interfaces;
using Durak.Properties;
using Durak.TextClasses;

namespace Durak
{
    class ConfigurationSetter : IConfigurationSetter
    {
        private IReaderFactory ReaderFactory{ get; }
        private ILanguageDataProvider LanguageConfiguration { get; }
        public IMessages Message { get; }
        public IAlerts Alert { get; }
        public IDefaultConstants Constant { get; }
        public ICardAttributesConverter CardAttributes { get; }

        // these messages are default
        string message = ConfigurationManager.AppSettings["Message"];

        internal ConfigurationSetter()
        {
            int languageType = 0;

            #region Check the input

            while (true)
            {
                Console.WriteLine($"{message}"); //Choose language and press Enter: 1- English, 2 - Русский
                string input = Console.ReadLine();
                int.TryParse(input, out languageType);

                if (languageType != 1 && languageType != 2)
                {
                    Console.WriteLine($"Input violation. {message}");
                }
                else break;
                #endregion
            }

            ReaderFactory = new ReaderFactory(languageType);
            LanguageConfiguration = new LanguageDataProvider(ReaderFactory);
            Message = new Messages(LanguageConfiguration);
            Alert = new Alerts(LanguageConfiguration);
            Constant = new DefaultConstants(LanguageConfiguration);
            CardAttributes = new CardAttributesConverter(LanguageConfiguration);

        }
    }
}