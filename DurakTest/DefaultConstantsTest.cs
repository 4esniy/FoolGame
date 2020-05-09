using System;
using System.Text;
using System.Collections.Generic;
using Durak;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Durak.TextClasses;
using Durak.Interfaces;

namespace DurakTest
{
    /// <summary>
    /// Summary description for DefaultConstants
    /// </summary>
    [TestClass]
    public class DefaultConstantsTest
    {
        [TestMethod]
        public void DefaultConstantsTestStringPropertyShouldBeSet()
        {
            //Assign
            var mockConfiguration = new Mock<ILanguageDataProvider>();
            mockConfiguration.Setup(x => x.GetTextFromConfiguration(It.IsAny<string>()))
                .Returns("fakeMessage");
            //Act
            var defaultConsts = new DefaultConstants(mockConfiguration.Object);
            //Assert
            Assert.IsNotNull(defaultConsts.strategy_1_4_ == "fakeMessage");
            Assert.IsNotNull(defaultConsts.strategy_2_5_ == "fakeMessage");
            Assert.IsNotNull(defaultConsts.strategy_Human_6_ == "fakeMessage");
            Assert.IsNotNull(defaultConsts.WantToContinue_7_ == "fakeMessage");
        }

        [TestMethod]
        public void DefaultConstantsTestIntPropertyShouldBeNotZero()
        {
            //Assign
            var mockConfiguration = new Mock<ILanguageDataProvider>();
            mockConfiguration.Setup(x => x.GetTextFromConfiguration(It.IsAny<string>()))
                .Returns("1");
            //Act
            var defaultConsts = new DefaultConstants(mockConfiguration.Object);
            //Assert
            Assert.IsTrue(defaultConsts.numberOfCards_1_ != 0);
        }


        [TestMethod]
        public void DefaultConstantsTestShouldThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new DefaultConstants(null));
        }
    }
}
