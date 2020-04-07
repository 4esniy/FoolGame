using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Durak;
using Rhino.Mocks;

namespace DurakTest
{
    /// <summary>
    /// Summary description for CardTest
    /// </summary>
    [TestClass]
    public class CardTests
    {

        [TestMethod]
        public void CardTest()
        {
            // arrange
            var Rank = MockRepository.GenerateStub<IMessages>();
            var Name = MockRepository.GenerateStub<IMessages>();
            var Suit = MockRepository.GenerateStub<IMessages>();
            var Trump = MockRepository.GenerateStub<IMessages>();

            // act
            var TestCard = new Card(Rank, Name , Suit, Trump);
            
            // assert
            Assert.IsNotNull(TestCard);
        }
    }
}
