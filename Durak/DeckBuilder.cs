using System;
using System.Collections.Generic;
using System.Linq;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak
{
    public class DeckBuilder : IDeckBuilder
    {
        private readonly string[] _names;
        private readonly string[] _suits;
        private readonly List<Card> _rawDeck = new List<Card>();

        public DeckBuilder(ICardAttributesConverter cardAttributesProvider)
        {
            try
            {
                if (cardAttributesProvider.Names == null || cardAttributesProvider.Suits == null)
                    throw new ArgumentNullException(nameof(DeckBuilder), "Names and Suits data was not provided");
                _names = cardAttributesProvider.Names;
                _suits = cardAttributesProvider.Suits;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Card CreateCard(int Rank, string Name, string Suit, bool Trump)
        {
            try
            {
                Card c = new Card(Rank, Name, Suit, Trump);
                return c;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Can't create Card. One of the credentials (Names or Suits) was missed");
                throw;
            }
        }

        public List<Card> CreateDeck()
        {
            //Choose randomly TrumpCard
            Random random1 = new Random();
            int trump = random1.Next(0, 4);

            //Create Deck
            foreach (string str in _suits)
            {
                for (int i = 0, j = 0; i < _names.Count(); i++, j++)
                {
                    if (str == _suits[trump])
                    {
                        Card card = CreateCard(i, _names[j], str, true);
                        _rawDeck.Add(card);
                    }

                    else
                    {
                        Card card = CreateCard(i, _names[j], str, false);
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

