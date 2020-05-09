using Durak;
using Durak.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DurakTest
{
    [TestClass]
    public class DeckBuilderTests
    {
        private readonly Mock<ICardAttributesConverter> cardAttributesProviderMock;
        private readonly string[] _names = { "Six", "Seven", "Ace" };
        private readonly string[] _suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        private Exception _ex = null;
        private readonly DeckBuilder _deckBuilder;


        public DeckBuilderTests()
        {
            cardAttributesProviderMock = new Mock<ICardAttributesConverter>();
            cardAttributesProviderMock.Setup(x => x.Names).Returns(_names);
            cardAttributesProviderMock.Setup(x => x.Suits).Returns(_suits);
            _deckBuilder = new DeckBuilder(cardAttributesProviderMock.Object);
        }

        [TestMethod]
        public void DeckBuilderTestPropertiesShouldBeSet()
        {
            // ARRANGE
            // ACT
            //Assert
            Assert.AreEqual(_names, _deckBuilder.names);
            Assert.AreEqual(_suits, _deckBuilder.suits);
        }

        [TestMethod]
        public void DeckBuilderTestShouldThrowException()
        {
            // ARRANGE
            // ACT
            try
            {
                var builder = new DeckBuilder(null);
            }
            catch (Exception e)
            {
                _ex = e;
            }
            //Assert
            Assert.IsNotNull(_ex);
        }

        [TestMethod]
        public void DeckBuilderTestCardShouldBeCreated()
        {
            // ARRANGE
            // ACT
            Card Card = _deckBuilder.CreateCard(1, "name", "suit", true);
            //Assert
            Assert.IsTrue(Card.Trump);
        }

        [TestMethod]
        public void DeckBuilderTestDeckShouldBeCreated()
        {
            // ARRANGE

            // ACT
            List<Card> i = _deckBuilder.CreateDeck();
            //Assert
            Assert.IsTrue(i.Count > 0);
        }
    }
}
