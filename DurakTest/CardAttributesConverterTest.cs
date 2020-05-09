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
    public class CardAttributesConverterTest
    {

        [TestMethod]
        public void CardAttributesConverterTestPropertiesShouldBeConverted()
        {
            //Assign
            string fakeString = "fakeName,fakeSuit";
            string[] fakeValue = { "fakeName", "fakeSuit" };
            var mockConfiguration = new Mock<ILanguageDataProvider>();
            mockConfiguration.Setup(x => x.GetTextFromConfiguration(It.IsAny<string>()))
               .Returns(fakeString);

            //Act
            var attributes = new CardAttributesConverter(mockConfiguration.Object);
            var names = attributes.Names;
            var suits = attributes.Suits;
            //Assert
            Assert.AreEqual(fakeValue.GetLength(0), names.GetLength(0));
            Assert.AreEqual(fakeValue.GetLength(0), suits.GetLength(0));
        }

        [TestMethod]
        public void CardAttributesConverterTestInputShouldNotBeNull()
        {
            //Assign
            Exception ex = null;
            //Act
            try
            {
                var attributes = new CardAttributesConverter(null);
            }
            catch (Exception e)
            {
                ex = e;
            }
            //Assert
            Assert.IsNotNull(ex);
        }
    }
}
