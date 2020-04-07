using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.Collections;

namespace Durak
{
    class Alerts : IAlerts
    {
        public string enterInteger_1_ { get ;}
        public string enterNotBiggerThan_2_ { get; }
        public string enterPositiveNumber_3_ { get; }
        public string enterNotLessThan10_4_ { get; }
        public string userNameNotEmpty_5_ { get; }
        public string noSuchStrategy_6_ { get; }

        internal Alerts(int languageType)
        {
            ReadLanguageConfiguration Configuration = new ReadLanguageConfiguration(languageType);

            enterInteger_1_ = Configuration.GetTextFromConfiguration("enterInteger_1_");
            enterNotBiggerThan_2_ = Configuration.GetTextFromConfiguration("enterNotBiggerThan_2_");
            enterPositiveNumber_3_ = Configuration.GetTextFromConfiguration("enterPositiveNumber_3_");
            enterNotLessThan10_4_ = Configuration.GetTextFromConfiguration("enterNotLessThan10_4_");
            userNameNotEmpty_5_ = Configuration.GetTextFromConfiguration("userNameNotEmpty_5_");
            noSuchStrategy_6_ = Configuration.GetTextFromConfiguration("noSuchStrategy_6_");

        }
    }
}
