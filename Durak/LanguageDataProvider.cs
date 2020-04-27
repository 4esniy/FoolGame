using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Durak.Interfaces;

namespace Durak
{
    public class LanguageDataProvider : ILanguageDataProvider
    {
        private readonly Exception _ex;

        private Dictionary<string, string> _textCollection { get; }
        private StringBuilder sb = new StringBuilder();

        public LanguageDataProvider(IReaderFactory factory)
        {
            var _factory = factory;
            IDataReader dataReader;

            try
            {
                dataReader = _factory.ReadFromXml();
                _textCollection = dataReader.Read();
            }
            catch (Exception e)
            {
                _ex = e;
                sb.Append($"{nameof(LanguageDataProvider)} ");
                sb.Append($" {e.Message}");
                sb.Append($" {e.StackTrace}");
                Console.WriteLine(sb);
            }
            finally
            {
                if (_ex != null)
                {
                    try
                    {
                        dataReader = _factory.ReadFromDb();
                        _textCollection = dataReader.Read();
                    }
                    catch (Exception e)
                    {
                        _ex = e;
                        sb.Append($"{nameof(LanguageDataProvider)}");
                        sb.Append($" {e.Message}");
                        sb.Append($" {e.StackTrace}");
                        Console.WriteLine(sb);
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
        }

        public string GetTextFromConfiguration(string keyValue)
        {
            string temp = null;
            foreach (var i in _textCollection)
            {
                if (i.Key.Equals(keyValue))
                    temp = i.Value;
            }
            if (temp == null)
                throw new ArgumentException("Incorrect Key value", nameof(GetTextFromConfiguration));

            return temp;
        }
    }
}
