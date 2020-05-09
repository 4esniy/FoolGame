using System;
using System.Collections.Generic;
using Durak;
using Durak.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DurakTest
{
    [TestClass]
    public class PlayerTest
    {
        private Mock<IConfigurationSetter> ConfigurationMock { get; }
        private Mock<IStrategy> StrategyMock { get; }
        private List<Card> CardList { get; }
        public Card ExpectedCard { get; }
        private Player _player { get; }


        public PlayerTest()
        {
            ConfigurationMock = new Mock<IConfigurationSetter>();
            StrategyMock = new Mock<IStrategy>();
            ExpectedCard = new Card(1, "fakeName", "fakeSuit", true);
            CardList = new List<Card>
            {
            new Card(1, "", "", true),
            new Card(1, "", "", true),
            new Card(1, "", "", true)
            };

            ConfigurationMock
                .Setup(x => x.Constant.numberOfCards_1_)
                .Returns(6);

            ConfigurationMock
                .Setup(x => x.Message.yourCardsAre_1_)
                .Returns(It.IsAny<string>());

            StrategyMock
                .Setup(x => x.Attack(CardList, CardList))
                .Returns(ExpectedCard);

            StrategyMock
                .Setup(x => x.PossibleAttackCards(CardList, CardList))
                .Returns(CardList);

            StrategyMock
                .Setup(x => x.Defend(CardList, CardList, ExpectedCard))
                .Returns(new Card(1, "fakeName", "fakeSuit", true));

            _player = new Player(ConfigurationMock.Object, StrategyMock.Object);
        }


        [TestMethod]
        public void PlayerPropertiesShouldBeSet()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsNotNull(_player.CardsOnHands);
            Assert.IsNotNull(_player.Strategy);
            Assert.IsNotNull(_player.Message);
            Assert.IsNotNull(_player.Constant);
            Assert.IsNotNull(_player.MinCards);
        }

        [TestMethod]
        public void PlayerAttackShouldReturnCard()
        {
            //Arrange
            //Act
            Card actualCard = _player.Attack(CardList);
            StrategyMock.Verify(x => x.Attack(CardList, CardList), Times.Exactly(1));
            //Assert
            Assert.AreEqual(ExpectedCard, actualCard);
        }

        [TestMethod]
        public void PlayerDefendShouldReturnCard()
        {
            //Arrange
            //Act
            Card actualCard = _player.Defend(CardList, ExpectedCard);
            StrategyMock.Verify(x => x.Defend(CardList, CardList, ExpectedCard), Times.Exactly(1));
            //Assert
            Assert.AreEqual(ExpectedCard, actualCard);
        }

        [TestMethod]
        public void PlayerShouldAddCardOnHands()
        {
            //Arrange
            //Act
            _player.AddCardToHands(ExpectedCard);
            //Assert
            Assert.IsTrue(_player.CardsOnHands.Count == 1);
        }

        [TestMethod]
        public void PlayerShouldRemoveCardFromCardOnHands()
        {
            //Arrange
            //Act
            _player.AddCardToHands(ExpectedCard);
            _player.RemoveCardFromHands(ExpectedCard);
            //Assert
            Assert.IsTrue(_player.CardsOnHands.Count == 0);
        }

        [TestMethod]
        public void PlayerShouldShowCardsOnHands()
        {
            //Arrange
            Exception ex = null;
            //Act
            _player.AddCardToHands(ExpectedCard);
            try
            {
                _player.ShowOnHands();
            }
            catch (Exception e)
            {
                ex = e;
            }
            //Assert
            Assert.IsNull(ex);
        }

        [TestMethod]
        public void PlayerShouldShowHowManyCardsOnHands()
        {
            //Arrange
            //Act
            _player.AddCardToHands(ExpectedCard);
            int numberCards = _player.HowManyCardsOnHands();
            //Assert
            Assert.IsTrue(numberCards.Equals(1));
        }

        [TestMethod]
        public void PlayerShouldShowHowManyCardsToTake()
        {
            //Arrange
            //Actvar player = new Player(Configuration.Object, Strategy.Object);
            _player.AddCardToHands(ExpectedCard);
            int numberCardsToTake = _player.CardsToTake();
            //Assert
            Assert.IsTrue(numberCardsToTake.Equals(5));
        }

        [TestMethod]
        public void PlayerShouldReturnZeroHowManyCardsToTakeWhenMoreThanMinimumCards()
        {
            //Arrange
            //Act
            _player.AddCardToHands(ExpectedCard);
            _player.AddCardToHands(ExpectedCard);
            _player.AddCardToHands(ExpectedCard);
            _player.AddCardToHands(ExpectedCard);
            _player.AddCardToHands(ExpectedCard);
            _player.AddCardToHands(ExpectedCard);
            int numberCardsToTake = _player.CardsToTake();
            //Assert
            Assert.IsTrue(numberCardsToTake.Equals(0));
        }
    }
}
