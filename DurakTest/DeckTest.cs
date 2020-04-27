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

        public void TestConstructor()
        {
            // ARRANGE
            
            var deckBuilder = new Mock<IDeckBuilder>();
            deckBuilder.Setup(x => x.CreateDeck())
                                                                        .Returns(new List<Card>());
            // ACT
            var deck = new Deck(deckBuilder.Object);
            // ASSERT
            Assert.IsTrue(deck._deckOfCards != null);
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
