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
        public void PropertyWasSet()
        {
            //Assign
            var mockConfiguration = new Mock<ILanguageDataProvider>();
            mockConfiguration.Setup(x => x.GetTextFromConfiguration(""))
                .Returns("fakeMessage");

            //Act
            var defaultConsts = new DefaultConstants(mockConfiguration.Object);

            //Assert
            Assert.IsNotNull(defaultConsts.WantToContinue_7_ == "fakeMessage");
        }
    }
}
