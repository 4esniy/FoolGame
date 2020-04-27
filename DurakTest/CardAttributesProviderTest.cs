using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Durak;
using Durak.Interfaces;
using Durak.TextClasses;
using Moq;

namespace DurakTest
{
    /// <summary>
    /// Summary description for CardAttributesProviderTest
    /// </summary>
    [TestClass]
    public class CardAttributesProviderTest
    {
        
        [TestMethod]
        public void PropertyWasSet()
        {
            //Assign
            string names = "fakeName,fakeName";
                var mockConfiguration = new Mock<ILanguageDataProvider>();
            mockConfiguration.Setup(x => x.GetTextFromConfiguration(""))
                .Returns(names);

            //Act
            var attributes = new CardAttributesConverter(mockConfiguration.Object);

            //Assert
            Assert.IsNotNull(attributes.Names);
            }
    }
}
