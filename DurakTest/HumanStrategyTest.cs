using System;
using Durak;
using Durak.Interfaces;
using Durak.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DurakTest
{
    /// <summary>
    /// Summary description for HumanStrategyTest
    /// </summary>
    [TestClass]
    public class HumanStrategyTest
    {

        private Mock<IConfigurationSetter> _configurationSetter { get; }
        private Mock<IConsoleReadWrap> _consoleRead { get; }
        private IStrategy _humanStrategy { get; }
        private List<Card> CardListOnHands { get; }
        private List<Card> CardListOnTable { get; }
        private Card CardToBeat { get; }
        private Card CardToBeatTrumpTrue { get; }


        public HumanStrategyTest()
        {
            var input = "1";
            _configurationSetter = new Mock<IConfigurationSetter>();
            _configurationSetter
                .Setup(x => x.Message.chooseAttackCard_3_)
                .Returns("");
            _configurationSetter
                .Setup(x => x.Message.youCannotUseCard_5_)
                .Returns("");
            _consoleRead = new Mock<IConsoleReadWrap>();
            _consoleRead
                .Setup(x => x.ConsoleReadLine())
                .Returns(input);
            _humanStrategy = new HumanStrategy(_configurationSetter.Object, _consoleRead.Object);
            CardToBeat = new Card(1, "", "", false);
            CardToBeatTrumpTrue = new Card(1, "", "", true);
            CardListOnHands = new List<Card>
            {
                new Card(1, "", "", true),
                new Card(2, "", "", false),
                new Card(8, "", "", true),
                new Card(9, "", "", true)
            };
            CardListOnTable = new List<Card>
            {
                new Card(1, "", "", false),
                new Card(2, "", "", false),
                new Card(1, "", "", false),
                new Card(1, "", "", true)
            };
        }

        [TestMethod]
        public void HumanStrategyPossibleAttackCardsShouldReturnListOfCards()
        {
            //Arrange
            //Act
            List<Card> actualCards = _humanStrategy.PossibleAttackCards(CardListOnHands, CardListOnTable);
            //Assert
            Assert.AreEqual(actualCards[0], CardListOnHands[0]);
            Assert.AreEqual(actualCards.Count, 2);
        }

        [TestMethod]
        public void HumanStrategyPossibleDefendCardsShouldReturnListOfCards()
        {
            //Arrange
            //Act
            List<Card> actualCards = _humanStrategy.PossibleDefendCards(CardListOnHands, CardToBeat);
            List<Card> actualCards2 = _humanStrategy.PossibleDefendCards(CardListOnHands, CardToBeatTrumpTrue);
            //Assert
            Assert.AreEqual(actualCards[0], CardListOnHands[0]);
            Assert.AreEqual(actualCards.Count, 4);
            Assert.AreEqual(actualCards2.Count, 2);
        }

        [TestMethod]
        public void HumanStrategyChooseMinRankCardReturnNull()
        {
            //Arrange
            //Act
            Card tempCard = _humanStrategy.ChooseMinRankCard(CardListOnHands, true);
            //Assert
            Assert.IsNull(tempCard);
        }

        [TestMethod]
        public void HumanStrategyAttackShouldReturnCard()
        {
            //Arrange
            //Act
            Card tempCard = _humanStrategy.Attack(CardListOnHands, CardListOnTable);
            //Assert
            Assert.AreEqual(CardListOnHands[0], tempCard);
        }

        [TestMethod]
        public void HumanStrategyDefendShouldReturnCard()
        {
            //Arrange
            //Act
            Card tempCard = _humanStrategy.Defend(CardListOnTable, CardListOnHands, CardToBeat);
            //Assert
            Assert.AreEqual( CardListOnHands[0],tempCard);
        }
    }
}
