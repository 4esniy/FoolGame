using System;
using System.Collections.Generic;
using System.Configuration;

namespace Durak
{
    public class Player
    {
        private string _playerName;
        public string PlayerName { get { return _playerName;}}
        private List<Card> CardsOnHands = new List<Card>();
        private IStrategy _strategy;
        private IMessages _message;
        private IDefaultConstants _constant;
        private int _minCards;


        public Player(int languageType, string strategyType , string playerName)
        {
            _playerName = playerName;
            _message = new Messages(languageType);
            _constant = new DefaultConstants(languageType);
            _minCards = _constant.numberOfCards_1_;

            string a = _constant.strategy_1_4_;
            string b = _constant.strategy_1_4_;
                

            if (strategyType == a)
                _strategy = new StrategyA(languageType);
            else if (strategyType == b)
                _strategy = new StrategyB(languageType);
            else
                _strategy = new HumanStrategy(languageType);

        }

        public Card Attack(List<Card> CardsOnTable)
        {
            return _strategy.Attack(CardsOnHands, CardsOnTable);

        }

        public Card Defend(List<Card> CardsOnTable, Card CardToBeat)
        {
            return _strategy.Defend(CardsOnTable, CardsOnHands, CardToBeat);
        }

        public void RemoveCardFromHads(Card CardToRemove)
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

