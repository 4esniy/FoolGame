using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Durak.Interfaces;

namespace Durak
{
    public class ReaderFactory : IReaderFactory
    {
        private int _languageType {get;}

        public ReaderFactory(int languageType)
        {
            _languageType = languageType;
        }

        public IDataReader ReadFromXml()
        {
            return new XMLReader(_languageType);
        }

        public IDataReader ReadFromDb()
        {
            return new DataBaseReader(_languageType);
        }
    }
}
