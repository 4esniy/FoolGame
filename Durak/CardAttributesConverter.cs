using System;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak 
{
    public class CardAttributesConverter : ICardAttributesConverter
    {
        public string[] Names { get;}
        public string[] Suits { get;} 

        public CardAttributesConverter(ILanguageDataProvider languageConfiguration)
        {
            if (languageConfiguration != null)
            {
                Names = languageConfiguration.GetAttributesFromConfiguration("cardNames_2_").Split(new string[] { "," }, StringSplitOptions.None);
                Suits = languageConfiguration.GetAttributesFromConfiguration("cardSuits_3_").Split(new string[] { "," }, StringSplitOptions.None);
            }
            else
            {
                throw new ArgumentNullException(nameof(CardAttributesConverter));
            }
        }
    }
}
