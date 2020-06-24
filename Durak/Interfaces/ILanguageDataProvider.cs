using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak.Interfaces
{
    public interface ILanguageDataProvider
    {
        string GetAlertFromConfiguration(string keyValue);
        string GetMessageFromConfiguration(string keyValue);
        string GetAttributesFromConfiguration(string keyValue);
    }
}
