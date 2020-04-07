using System;
using Durak;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace DurakTest
{
    [TestClass]
    public class HumanStrategyTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AttackTest()
        {
            int lanugaeType = 1;
            var humanStrategy = new HumanStrategy(lanugaeType);
            //var deck = new Deck();


    
        }
    }
}
