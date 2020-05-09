using Durak.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Durak
{
    public class LanguageDataProvider : ILanguageDataProvider
    {
        public Exception Ex { get; }
        public Dictionary<string, string> TextCollection { get; }

        public LanguageDataProvider(IReaderFactory Factory)
        {
            var factory = Factory;

            try
            {
                TextCollection = factory.ReadFromXml().Read();
            }
            catch (Exception e)
            {
                Ex = e;
            }
            finally
            {
                if (Ex != null)
                {
                    try
                    {
                        TextCollection = factory.ReadFromDb().Read();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(nameof(LanguageDataProvider));
                    }
                }
            }
        }

        public string GetTextFromConfiguration(string keyValue)
        {
            string temp = null;
            foreach (var i in TextCollection)
            {
                if (i.Key.Equals(keyValue))
                    temp = i.Value;
            }
            if (temp == null)
                throw new ArgumentException("Key value does not exist", nameof(GetTextFromConfiguration));

            return temp;
        }
    }
}
