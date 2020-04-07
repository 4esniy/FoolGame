using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.Collections;

namespace Durak
{
    class DefaultConstants : IDefaultConstants
    {
        public int numberOfCards_1_ { get; }
        public string cardNames_2_ { get; }
        public string cardSuits_3_ { get; }
        public string strategy_1_4_ { get; }
        public string strategy_2_5_ { get; }
        public string strategy_Human_6_ { get; }
        public string WantToContinue_7_ { get; }

        internal DefaultConstants(int languageType)
        {
            ReadLanguageConfiguration Configuration = new ReadLanguageConfiguration(languageType);

            

            numberOfCards_1_ = int.Parse(Configuration.GetTextFromConfiguration("numberOfCards_1_"));
            cardNames_2_ = Configuration.GetTextFromConfiguration("cardNames_2_");
            cardSuits_3_ = Configuration.GetTextFromConfiguration("cardSuits_3_");
            strategy_1_4_ = Configuration.GetTextFromConfiguration("strategy_1_4_");
            strategy_2_5_ = Configuration.GetTextFromConfiguration("strategy_2_5_");
            strategy_Human_6_ = Configuration.GetTextFromConfiguration("strategy_Human_6_");
            WantToContinue_7_ = Configuration.GetTextFromConfiguration("WantToContinue_7_");

        }

        public override string ToString()
        {
            string temp = this.ToString();
            return temp;
        }

    }
}
