using System;
using System.Collections.Generic;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak
{
    public class Player
    {
        private List<Card> CardsOnHands = new List<Card>();
        private IStrategy _strategy;
        private IMessages _message;
        private IDefaultConstants _constant;
        private int _minCards;


        internal Player(IConfigurationSetter configuration, IStrategy strategy)
        {
            try
            {
                _strategy = strategy;
                _message = configuration.Message;
                _constant = configuration.Constant;
                _minCards = _constant.numberOfCards_1_;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"{nameof(Player)}received empty parameters. {e.Message}");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public Card Attack(List<Card> CardsOnTable)
        {
            return _strategy.Attack(CardsOnHands, CardsOnTable);

        }

        public Card Defend(List<Card> CardsOnTable, Card CardToBeat)
        {
            return _strategy.Defend(CardsOnTable, CardsOnHands, CardToBeat);
        }

        public void RemoveCardFromHands(Card CardToRemove)
        {
            CardsOnHands.Remove(CardToRemove);
        }

        public void ShowOnHands()
        {
            Console.WriteLine($"{_message.yourCardsAre_1_}"); //You cards are:
            for (int i = 0; i < CardsOnHands.Count; i++)
            {
                if (CardsOnHands[i].Trump == true)
                    Console.WriteLine($"{i + 1} - {CardsOnHands[i].Name}, {CardsOnHands[i].Suit.ToUpper()}");
                else
                    Console.WriteLine($"{i + 1} - {CardsOnHands[i].Name}, {CardsOnHands[i].Suit}");
            }
        }

        internal int HowManyCardsOnHands()
        {
            return CardsOnHands.Count;
        }

        internal void AddCardToHands(Card AnyCard)
        {
            CardsOnHands.Add(AnyCard);
        }

        internal int CardsToTake()
        {
            int i = 0;
            if (CardsOnHands.Count >= _minCards)
                return 0;
            else
                return i = _minCards - CardsOnHands.Count;
        }
    }
}

