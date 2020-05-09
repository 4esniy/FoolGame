using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using Durak.Interfaces;
using Durak.Properties;
using Durak.TextClasses;

namespace Durak
{
    public class ConfigurationSetter : IConfigurationSetter
    {
        public IReaderFactory ReaderFactory { get; }
        public ILanguageDataProvider LanguageConfiguration { get; }
        public IMessages Message { get; }
        public IAlerts Alert { get; }
        public IDefaultConstants Constant { get; }
        public ICardAttributesConverter CardAttributes { get; }
        public string _message { get; }
        public int _languageType { get; }

        public ConfigurationSetter(IManualInputProvider manualInputProvider)
        {
            _message = manualInputProvider.message;
            _languageType = manualInputProvider.ReturnLanguageTypeInputValue();

            ReaderFactory = new ReaderFactory(_languageType);

            try
            {
                LanguageConfiguration = new LanguageDataProvider(ReaderFactory);
            }
            catch (Exception e)
            {
                //log
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                Environment.Exit(0);
            }

            try
            {
                Message = new Messages(LanguageConfiguration);
                Alert = new Alerts(LanguageConfiguration);
                Constant = new DefaultConstants(LanguageConfiguration);
                CardAttributes = new CardAttributesConverter(LanguageConfiguration);
            }
            catch (Exception e)
            {
                //log
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}