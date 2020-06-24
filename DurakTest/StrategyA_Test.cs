using Durak;
using Durak.Interfaces;
using Durak.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DurakTest
{
    /// <summary>
    /// Summary description for StrategyA_Test
    /// </summary>
    [TestClass]
    public class StrategyA_Test
    {

        private Mock<IConfigurationSetter> ConfigurationSetter { get; }
        private Mock<IConsoleReadWrap> ConsoleReadMock { get; }
        private IStrategy StrategyA { get; }
        private List<Card> CardListOnHands { get; }
        private List<Card> CardListOnTable { get; }
        private Card CardToBeat { get; }
        private Card CardToBeatTrumpTrue { get; }


        public StrategyA_Test()
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
           
            StrategyA = new StrategyA(ConfigurationSetter.Object, ConsoleReadMock.Object);
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
        public void StrategyA_PossibleAttackCardsShouldReturnListOfCards()
        {
            //Arrange
            //Act
            List<Card> actualCards = StrategyA.PossibleAttackCards(CardListOnHands, CardListOnTable);
            //Assert
            Assert.AreEqual(actualCards[0], CardListOnHands[0]);
            Assert.AreEqual(actualCards.Count, 2);
        }

        [TestMethod]
        public void StrategyA_PossibleDefendCardsShouldReturnListOfCards()
        {
            //Arrange
            //Act
            List<Card> actualCards = StrategyA.PossibleDefendCards(CardListOnHands, CardToBeat);
            List<Card> actualCards2 = StrategyA.PossibleDefendCards(CardListOnHands, CardToBeatTrumpTrue);
            //Assert
            Assert.AreEqual(actualCards[0], CardListOnHands[0]);
            Assert.AreEqual(actualCards.Count, 4);
            Assert.AreEqual(actualCards2.Count, 2);
        }

        [TestMethod]
        public void StrategyAChooseMinRankCardReturnNull()
        {
            //Arrange
            //Act
            Card actualCard = StrategyA.ChooseMinRankCard(CardListOnHands, true);
            //Assert
            Assert.AreEqual(CardListOnHands[0], actualCard);
        }

        [TestMethod]
        public void StrategyA_AttackShouldReturnCard()
        {
            //Arrange
            //Act
            Card tempCard = StrategyA.Attack(CardListOnHands, CardListOnTable);
            //Assert
            Assert.AreEqual(CardListOnHands[1], tempCard);
        }

        [TestMethod]
        public void StrategyA_DefendShouldReturnCardIfCardToBeatTrumpNotTrue()
        {
            //Arrange
            //Act
            Card tempCard = StrategyA.Defend(CardListOnTable, CardListOnHands, CardToBeat);
            //Assert
            Assert.AreEqual(CardListOnHands[1], tempCard);
        }

        [TestMethod]
        public void StrategyA_DefendShouldReturnCardIfCardToBeatTrumpTrue()
        {
            //Arrange
            //Act
            Card tempCard = StrategyA.Defend(CardListOnTable, CardListOnHands, CardToBeatTrumpTrue);
            //Assert
            Assert.AreEqual(CardListOnHands[2], tempCard);
        }
    }
}

