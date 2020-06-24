using System;
using System.Collections.Generic;
using System.Linq;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak.Strategies
{
    public class StrategyA : IStrategy
    {
        private IMessages _message;
        private IConsoleReadWrap _consoleRead;

        public StrategyA(IConfigurationSetter configuration, IConsoleReadWrap consoleRead)
        {

            if (configuration == null || consoleRead == null)
                throw new NullReferenceException(nameof(StrategyA));
                _message = configuration.Message;
                _consoleRead = consoleRead;
        }

        public Card Attack(List<Card> CardsOnHands, List<Card> CardsOnTable)
        {

            List<Card> possibleAttackCards = PossibleAttackCards(CardsOnHands, CardsOnTable);
            Card minCardNonTrump = null;
            Card minCardTrump = null;

            if (possibleAttackCards.Count != 0)
            {
                minCardNonTrump = ChooseMinRankCard(possibleAttackCards, false);
                minCardTrump = ChooseMinRankCard(possibleAttackCards, true);
            }
            else if (possibleAttackCards.Count == 0 && CardsOnTable.Count == 0)
            {
                minCardNonTrump = ChooseMinRankCard(CardsOnHands, false);
                minCardTrump = ChooseMinRankCard(CardsOnHands, true);
            }
            else
            {
                Console.WriteLine($"{_message.cpuHasNoAttackCard_30_}"); //CPU has no cards to attack, press any key to continue
                Console.ReadKey();
                return null;
            }


            if (minCardNonTrump == null) // null -  there are no NonTrump cards in possibleAttack cards
            {
                Console.WriteLine($"{_message.cpuAttackedYouWith_31_} {minCardTrump.Name},{(minCardTrump.Suit).ToUpper()}"); //CPU attacked you with
                return minCardTrump;
            }
            else
            {
                Console.WriteLine($"{_message.cpuAttackedYouWith_31_} {minCardNonTrump.Name},{minCardNonTrump.Suit}");
                return minCardNonTrump;
            }
        }


        public Card Defend(List<Card> CardsOnTable, List<Card> CardsOnHands, Card CardToBeat)
        {
            List<Card> possibleDefendCards = PossibleDefendCards(CardsOnHands, CardToBeat);
            Card minCardNonTrump = null;
            Card minCardTrump = null;

            if (possibleDefendCards.Count != 0)
            {
                minCardNonTrump = ChooseMinRankCard(possibleDefendCards, false);
                minCardTrump = ChooseMinRankCard(possibleDefendCards, true);

                if (minCardNonTrump == null) // there are no NonTrump cards on Hands
                {
                    Console.WriteLine($"{_message.cpuBeatWith_32_} {minCardTrump.Name},{(minCardTrump.Suit).ToUpper()}"); //CPU covered with
                    return minCardTrump;
                }
                else
                {
                    Console.WriteLine($"{_message.cpuBeatWith_32_} {minCardNonTrump.Name},{minCardNonTrump.Suit}");
                    return minCardNonTrump;
                }
            }
            else
            {
                Console.WriteLine($"{_message.cpuHasNoDefendCard_33_}"); //CPU has no cards to defend, press any key to continue
                _consoleRead.ConsoleReadKey();
                return null;
            }
        }

        public List<Card> PossibleAttackCards(List<Card> CardsOnHands, List<Card> CardsOnTable) //check the cards on table with the cards on hand
        {
            List<Card> possibleAttackCards = new List<Card>();
            for (int i = 0; i <= CardsOnHands.Count - 1; i++)
            {
                for (int j = 1; j <= CardsOnTable.Count; j++)
                {
                    if (CardsOnHands[i].Rank == CardsOnTable[j - 1].Rank)
                        possibleAttackCards.Add(CardsOnHands[i]);
                }
            }
            possibleAttackCards = possibleAttackCards.Distinct().ToList();
            return possibleAttackCards;
        }

        public List<Card> PossibleDefendCards(List<Card> CardsOnHands, Card CardToBeat) ///check the cards on table with the cards on hand
        {
            List<Card> possibleDefendCards = new List<Card>();
            for (int i = 0; i <= CardsOnHands.Count - 1; i++)
            {
                if (CardToBeat.Trump == true)
                {
                    if (CardsOnHands[i].Trump == true && CardsOnHands[i].Rank > CardToBeat.Rank)
                    {
                        possibleDefendCards.Add(CardsOnHands[i]);
                    }
                }
                else //CardToBeat.Trump == false
                {
                    if (CardsOnHands[i].Suit == CardToBeat.Suit && CardsOnHands[i].Trump == false && CardsOnHands[i].Rank > CardToBeat.Rank)
                    {
                        possibleDefendCards.Add(CardsOnHands[i]);
                    }
                    if (CardsOnHands[i].Trump == true)
                    {
                        possibleDefendCards.Add(CardsOnHands[i]);
                    }
                }
            }
            possibleDefendCards = possibleDefendCards.Distinct().ToList();
            return possibleDefendCards;
        }


        public Card ChooseMinRankCard(List<Card> SomeCards, bool OnlyTrumpCards)
        {

            List<Card> temp = new List<Card>();
            for (int i = 1; i <= SomeCards.Count; i++)
            {
                if (SomeCards[i - 1].Trump == OnlyTrumpCards)
                    temp.Add(SomeCards[i - 1]);
            }

            if (temp.Count == 0)
                return null;

            int n = temp.Count - 1;
            int MinCardRank = temp[n].Rank;
            int indexMinCardRank = n;

            while (n > 0)
            {
                if (MinCardRank - temp[n - 1].Rank > 0)
                {
                    MinCardRank = temp[n - 1].Rank;
                    indexMinCardRank = n - 1;
                    n--;
                }
                else
                {
                    n--;
                }
            }
            return temp[indexMinCardRank];
        }
    }
}
