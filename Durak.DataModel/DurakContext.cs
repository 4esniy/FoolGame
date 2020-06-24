using System.Data.Entity;

namespace Durak.DataModel
{
    public enum LanguageEnum
    {
        English = 1, Russian
    }
    public enum KeyWordEnum
    {
        cardNames_2_ = 1, cardSuits_3_
    }
    public class Languages
    {
        public int LanguagesId { get; set; }
        public string Language { get; set; }
    }
    public class KeyWords
    {
        public int KeyWordsId { get; set; }
        public string KeyWord { get; set; }
    }
    public class CardNames
    {
        public int CardNamesId { get; set; }
        public string Name { get; set; }
        public Languages Languages { get; set; }
        public KeyWords NamesKeyWord { get; set; }
    }
    public class CardSuits
    {
        public int CardSuitsId { get; set; }
        public string Suit { get; set; }
        public Languages Languages { get; set; }
        public KeyWords SuitsKeyWord { get; set; }

    }

    public class CardAttributesContext : DbContext
    {
        public CardAttributesContext() : base("Card_attributes")
        {
        }
        public DbSet<CardNames> CardNames { get; set; }
        public DbSet<CardSuits> CardSuits { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<KeyWords> KeyWords { get; set; }
    }

}
