using System;
using Durak.Interfaces;

namespace Durak.TextClasses
{
    public class Messages : IMessages
    {
        public string yourCardsAre_1_ { get; }
        public string cardOnTableAre_2_ { get; }
        public string chooseAttackCard_3_ { get; }
        public string youMayUseTheseCards_4_ { get; }
        public string youCannotUseCard_5_ { get; }
        public string haveNoCardsToAttack_6_ { get; }
        public string chooseDefendCard_7_ { get; }
        public string chooseToTakeAllCards_8_ { get; }
        public string youTakeAllCards_9_ { get; }
        public string haveNoCardsToDefend_10_ { get; }
        public string welcome_11_ { get; }
        public string enterName_12_ { get; }
        public string hello_13_ { get; }
        public string enterCpuStrategy_14_ { get; }
        public string firstVar_15_ { get; }
        public string secondVar_16_ { get; }
        public string trumpCardIs_17_ { get; }
        public string yourTurn_18_ { get; }
        public string thereIs_19_ { get; }
        public string cardsInCpuHands_20_ { get; }
        public string cardsInDeck_21_ { get; }
        public string turnChanges_22_ { get; }
        public string cpuTurn_23_ { get; }
        public string drawThisTime_24_ { get; }
        public string congratulations_25_ { get; }
        public string youAreWinner_26_ { get; }
        public string youLoseThisGame_27_ { get; }
        public string press_28_ { get; }
        public string toStartAgain_29_ { get; }
        public string cpuHasNoAttackCard_30_ { get; }
        public string cpuAttackedYouWith_31_ { get; }
        public string cpuBeatWith_32_ { get; }
        public string cpuHasNoDefendCard_33_ { get; }


        public Messages (ILanguageDataProvider languageConfiguration)
        {
            if (languageConfiguration != null)
            {
                yourCardsAre_1_ = languageConfiguration.GetMessageFromConfiguration("yourCardsAre_1_");
                cardOnTableAre_2_ = languageConfiguration.GetMessageFromConfiguration("cardOnTableAre_2_");
                chooseAttackCard_3_ = languageConfiguration.GetMessageFromConfiguration("chooseAttackCard_3_");
                youMayUseTheseCards_4_ = languageConfiguration.GetMessageFromConfiguration("youMayUseTheseCards_4_");
                youCannotUseCard_5_ = languageConfiguration.GetMessageFromConfiguration("youCannotUseCard_5_");
                haveNoCardsToAttack_6_ = languageConfiguration.GetMessageFromConfiguration("haveNoCardsToAttack_6_");
                chooseDefendCard_7_ = languageConfiguration.GetMessageFromConfiguration("chooseDefendCard_7_");
                chooseToTakeAllCards_8_ = languageConfiguration.GetMessageFromConfiguration("chooseToTakeAllCards_8_");
                youTakeAllCards_9_ = languageConfiguration.GetMessageFromConfiguration("youTakeAllCards_9_");
                haveNoCardsToDefend_10_ = languageConfiguration.GetMessageFromConfiguration("haveNoCardsToDefend_10_");
                welcome_11_ = languageConfiguration.GetMessageFromConfiguration("welcome_11_");
                enterName_12_ = languageConfiguration.GetMessageFromConfiguration("enterName_12_");
                hello_13_ = languageConfiguration.GetMessageFromConfiguration("hello_13_");
                enterCpuStrategy_14_ = languageConfiguration.GetMessageFromConfiguration("enterCpuStrategy_14_");
                firstVar_15_ = languageConfiguration.GetMessageFromConfiguration("firstVar_15_");
                secondVar_16_ = languageConfiguration.GetMessageFromConfiguration("secondVar_16_");
                trumpCardIs_17_ = languageConfiguration.GetMessageFromConfiguration("trumpCardIs_17_");
                yourTurn_18_ = languageConfiguration.GetMessageFromConfiguration("yourTurn_18_");
                thereIs_19_ = languageConfiguration.GetMessageFromConfiguration("thereIs_19_");
                cardsInCpuHands_20_ = languageConfiguration.GetMessageFromConfiguration("cardsInCpuHands_20_");
                cardsInDeck_21_ = languageConfiguration.GetMessageFromConfiguration("cardsInDeck_21_");
                turnChanges_22_ = languageConfiguration.GetMessageFromConfiguration("turnChanges_22_");
                cpuTurn_23_ = languageConfiguration.GetMessageFromConfiguration("cpuTurn_23_");
                drawThisTime_24_ = languageConfiguration.GetMessageFromConfiguration("drawThisTime_24_");
                congratulations_25_ = languageConfiguration.GetMessageFromConfiguration("congratulations_25_");
                youAreWinner_26_ = languageConfiguration.GetMessageFromConfiguration("youAreWinner_26_");
                youLoseThisGame_27_ = languageConfiguration.GetMessageFromConfiguration("youLoseThisGame_27_");
                press_28_ = languageConfiguration.GetMessageFromConfiguration("press_28_");
                toStartAgain_29_ = languageConfiguration.GetMessageFromConfiguration("toStartAgain_29_");
                cpuHasNoAttackCard_30_ = languageConfiguration.GetMessageFromConfiguration("cpuHasNoAttackCard_30_");
                cpuAttackedYouWith_31_ = languageConfiguration.GetMessageFromConfiguration("cpuAttackedYouWith_31_");
                cpuBeatWith_32_ = languageConfiguration.GetMessageFromConfiguration("cpuBeatWith_32_");
                cpuHasNoDefendCard_33_ = languageConfiguration.GetMessageFromConfiguration("cpuHasNoDefendCard_33_");
            }
            else
            {
                throw new ArgumentNullException(nameof(Messages));
            }
        }
    }
}
