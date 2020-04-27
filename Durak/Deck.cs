using System;
using System.Collections.Generic;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak
{
    public class Deck : IDeck
    {
        public List<Card> _deckOfCards {get; }

        public Deck(IDeckBuilder deckBuilder)
        {
            try
            {
                _deckOfCards = deckBuilder.CreateDeck();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Received value of {nameof(Deck)} is empty {e.Message}");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void GiveCardFromDeck(int i, Player T)
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

        public string ShowTrumpCard()
        {
            
            string temp=null;
            foreach (Card i in _deckOfCards)
                if (i.Trump)
                {
                    temp = i.Suit;
                    break;
                }
            
            return temp;
        }

        public int HowManyCardsInDeck()
        {
            return _deckOfCards.Count;
        }

    }
}
