using System;
using System.Text;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Durak;
using Durak.Interfaces;

namespace DurakTest
{
    /// <summary>
    /// Summary description for ReaderFactoryTest
    /// </summary>
    [TestClass]
    public class ReaderFactoryTest
    {
        [TestMethod]
        public void IsXmlReaderCreated()
        {
            //Assign
            var languageType = 1;
            var readerFactory = new ReaderFactory(languageType);
            IDataReader _dataReader;

            //Act
            _dataReader = readerFactory.ReadFromXml();
            //Assert
            Assert.IsNotNull(_dataReader.TextCollection);
        }
    }
}
