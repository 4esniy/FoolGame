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
        public void ReaderFactoryTestShouldCreateXMLReader()
        {
            //Assign
            var languageType = 1;
            var readerFactory = new ReaderFactory(languageType);
            IDataReader _dataReader = new XMLReader(languageType);

            //Act
            var dataReader = readerFactory.ReadFromXml();
            //Assert
            Assert.IsInstanceOfType(dataReader, _dataReader.GetType() );
        }

        [TestMethod]
        public void ReaderFactoryTestShouldCreateDBReader()
        {
            //Assign
            var languageType = 1;
            var readerFactory = new ReaderFactory(languageType);
            IDataReader dataReader = new DataBaseReader(languageType);

            //Act
            var DataReader = readerFactory.ReadFromDb();
            //Assert
            Assert.IsInstanceOfType(DataReader, dataReader.GetType());
        }
    }
}
