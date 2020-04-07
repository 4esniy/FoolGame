using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;

namespace Durak
{

    internal class Deck
    { 
        private List<Card> _deckOfCards = new List<Card>();
        internal string[] _names;
        internal string[] _suits;

        internal Deck (string names, string suits)
        {
         _names = names.Split(new string[] { "," }, StringSplitOptions.None);
         _suits = suits.Split(new string[] { "," }, StringSplitOptions.None);
        }
        
        internal void CreateCard(int Rank, string Name, string Suit, bool Trump)
        {
            Card c = new Card(Rank, Name, Suit, Trump);
            _deckOfCards.Add(c);
        }

        internal void CreateDeck(int Trump)
        {
            foreach (string str in _suits)
            {
                for (int i = 0, j = 0; i < _names.Count(); i++, j++)
                {
                    if (str == _suits[Trump])
                        CreateCard(i, _names[j], str, true);
                    else
                        CreateCard(i, _names[j], str, false);
                }
            }
        }

        internal void ShowCards() //Just to check that cards are created
        {
            foreach (Card i in _deckOfCards)
                i.Show();
        }


        internal void GiveCardFromDeck(int i, Player T)
        {
            if (_deckOfCards.Count > 0)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (_deckOfCards.Count > 0)
                    {
                        T.AddCardToHands(_deckOfCards[0]);
                        _deckOfCards.RemoveAt(0);
                    }
                }
            }
        }

        internal void ShuffleDeck()
        {
            Random rnd = new Random();
            int n = _deckOfCards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n);
                Card value = _deckOfCards[k];
                _deckOfCards[k] = _deckOfCards[n];
                _deckOfCards[n] = value;
            }
        }

        internal string ShowTrumpCard(int Trump)
        {
            return _suits[Trump].ToUpper();
        }

        internal int HowManyCardsInDeck()
        {
            return _deckOfCards.Count;
        }

    }
}
