using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    internal class Deck
    {
        // TODO: protected
        internal List<Card> _deckOfCards = new List<Card>(); 
        //internal int DeckAmount = 36;
        internal string[] Names = { "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Lady", "King", "Ace" };
        internal string[] Suits = { "Diamonds", "Spades", "Clubs", "Hearts" };

        internal void CreateCard(int Rank, string Name, string Suit, bool Trump)
        {
            Card c = new Card(Rank, Name, Suit, Trump);
            _deckOfCards.Add(c);
        }

        internal void CreateDeck(int Trump)
        {
            foreach (string str in Suits)
            {
                for (int i = 0, j = 0; i < Names.Count(); i++, j++)
                {
                    if (str == Suits[Trump])
                        CreateCard(i, Names[j], str, true);
                    else
                        CreateCard(i, Names[j], str, false);
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
                        T.CardsOnHands.Add(_deckOfCards[0]);
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
    }
}
