using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    abstract class Player
    {
        private const int _minCards = 6;
        protected int MinCards { get {return _minCards;} }
        //TODO: protected
        internal List<Card> CardsOnHands = new List<Card>();

        internal void ShowOnHands()
        {
            Console.WriteLine("You cards are:");
            for (int i = 0; i < CardsOnHands.Count; i++)
            {
                if (CardsOnHands[i].Trump == true)
                    Console.WriteLine($"{i + 1} - {CardsOnHands[i].Name}, {CardsOnHands[i].Suit.ToUpper()}");
                else
                    Console.WriteLine($"{i + 1} - {CardsOnHands[i].Name}, {CardsOnHands[i].Suit}");
            }
        }
        internal int CardsToTake()
        {
            int i = 0;
            if (CardsOnHands.Count >= 6)
                return 0;
            else
                return i = 6 - CardsOnHands.Count;
        }


        internal int ChooseMinRankCard(List<Card> SomeCards, bool WithTrump)
        {
            if (WithTrump == false) //If false than choosen min between NON-trump cards
            {
                List<Card> temp = new List<Card>();
                for (int i = 1; i <= SomeCards.Count; i++)
                {
                    if (SomeCards[i - 1].Trump != true)
                        temp.Add(SomeCards[i - 1]);
                }
                if (temp.Count == 0)
                {
                    return 100;
                }
                else
                {
                    int n = temp.Count - 1;
                    int minCardRank = temp[n].Rank;
                    int minIndex = n;

                    while (n > 0)
                    {
                        if (minCardRank - temp[n - 1].Rank > 0)
                        {
                            minCardRank = temp[n - 1].Rank;
                            minIndex = n - 1;
                            n--;
                        }
                        else
                        {
                            n--;
                        }
                    }
                    return CompareCards(SomeCards, temp[minIndex]);
                }
            }

            else //WithTrump == true
            {
                List<Card> temp = new List<Card>();
                for (int i = 1; i <= SomeCards.Count; i++)
                {
                    if (SomeCards[i - 1].Trump == true)
                        temp.Add(SomeCards[i - 1]);
                }
                if (temp.Count == 0)
                {
                    return 100;
                }
                else
                {
                    int n = temp.Count - 1;
                    int minCardRank = temp[n].Rank;
                    int minIndex = n;

                    while (n > 0)
                    {
                        if (minCardRank - temp[n - 1].Rank > 0)
                        {
                            minCardRank = temp[n - 1].Rank;
                            minIndex = n - 1;
                            n--;
                        }
                        else
                        {
                            n--;
                        }
                    }
                    return CompareCards(SomeCards, temp[minIndex]);
                }
            }
        }

        internal int CompareCards(List<Card> CardsOnHands, Card CardToCompare) //show index in Cards on hands with the compared card
        {
            int indexOfCard = 0;
            for (int i = 0; i < CardsOnHands.Count; i++)
            {
                if (CardsOnHands[i].Suit == CardToCompare.Suit)
                    if (CardsOnHands[i].Rank == CardToCompare.Rank)
                        indexOfCard = i;
            }
            return indexOfCard;
        }


        internal virtual List<Card> IfCanAttack(List<Card> CardsOnTable) //check the cards on table with the cards on hand
        {
            List<Card> PossibleAttackCards = new List<Card>();
            if (CardsOnTable.Count == 0)
                return null;
            else
            {
                for (int i = 0; i <= CardsOnHands.Count - 1; i++)
                {
                    for (int j = 1; j <= CardsOnTable.Count; j++)
                    {
                        if (CardsOnHands[i].Rank == CardsOnTable[j - 1].Rank)
                            PossibleAttackCards.Add(CardsOnHands[i]);
                    }
                }
                if (PossibleAttackCards.Count == 0)
                    return null;
                else
                    return PossibleAttackCards;
            }
        }
    }
}

