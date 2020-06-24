using Durak.Interfaces;
using System;
using System.Collections.Generic;

namespace Durak
{
    public class LanguageDataProvider : ILanguageDataProvider
    {
        public Exception Ex { get; }
        public Dictionary<string, string> AlertsCollection { get; }
        public Dictionary<string, string> MessagesCollection { get; }
        public Dictionary<string, string> AttributesCollection { get; }

        public LanguageDataProvider(IReaderFactory Factory)
        {
            var factory = Factory;

            try
            {
                AlertsCollection = factory.ReadFromXml().Read();
                MessagesCollection = factory.ReadFromDb().Read();
                AttributesCollection = factory.ReadUsingEF().Read();
            }
            catch (Exception e)
            {
                throw new Exception(nameof(LanguageDataProvider));
            }

        }

        public string GetAlertFromConfiguration(string keyValue)
        {
            string temp = null;
            foreach (var i in AlertsCollection)
            {
                if (i.Key.Equals(keyValue))
                    temp = i.Value;
            }
            if (temp == null)
                throw new ArgumentException("Key value does not exist", nameof(GetAlertFromConfiguration));

            return temp;
        }

        public string GetMessageFromConfiguration(string keyValue)
        {
            string temp = null;
            foreach (var i in MessagesCollection)
            {
                if (i.Key.Equals(keyValue))
                    temp = i.Value;
            }
            if (temp == null)
                throw new ArgumentException("Key value does not exist", nameof(GetMessageFromConfiguration));

            return temp;
        }

        public string GetAttributesFromConfiguration(string keyValue)
        {
            string temp = null;
            foreach (var i in AttributesCollection)
            {
                if (i.Key.Equals(keyValue))
                    temp = i.Value;
            }
            if (temp == null)
                throw new ArgumentException("Key value does not exist", nameof(GetAttributesFromConfiguration));

            return temp;
        }
    }
}
