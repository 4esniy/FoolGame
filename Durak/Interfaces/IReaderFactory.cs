using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak.Interfaces
{
    public interface IReaderFactory
    {
        IDataReader ReadFromXml();
        IDataReader ReadFromDb();
    }
}
