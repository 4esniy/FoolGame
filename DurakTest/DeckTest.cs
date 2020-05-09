using System;
using System.Collections.Generic;
using Durak;
using Durak.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DurakTest
{
    /// <summary>
    /// Summary description for DeckTest
    /// </summary>
    [TestClass]
    public class DeckTest
    {
        [TestMethod]

        public void DeckTestCtorShouldSetProperty()
        {
            // ARRANGE

            var deckBuilder = new Mock<IDeckBuilder>();
            deckBuilder.Setup(x => x.CreateDeck())
                                                                        .Returns(new List<Card>());
            // ACT
            var deck = new Deck(deckBuilder.Object);
            // ASSERT
            Assert.IsNotNull(deck._deckOfCards);
        }

        [TestMethod]
        public void DeckTestCtorShouldThrowExcIfInputNull()
        {
            // ARRANGE
            Exception ex = null;
            // ACT
            try
            {
                var deck = new Deck(null);
            }
            catch (Exception e)
            {
                ex = e;
            }
            // ASSERT
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void GiveCardFromDeckShouldAddCardOnHands()
        {
            //Arrange
            List<Card> deckOfCards = new List<Card>
            {
                new Card(1, "name", "suit", true),
                new Card(1, "name", "suit", true),
                new Card(1, "name", "suit", true),
            };

            var deckBuilderMock = new Mock<IDeckBuilder>();
            var playerMock = new Mock<IPlayer>();

            deckBuilderMock
                .Setup(x => x.CreateDeck())
                .Returns(deckOfCards);
            
            playerMock
                .Setup(x => x.AddCardToHands(It.IsAny<Card>()));

            var deck = new Deck(deckBuilderMock.Object);
            //Act
            deck.GiveCardFromDeck(1, playerMock.Object);
            playerMock.Verify(x => x.AddCardToHands(It.IsAny<Card>()), Times.Once());
            //Assert
            Assert.AreEqual(2, deckOfCards.Count);
        }


        [TestMethod]
        public void DeckTestShowTrumpCardShouldShowTrumpSuit()
        {
            // ARRANGE
            List<Card> deckOfCards = new List<Card>()
            {
                new Card(1, "name", "suit", false),
                new Card(1, "name", "suit", false),
                new Card(1, "name", "TrumpSuit", true),
            };
            // ACT
            var deckBuilderMock = new Mock<IDeckBuilder>();
            deckBuilderMock.Setup(x => x.CreateDeck())
                .Returns(deckOfCards);
            var deck = new Deck(deckBuilderMock.Object);
            var TrumpSuit = deck.ShowTrumpCard();
            // ASSERT
            Assert.AreEqual("TrumpSuit",TrumpSuit);
        }

        [TestMethod]
        public void TestHowManyCardsInDeckMethod()
        {
            // ARRANGE
            List<Card> dummyDeck = new List<Card> { new Card(1, "Six", "Spades", true) };

            var deckBuilder = new Mock<IDeckBuilder>();
            deckBuilder.Setup(x => x.CreateDeck())
                .Returns(dummyDeck);
            // ACT
            var deck = new Deck(deckBuilder.Object);
            var number = deck.HowManyCardsInDeck();
            // ASSERT
            Assert.IsTrue(number > 0);
        }
    }


}
