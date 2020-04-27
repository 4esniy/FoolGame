using System;
using System.Text;
using System.Collections.Generic;
using Durak;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Durak;
using Durak.Interfaces;
using Durak.TextClasses;

namespace DurakTest
{
    
    [TestClass]
    public class MessageTest
    {
        public void PropertyWasSet()
        {
            //Assign
            var mockConfiguration = new Mock<ILanguageDataProvider>();
            mockConfiguration.Setup(x => x.GetTextFromConfiguration(""))
                .Returns("fakeMessage");
            //Act
            var messages = new Messages(mockConfiguration.Object);
            //Assert
            Assert.IsNotNull(messages.cardOnTableAre_2_ == "fakeMessage");
            }
    }
}
