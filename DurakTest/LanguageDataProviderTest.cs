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
    public class LanguageDataProviderTest
    {
        private readonly Mock<IReaderFactory> _factory;
        private readonly Dictionary<string, string> _dictionary;
        private readonly Dictionary<string, string> _emptyDictionary;
        private LanguageDataProvider _languageDataProvider;
        private Exception _ex;

        public LanguageDataProviderTest()
        {
            _factory = new Mock<IReaderFactory>();
            _dictionary = new Dictionary<string, string>
            {
                {"key1", "value1"},
                {"key2", "value2"},
                {"key3", "value3"},
            };
            _emptyDictionary = new Dictionary<string, string>();
            _ex = new Exception();
            
        }

        [TestMethod]
        public void LanguageDataProviderTestPropertyShouldBeSetFromXML()
        {
            //arrange
            _factory.Setup(x => x.ReadFromXml().Read()).Returns(_dictionary);
            //act
            _languageDataProvider = new LanguageDataProvider(_factory.Object);
            //assert
            Assert.IsTrue(_languageDataProvider.TextCollection.Count.Equals(3));
        }

        [TestMethod]
        public void LanguageDataProviderTestPropertyShouldBeSetFromDB()
        {
            //arrange
            _factory.Setup(x => x.ReadFromXml().Read()).Throws(_ex);
            _factory.Setup(x => x.ReadFromDb().Read()).Returns(_dictionary);
            //act
            _languageDataProvider = new LanguageDataProvider(_factory.Object);
            //assert
            Assert.IsTrue(_languageDataProvider.TextCollection.Count.Equals(3));
        }

        [TestMethod]
        public void LanguageDataProviderTestAnyExceptionShouldBeCatched()
        {
            //arrange
            _factory.Setup(x => x.ReadFromXml().Read()).Throws(_ex);
            _factory.Setup(x => x.ReadFromDb().Read()).Throws(_ex);
            //act
            //assert
            Assert.ThrowsException<Exception>(() => new LanguageDataProvider(_factory.Object));
            
        }

        [TestMethod]
        public void LanguageDataProviderGetTextFromConfigurationShouldReturnValueFromCollection()
        {
            //arrange
            _factory.Setup(x => x.ReadFromXml().Read()).Returns(_dictionary);
            _languageDataProvider = new LanguageDataProvider(_factory.Object);
            //act
            string temp =_languageDataProvider.GetTextFromConfiguration("key2");
            //assert
            Assert.IsTrue(temp.Equals("value2"));
        }

        [TestMethod]
        public void LanguageDataProviderGetTextFromConfigurationShouldThrowException()
        {
            //arrange
            _factory.Setup(x => x.ReadFromXml().Read()).Returns(_dictionary);
            _languageDataProvider = new LanguageDataProvider(_factory.Object);
            //act
            //assert
            Assert.ThrowsException<ArgumentException>(() => _languageDataProvider.GetTextFromConfiguration("wrongKey"));
        }


    }
}
