using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace Durak
{
    public class ReadLanguageConfiguration
    {
        private string _pathEng = ConfigurationManager.AppSettings["PathEng"];
        private string _pathRus = ConfigurationManager.AppSettings["PathRus"];
        private Dictionary<string, string> textCollection = new Dictionary<string, string>();
        private XmlDocument _doc = new XmlDocument();

        public ReadLanguageConfiguration(int languageType)
        {
            if (languageType == 1)
                _doc.Load(_pathEng);
            else
                _doc.Load(_pathRus);

            XmlNode rootNode = _doc.FirstChild.NextSibling.FirstChild.NextSibling;
            if (rootNode.HasChildNodes)
            {
                for (int i = 0; i < rootNode.ChildNodes.Count; i++)
                {
                        textCollection.Add(rootNode.ChildNodes[i].Attributes.Item(0).Value, rootNode.ChildNodes[i].Attributes.Item(1).Value);
                }
            }
        }

        public string GetTextFromConfiguration(string keyValue)
        {
            string temp = null;
            foreach (var i in textCollection)
            {
                if (i.Key.Equals(keyValue))
                    temp = i.Value;
            }
            return temp;
        }

        
    }
}
