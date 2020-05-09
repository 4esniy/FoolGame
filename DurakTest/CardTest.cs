using Durak;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DurakTest
{
    [TestClass]

    public class CardTest
    {
        private int rank = 1;
        private string name = "Valet";
        private string suit = "Clubs";
        private bool trumpTrue = false;
        private bool trumpFalse = false;

        [TestMethod]
        public void CotrTest()
        {
            //Arrange
            Card expectedCard = new Card(rank, name, suit, trumpTrue);
            //Act

            //Assert
            Assert.AreEqual(rank, expectedCard.Rank);
            Assert.AreEqual(name, expectedCard.Name);
            Assert.AreEqual(suit, expectedCard.Suit);
            Assert.AreEqual(trumpTrue, expectedCard.Trump);
            
        }

        [TestMethod]
        public void CotrTestNameIsNotNull()
        {
            //Arrange
            Exception ex=null;
            //Act
            try
            {
                Card expectedCard = new Card(rank, null, suit, trumpTrue);
            }
            catch (Exception e)
            {
                ex = e;
            }
            //Assert
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void ShowTest()
        {
            //Arrange
            var expectedCard = new Card(rank, name, suit, trumpTrue);
            var message = trumpTrue ? $"{name}, {suit.ToUpper()}" : $"{name}, {suit}";
            //Act
            //Assert
            Assert.AreEqual(message, expectedCard.Show());
        }
    }
}
