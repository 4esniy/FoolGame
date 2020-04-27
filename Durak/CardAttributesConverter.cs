using System;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak 
{
    public class CardAttributesConverter : ICardAttributesConverter
    {
        public string[] Names { get; set; }
        public string[] Suits { get; set; } 

        public CardAttributesConverter(ILanguageDataProvider languageConfiguration)
        {
            try
            {
                Names = languageConfiguration.GetTextFromConfiguration("cardNames_2_").Split(new string[] { "," }, StringSplitOptions.None);
                Suits = languageConfiguration.GetTextFromConfiguration("cardSuits_3_").Split(new string[] { "," }, StringSplitOptions.None);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Properties of {nameof(CardAttributesConverter)} are empty {e.Message}");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
