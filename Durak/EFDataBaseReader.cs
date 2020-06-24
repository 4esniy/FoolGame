using Durak.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Durak
{
    public class EFDataBaseReader : IDataReader
    {

        public int _languageType { get; }

        public EFDataBaseReader(int languageType)
        {
            _languageType = languageType;
        }

        public Dictionary<string, string> Read()
        {
            var textCollection = new Dictionary<string, string>();

            using (var context = new CardAttributesContext())
            {
                if (!context.Database.Exists())
                {
                    var languageEng = new Languages() { Language = Enum.GetName(typeof(LanguageEnum), 1) };
                    var languageRu = new Languages() { Language = Enum.GetName(typeof(LanguageEnum), 2) };
                    var keywordNames = new KeyWords() { KeyWord = Enum.GetName(typeof(KeyWordEnum), 1)};
                    var keywordSuits = new KeyWords() { KeyWord = Enum.GetName(typeof(KeyWordEnum), 2)};
                    var cardNamesEng = new CardNames()
                    {
                        Name = "Six,Seven,Eight,Nine,Ten,Jack,Lady,King,Ace",
                        Languages = languageEng,
                        NamesKeyWord = keywordNames
                    };
                    var cardNamesRu = new CardNames()
                    {
                        Name = "Шестерка,Семерка,Восьмерка,Девятка,Десять,Валет,Дама,Король,Туз",
                        Languages = languageRu,
                        NamesKeyWord = keywordNames
                    };
                    var SuitsEng = new CardSuits()
                    { Suit = "Diamonds,Spades,Clubs,Hearts", 
                        Languages = languageEng, 
                        SuitsKeyWord = keywordSuits
                    };
                    var SuitsRu = new CardSuits()
                    { Suit = "Буби,Пики,Крести,Червы", 
                        Languages = languageRu, 
                        SuitsKeyWord = keywordSuits
                    };

                    context.Languages.Add(languageEng);
                    context.Languages.Add(languageRu);
                    context.KeyWords.Add(keywordNames);
                    context.KeyWords.Add(keywordSuits);
                    context.CardNames.Add(cardNamesEng);
                    context.CardNames.Add(cardNamesRu);
                    context.CardSuits.Add(SuitsEng);
                    context.CardSuits.Add(SuitsRu);

                    context.SaveChanges();
                }

                context.Database.Log = Console.WriteLine;
                var cardNames = context.CardNames
                    .Include(n => n.NamesKeyWord)
                .First(n => n.Languages.LanguagesId == _languageType);

                CardSuits cardSuits = context.CardSuits
                   .Include(n => n.SuitsKeyWord)
                .First(n => n.Languages.LanguagesId == _languageType);

                textCollection.Add(cardNames.NamesKeyWord.KeyWord, cardNames.Name);
                textCollection.Add(cardSuits.SuitsKeyWord.KeyWord, cardSuits.Suit);
            }
            return textCollection;
        }
    }
}