using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using Durak;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DurakTest
{

    [TestClass]
    public class DataBaseReaderTest
    {
        [TestMethod]
        public void DataBaseReaderTestCotrShouldSetLanguageType()
        {
            //Assign
            int langType = 1;
            //Act
            var dBReader = new DataBaseReader(langType);
            //Assert
            Assert.IsNotNull(dBReader._languageType);

        }


    }
}
