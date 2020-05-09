using System;
using Durak;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Durak.Interfaces;

namespace DurakTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ManualInputProviderTest
    {
        public ManualInputProviderTest()
        {

        }


        [TestMethod]
        public void ManualInputProviderShouldSetProperties()
        {
            //Arrange
            var expectedMessage = "fakeMessage";
            var consoleReaderMock = new Mock<IConsoleReadWrap>();
            consoleReaderMock.Setup(x => x.ReadAppSettings()).Returns("fakeMessage");
            consoleReaderMock.Setup(x => x.ConsoleReadLine()).Returns("1");
            //Act
            var manualInput = new ManualInputProvider(consoleReaderMock.Object);
            //Assert
            Assert.IsNotNull(manualInput._consoleReadWrap);
            Assert.AreEqual(expectedMessage, manualInput.message);
        }


        [TestMethod]
        public void ManualInputProviderTestReturnLanguageTypeInputValueShouldReturn_1_or_2()
        {
            //Arrange
            var expectedValue = 2;
            var consoleReaderMock = new Mock<IConsoleReadWrap>();
            consoleReaderMock.Setup(x => x.ConsoleReadLine()).Returns("2");
            //Act
            var manualInput = new ManualInputProvider(consoleReaderMock.Object);

            //Assert
            Assert.AreEqual(expectedValue, manualInput.ReturnLanguageTypeInputValue());
        }
    }
}
