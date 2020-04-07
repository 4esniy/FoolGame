using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Collections;

namespace Durak
{
    class Messages : IMessages
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



        internal Messages (int languageType)
        {

            ReadLanguageConfiguration Configuration = new ReadLanguageConfiguration(languageType);

            yourCardsAre_1_ = Configuration.GetTextFromConfiguration("yourCardsAre_1_");
            cardOnTableAre_2_  = Configuration.GetTextFromConfiguration("cardOnTableAre_2_");
            chooseAttackCard_3_ = Configuration.GetTextFromConfiguration("chooseAttackCard_3_");
            youMayUseTheseCards_4_ = Configuration.GetTextFromConfiguration("youMayUseTheseCards_4_");
            youCannotUseCard_5_ = Configuration.GetTextFromConfiguration("youCannotUseCard_5_");
            haveNoCardsToAttack_6_ = Configuration.GetTextFromConfiguration("haveNoCardsToAttack_6_");
            chooseDefendCard_7_ = Configuration.GetTextFromConfiguration("chooseDefendCard_7_");
            chooseToTakeAllCards_8_ = Configuration.GetTextFromConfiguration("chooseToTakeAllCards_8_");
            youTakeAllCards_9_ = Configuration.GetTextFromConfiguration("youTakeAllCards_9_");
            haveNoCardsToDefend_10_ = Configuration.GetTextFromConfiguration("haveNoCardsToDefend_10_");
            welcome_11_ = Configuration.GetTextFromConfiguration("welcome_11_");
            enterName_12_ = Configuration.GetTextFromConfiguration("enterName_12_");
            hello_13_ = Configuration.GetTextFromConfiguration("hello_13_");
            enterCpuStrategy_14_ = Configuration.GetTextFromConfiguration("enterCpuStrategy_14_");
            firstVar_15_ = Configuration.GetTextFromConfiguration("firstVar_15_");
            secondVar_16_ = Configuration.GetTextFromConfiguration("secondVar_16_");
            trumpCardIs_17_ = Configuration.GetTextFromConfiguration("trumpCardIs_17_");
            yourTurn_18_ = Configuration.GetTextFromConfiguration("yourTurn_18_");
            thereIs_19_ = Configuration.GetTextFromConfiguration("thereIs_19_");
            cardsInCpuHands_20_ = Configuration.GetTextFromConfiguration("cardsInCpuHands_20_");
            cardsInDeck_21_ = Configuration.GetTextFromConfiguration("cardsInDeck_21_");
            turnChanges_22_ = Configuration.GetTextFromConfiguration("turnChanges_22_");
            cpuTurn_23_ = Configuration.GetTextFromConfiguration("cpuTurn_23_");
            drawThisTime_24_ = Configuration.GetTextFromConfiguration("drawThisTime_24_");
            congratulations_25_ = Configuration.GetTextFromConfiguration("congratulations_25_");
            youAreWinner_26_ = Configuration.GetTextFromConfiguration("youAreWinner_26_");
            youLoseThisGame_27_ = Configuration.GetTextFromConfiguration("youLoseThisGame_27_");
            press_28_ = Configuration.GetTextFromConfiguration("press_28_");
            toStartAgain_29_ = Configuration.GetTextFromConfiguration("toStartAgain_29_");
            cpuHasNoAttackCard_30_ = Configuration.GetTextFromConfiguration("cpuHasNoAttackCard_30_");
            cpuAttackedYouWith_31_ = Configuration.GetTextFromConfiguration("cpuAttackedYouWith_31_");
            cpuBeatWith_32_ = Configuration.GetTextFromConfiguration("cpuBeatWith_32_");
            cpuHasNoDefendCard_33_ = Configuration.GetTextFromConfiguration("cpuHasNoDefendCard_33_");

        }

    }
}
