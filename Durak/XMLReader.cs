using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Durak.Interfaces;

namespace Durak
{
    public class XMLReader : IDataReader
    {
        private string _pathEng = ConfigurationManager.AppSettings["PathEng"];
        private string _pathRus = ConfigurationManager.AppSettings["PathRus"];

        private Dictionary<string, string> _textCollection = new Dictionary<string, string>();
        private readonly int _languageType;

        public XMLReader(int languageType)
        {
            _languageType = languageType;
        }

        public Dictionary<string, string> Read()
        {
            XmlDocument _doc = new XmlDocument();
            try
            {
                if (_languageType == 1)
                    _doc.Load(_pathEng);
                else
                    _doc.Load(_pathRus);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(nameof(Read) + " " + e.Message);
                throw new FileNotFoundException();
            }

            try
            {
                XmlNode rootNode = _doc.FirstChild.NextSibling.FirstChild.NextSibling;
                if (rootNode.HasChildNodes)
                {
                    for (int i = 0; i < rootNode.ChildNodes.Count; i++)
                    {
                        _textCollection.Add(rootNode.ChildNodes[i].Attributes.Item(0).Value,
                            rootNode.ChildNodes[i].Attributes.Item(1).Value);
                    }
                }
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine($"Not supported file format {nameof(Read)}" + " " + e.Message);
                throw new InvalidDataException();
            }

            return _textCollection;
        }

    }
}
