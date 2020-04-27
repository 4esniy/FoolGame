using System;
using System.Text;
using System.Collections.Generic;
using Durak;
using Durak.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Durak.Properties;

namespace DurakTest
{
    /// <summary>
    /// Summary description for DeckTests
    /// </summary>
    [TestClass]
    public class DeckBuilderTests
    {
        [TestMethod]
        public void DeckBuilderConstructorTestNamesIsNotNull()
        {
            // ARRANGE
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            Exception ex = null;
            var mockCardAttributesProvider = new Mock<ICardAttributesConverter>();
            mockCardAttributesProvider.SetupAllProperties();
            mockCardAttributesProvider.Object.Names = null;
            mockCardAttributesProvider.Object.Suits = suits;
            // ACT
            try
            {
                var deckBuilder = new DeckBuilder(mockCardAttributesProvider.Object);
            }
            catch (ArgumentNullException e)
            {
                ex = e;
            }
            //Assert
            Assert.IsNotNull(ex);
            
        }

        [TestMethod]
        public void DeckBuilderConstructorTestSuitsIsNotNull()
        {
            // ARRANGE
            string[] names = { "Six", "Seven", "Ace" };
            Exception ex = null;
            var mockCardAttributesProvider = new Mock<ICardAttributesConverter>();
            mockCardAttributesProvider.SetupAllProperties();
            mockCardAttributesProvider.Object.Names = names;
            mockCardAttributesProvider.Object.Suits = null;
            // ACT
            try
            {
                var deckBuilder = new DeckBuilder(mockCardAttributesProvider.Object);
            }
            catch (ArgumentNullException e)
            {
                ex = e;
            }
            //Assert
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void DeckBuilderCreateDeckTestDeckIsNotEmpty()
        {
            // ARRANGE
            string[] names = { "Six", "Seven", "Ace" };
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            var mockCardAttributesProvider = new Mock<ICardAttributesConverter>();
            mockCardAttributesProvider.SetupAllProperties();
            mockCardAttributesProvider.Object.Names = names;
            mockCardAttributesProvider.Object.Suits = suits;
            // ACT
                var deckBuilder = new DeckBuilder(mockCardAttributesProvider.Object);
                List<Card> i = deckBuilder.CreateDeck();
            //Assert
            Assert.IsTrue(i.Count > 0);
        }

        [TestMethod]
        public void DeckBuilderCreateCardTest()
        {
            // ARRANGE
            string[] names = { "Six", "Seven", "Ace" };
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            ArgumentNullException ex = null;
            var mockCardAttributesProvider = new Mock<ICardAttributesConverter>();
            mockCardAttributesProvider.SetupAllProperties();
            mockCardAttributesProvider.Object.Names = names;
            mockCardAttributesProvider.Object.Suits = suits;
            // ACT
            var deckBuilder = new DeckBuilder(mockCardAttributesProvider.Object);
            ////Assert
            Assert.ThrowsException<ArgumentNullException>(() => deckBuilder.CreateCard(0, null, "Clubs", true));
        }

    }
}
