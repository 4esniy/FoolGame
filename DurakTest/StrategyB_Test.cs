using Durak;
using Durak.Interfaces;
using Durak.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DurakTest
{
    /// <summary>
    /// Summary description for StrategyB_Test
    /// </summary>
    [TestClass]
    public class StrategyB_Test
    {

        private Mock<IConfigurationSetter> ConfigurationSetter { get; }
        private Mock<IConsoleReadWrap> ConsoleReadMock { get; }
        private IStrategy StrategyB { get; }
        private List<Card> CardListOnHands { get; }
        private List<Card> CardListOnTable { get; }
        private Card CardToBeat { get; }
        private Card CardToBeatTrumpTrue { get; }


        public StrategyB_Test()
        {
            var input = "1";
            ConfigurationSetter = new Mock<IConfigurationSetter>();
            ConfigurationSetter
                .Setup(x => x.Message.chooseAttackCard_3_)
                .Returns("");
            ConfigurationSetter
                .Setup(x => x.Message.youCannotUseCard_5_)
                .Returns("");

            ConsoleReadMock = new Mock<IConsoleReadWrap>();
            ConsoleReadMock
                .Setup(x => x.ConsoleReadKey());
           
            StrategyB = new StrategyB(ConfigurationSetter.Object, ConsoleReadMock.Object);
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
        public void StrategyB_PossibleAttackCardsShouldReturnListOfCards()
        {
            //Arrange
            //Act
            List<Card> actualCards = StrategyB.PossibleAttackCards(CardListOnHands, CardListOnTable);
            //Assert
            Assert.AreEqual(actualCards[0], CardListOnHands[0]);
            Assert.AreEqual(actualCards.Count, 2);
        }

        [TestMethod]
        public void StrategyB_PossibleDefendCardsShouldReturnListOfCards()
        {
            //Arrange
            //Act
            List<Card> actualCards = StrategyB.PossibleDefendCards(CardListOnHands, CardToBeat);
            List<Card> actualCards2 = StrategyB.PossibleDefendCards(CardListOnHands, CardToBeatTrumpTrue);
            //Assert
            Assert.AreEqual(actualCards[0], CardListOnHands[0]);
            Assert.AreEqual(actualCards.Count, 4);
            Assert.AreEqual(actualCards2.Count, 2);
        }

        [TestMethod]
        public void StrategyBChooseMinRankCardReturnNull()
        {
            //Arrange
            //Act
            Card actualCard = StrategyB.ChooseMinRankCard(CardListOnHands, true);
            //Assert
            Assert.AreEqual(CardListOnHands[0], actualCard);
        }

        [TestMethod]
        public void StrategyB_AttackShouldReturnCard()
        {
            //Arrange
            //Act
            Card tempCard = StrategyB.Attack(CardListOnHands, CardListOnTable);
            //Assert
            Assert.AreEqual(CardListOnHands[1], tempCard);
        }

        [TestMethod]
        public void StrategyB_DefendShouldReturnCardIfCardToBeatTrumpNotTrue()
        {
            //Arrange
            //Act
            Card tempCard = StrategyB.Defend(CardListOnTable, CardListOnHands, CardToBeat);
            //Assert
            Assert.AreEqual(CardListOnHands[1], tempCard);
        }

        [TestMethod]
        public void StrategyB_DefendShouldReturnCardIfCardToBeatTrumpTrue()
        {
            //Arrange
            //Act
            Card tempCard = StrategyB.Defend(CardListOnTable, CardListOnHands, CardToBeatTrumpTrue);
            //Assert
            Assert.AreEqual(CardListOnHands[2], tempCard);
        }
    }
}

