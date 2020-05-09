using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Durak;
using Durak.Interfaces;
using Durak.TextClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DurakTest
{
    /// <summary>
    /// Summary description for AlertTest
    /// </summary>
    [TestClass]
    public class AlertTest
    {
        [TestMethod]
        public void AlertTestPropertyShouldBeSet()
        {
            //Assign
            var mockConfiguration = new Mock<ILanguageDataProvider>();
            mockConfiguration.Setup(x => x.GetTextFromConfiguration(""))
                .Returns("fakeMessage");
            //Act
            var alert = new Alerts(mockConfiguration.Object);
            //Assert
            Assert.IsNotNull(alert.enterInteger_1_ == "fakeMessage");
            Assert.IsNotNull(alert.enterNotBiggerThan_2_ == "fakeMessage");
            Assert.IsNotNull(alert.enterNotLessThan10_4_ == "fakeMessage");
            Assert.IsNotNull(alert.enterPositiveNumber_3_ == "fakeMessage");
            Assert.IsNotNull(alert.noSuchStrategy_6_== "fakeMessage");
            Assert.IsNotNull(alert.userNameNotEmpty_5_== "fakeMessage");
        }

        [TestMethod]
        public void AlertTestShouldThrowException()
        {
            //Assign
            //Act
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Alerts(null));
        }
    }
}
