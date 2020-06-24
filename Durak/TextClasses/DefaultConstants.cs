using System;
using Durak.Interfaces;
using Serilog;

namespace Durak.TextClasses
{
    public class DefaultConstants : IDefaultConstants
    {
        public int numberOfCards_1_ { get; }
        public string strategy_1_4_ { get; }
        public string strategy_2_5_ { get; }
        public string strategy_Human_6_ { get; }
        public string WantToContinue_7_ { get; }

        public DefaultConstants(ILanguageDataProvider languageConfiguration)
        {
            if (languageConfiguration != null)
            {
                strategy_1_4_ = languageConfiguration.GetMessageFromConfiguration("strategy_1_4_");
                strategy_2_5_ = languageConfiguration.GetMessageFromConfiguration("strategy_2_5_");
                strategy_Human_6_ = languageConfiguration.GetMessageFromConfiguration("strategy_Human_6_");
                WantToContinue_7_ = languageConfiguration.GetMessageFromConfiguration("WantToContinue_7_");
                int.TryParse(languageConfiguration.GetMessageFromConfiguration("numberOfCards_1_"), out int numberOfCards);
                numberOfCards_1_ = numberOfCards;
            }
            else
            {
                throw new ArgumentNullException(nameof(DefaultConstants));
            }
        }

    }
}
