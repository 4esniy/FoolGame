using System;
using System.Text;
using System.Collections.Generic;
using Durak;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DurakTest
{
    /// <summary>
    /// This tests EFDataBaseReaderTest
    /// </summary>
    [TestClass]
    public class EFDataBaseReaderTest
    {
        private int _languageType = 1;
        private EFDataBaseReader _efDataBaseReader;
        public EFDataBaseReaderTest()
        {
            _efDataBaseReader = new EFDataBaseReader(_languageType);
        }

        [TestMethod]
        public void InitialAttributesShouldBeSet()
        {
            Assert.IsNotNull(_efDataBaseReader._languageType);
        }
    }
}
