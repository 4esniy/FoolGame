using Durak.Interfaces;
using Durak.TextClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DurakTest
{

    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void MessageTestShouldSetProperty()
        {
            //Assign
            var mockConfiguration = new Mock<ILanguageDataProvider>();
            mockConfiguration.Setup(x => x.GetTextFromConfiguration(It.IsAny<string>()))
                .Returns("fakeMessage");
            //Act
            var messages = new Messages(mockConfiguration.Object);
            //Assert
            Assert.IsNotNull(messages.yourCardsAre_1_ == "fakeMessage");
            Assert.IsNotNull(messages.cardOnTableAre_2_ == "fakeMessage");
            Assert.IsNotNull(messages.chooseAttackCard_3_ == "fakeMessage");
            Assert.IsNotNull(messages.youMayUseTheseCards_4_ == "fakeMessage");
            Assert.IsNotNull(messages.youCannotUseCard_5_ == "fakeMessage");
            Assert.IsNotNull(messages.haveNoCardsToAttack_6_ == "fakeMessage");
            Assert.IsNotNull(messages.chooseDefendCard_7_ == "fakeMessage");
            Assert.IsNotNull(messages.chooseToTakeAllCards_8_ == "fakeMessage");
            Assert.IsNotNull(messages.youTakeAllCards_9_ == "fakeMessage");
            Assert.IsNotNull(messages.haveNoCardsToDefend_10_ == "fakeMessage");
            Assert.IsNotNull(messages.welcome_11_ == "fakeMessage");
            Assert.IsNotNull(messages.enterName_12_ == "fakeMessage");
            Assert.IsNotNull(messages.hello_13_ == "fakeMessage");
            Assert.IsNotNull(messages.enterCpuStrategy_14_ == "fakeMessage");
            Assert.IsNotNull(messages.firstVar_15_ == "fakeMessage");
            Assert.IsNotNull(messages.secondVar_16_ == "fakeMessage");
            Assert.IsNotNull(messages.trumpCardIs_17_ == "fakeMessage");
            Assert.IsNotNull(messages.yourTurn_18_ == "fakeMessage");
            Assert.IsNotNull(messages.cardsInCpuHands_20_ == "fakeMessage");
            Assert.IsNotNull(messages.thereIs_19_ == "fakeMessage");
            Assert.IsNotNull(messages.cardsInDeck_21_ == "fakeMessage");
            Assert.IsNotNull(messages.turnChanges_22_ == "fakeMessage");
            Assert.IsNotNull(messages.cpuTurn_23_ == "fakeMessage");
            Assert.IsNotNull(messages.drawThisTime_24_ == "fakeMessage");
            Assert.IsNotNull(messages.congratulations_25_ == "fakeMessage");
            Assert.IsNotNull(messages.youAreWinner_26_ == "fakeMessage");
            Assert.IsNotNull(messages.youLoseThisGame_27_ == "fakeMessage");
            Assert.IsNotNull(messages.press_28_ == "fakeMessage");
            Assert.IsNotNull(messages.toStartAgain_29_ == "fakeMessage");
            Assert.IsNotNull(messages.cpuHasNoAttackCard_30_ == "fakeMessage");
            Assert.IsNotNull(messages.cpuAttackedYouWith_31_ == "fakeMessage");
            Assert.IsNotNull(messages.cpuBeatWith_32_ == "fakeMessage");
            Assert.IsNotNull(messages.cpuHasNoDefendCard_33_ == "fakeMessage");
        }

        [TestMethod]
        public void MessageTestShouldThrowException()
        {
            //Assign
            //Act
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Messages(null));
        }
    }
}
