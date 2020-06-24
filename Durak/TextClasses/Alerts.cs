using System;
using Durak.Interfaces;

namespace Durak.TextClasses
{
    public class Alerts : IAlerts
    {
        public string enterInteger_1_ { get; }
        public string enterNotBiggerThan_2_ { get; }
        public string enterPositiveNumber_3_ { get; }
        public string enterNotLessThan10_4_ { get; }
        public string userNameNotEmpty_5_ { get; }
        public string noSuchStrategy_6_ { get; }

        public Alerts(ILanguageDataProvider languageConfiguration)
        {
            if (languageConfiguration != null)
            {
                enterInteger_1_ = languageConfiguration.GetAlertFromConfiguration("enterInteger_1_");
                enterNotBiggerThan_2_ = languageConfiguration.GetAlertFromConfiguration("enterNotBiggerThan_2_");
                enterPositiveNumber_3_ = languageConfiguration.GetAlertFromConfiguration("enterPositiveNumber_3_");
                enterNotLessThan10_4_ = languageConfiguration.GetAlertFromConfiguration("enterNotLessThan10_4_");
                userNameNotEmpty_5_ = languageConfiguration.GetAlertFromConfiguration("userNameNotEmpty_5_");
                noSuchStrategy_6_ = languageConfiguration.GetAlertFromConfiguration("noSuchStrategy_6_");
            }
            else
            {
                throw new ArgumentNullException(nameof(Alerts));
            }
        }
    }
}
