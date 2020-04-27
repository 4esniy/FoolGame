using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Durak;
using Durak.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;

namespace DurakTest
{
    /// <summary>
    /// Summary description for ReadLanguageConfigurationTest
    /// </summary>
    [TestClass]
    public class LanguageConfigurationReaderTest
    {

        [TestMethod]
        public void ConstructorTest()
        {
            //arrange
            //act
            //assert
        }


        [TestMethod]
        public void GetTextFromConfigurationTestInputIsNotNull()
        {
            //arrange
            const int languageType = 1;
            const string fakestring = null;
            Exception ex = null;
            var readerFactory = new Mock<IReaderFactory>();
            //act
            try
            {
                var configuration = new LanguageDataProvider(readerFactory.Object);
                configuration.GetTextFromConfiguration(fakestring);
            }
            catch (Exception e)
            {
                ex = e;
                
            }
            //assert
            Assert.IsNotNull(ex);
        }

        //[TestMethod]
        //public void GetTextFromConfigurationTestOutputIsNotNull()
        //{
        //    //arrange
        //    string actualValue = null;
        //    const string fakeKey = "fakeKey";
        //    var readerFactory = new Mock<IReaderFactory>();
        //    Dictionary<string, string> _textCollection = new Dictionary<string, string>();
        //    _textCollection.Add("fakeKey", "fakeValue");
        //    var configuration = new LanguageDataProvider(readerFactory.Object) {textCollection = _textCollection};
        //    //act
        //    actualValue = configuration.GetTextFromConfiguration(fakeKey);

        //    //assert
        //    Assert.IsTrue(actualValue == "fakeValue");
        //}
    }
}
