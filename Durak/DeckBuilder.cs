using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak
{
    public class DeckBuilder : IDeckBuilder
    {
        public string[] names { get; }
        public string[] suits { get; }
        private readonly List<Card> _rawDeck = new List<Card>();

        public DeckBuilder(ICardAttributesConverter cardAttributesConverter, int gameType)
        {
            if (cardAttributesConverter == null)
                throw new Exception(nameof(DeckBuilder));

            if (gameType == 1)
            {
                names = cardAttributesConverter.Names;
                suits = cardAttributesConverter.Suits;
            }

            if (gameType == 2)
            {
                NotImplementedException e;
            }

        }

        public Card CreateCard(int Rank, string Name, string Suit, bool Trump)
        {
            Card c = new Card(Rank, Name, Suit, Trump);
            return c;

        }

        public List<Card> CreateDeck()
        {
            //Choose randomly TrumpCard
            Random random1 = new Random();
            int trump = random1.Next(0, 4);

            //Create Deck
            foreach (string str in suits)
            {
                for (int i = 0, j = 0; i < names.Count(); i++, j++)
                {
                    if (str == suits[trump])
                    {
                        Card card = CreateCard(i, names[j], str, true);
                        _rawDeck.Add(card);
                    }

                    else
                    {
                        Card card = CreateCard(i, names[j], str, false);
                        _rawDeck.Add(card);
                    }
                }
            }

            // shuffle deck
            Random rnd = new Random();
            int n = _rawDeck.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n);
                Card value = _rawDeck[k];
                _rawDeck[k] = _rawDeck[n];
                _rawDeck[n] = value;
            }

            return _rawDeck;
        }
    }
}

