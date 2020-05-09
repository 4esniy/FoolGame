using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak
{
    public class Player : IPlayer
    {
        public List<Card> CardsOnHands { get; }
        public IStrategy Strategy { get; }
        public IMessages Message { get; }
        public IDefaultConstants Constant { get; }
        public int MinCards { get; }


        public Player(IConfigurationSetter configuration, IStrategy strategy)
        {
            Strategy = strategy;
            Message = configuration.Message;
            Constant = configuration.Constant;
            MinCards = Constant.numberOfCards_1_;
            CardsOnHands = new List<Card>();
        }

        public Card Attack(List<Card> CardsOnTable)
        {
           return Strategy.Attack(CardsOnHands, CardsOnTable);
        }

        public Card Defend(List<Card> CardsOnTable, Card CardToBeat)
        {
            return Strategy.Defend(CardsOnTable, CardsOnHands, CardToBeat);
        }

        public void RemoveCardFromHands(Card CardToRemove)
        {
            CardsOnHands.Remove(CardToRemove);
        }

        public void ShowOnHands()
        {
            Console.WriteLine($"{Message.yourCardsAre_1_}"); //You cards are:
            for (int i = 0; i < CardsOnHands.Count; i++)
            {
                if (CardsOnHands[i].Trump)
                    Console.WriteLine($"{i + 1} - {CardsOnHands[i].Name}, {CardsOnHands[i].Suit.ToUpper()}");
                else
                    Console.WriteLine($"{i + 1} - {CardsOnHands[i].Name}, {CardsOnHands[i].Suit}");
            }
        }

        public int HowManyCardsOnHands()
        {
            return CardsOnHands.Count;
        }

        public void AddCardToHands(Card AnyCard)
        {
            CardsOnHands.Add(AnyCard);
        }

        public int CardsToTake()
        {
            if (CardsOnHands.Count >= MinCards)
                return 0;

            return MinCards - CardsOnHands.Count;
        }
    }
}

