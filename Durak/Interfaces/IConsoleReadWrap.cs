using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak.Interfaces
{
    public interface IConsoleReadWrap
    {
        string ConsoleReadLine();
        string ReadAppSettings();
    }
}
