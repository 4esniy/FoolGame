using System;
using Durak.Interfaces;

namespace Durak.TextClasses
{
    public class Alerts : IAlerts
    {
        public string enterInteger_1_ { get ;}
        public string enterNotBiggerThan_2_ { get; }
        public string enterPositiveNumber_3_ { get; }
        public string enterNotLessThan10_4_ { get; }
        public string userNameNotEmpty_5_ { get; }
        public string noSuchStrategy_6_ { get; }

        public Alerts(ILanguageDataProvider languageConfiguration)
        {
            try
            {
                enterInteger_1_ = languageConfiguration.GetTextFromConfiguration("enterInteger_1_");
                enterNotBiggerThan_2_ = languageConfiguration.GetTextFromConfiguration("enterNotBiggerThan_2_");
                enterPositiveNumber_3_ = languageConfiguration.GetTextFromConfiguration("enterPositiveNumber_3_");
                enterNotLessThan10_4_ = languageConfiguration.GetTextFromConfiguration("enterNotLessThan10_4_");
                userNameNotEmpty_5_ = languageConfiguration.GetTextFromConfiguration("userNameNotEmpty_5_");
                noSuchStrategy_6_ = languageConfiguration.GetTextFromConfiguration("noSuchStrategy_6_");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{nameof(Alerts)}received empty parameters. {e.Message}");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
