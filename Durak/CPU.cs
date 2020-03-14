using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    public class CPU
    {
        internal List<Card> CardsOnHands = new List<Card>();

        internal void ShowOnHands()
        {
            Console.WriteLine("CPU's cards are:");
            for (int i = 0; i < CardsOnHands.Count; i++)
            {
                if (CardsOnHands[i].trump == true)
                    Console.WriteLine($"{i+1} - {CardsOnHands[i].name}, {CardsOnHands[i].suit.ToUpper()}");
                else
                    Console.WriteLine($"{i+1} - {CardsOnHands[i].name}, {CardsOnHands[i].suit}");
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

        internal void TakeCard(int i)
        {
            if (Card.Deck.Count > 0)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (Card.Deck.Count > 0)
                    {
                        CardsOnHands.Add(Card.Deck[0]);
                        Card.Deck.RemoveAt(0);
                    }
                }
            }
        }

        internal Card CPUAttack() 
        {
            var Item = Card.ChooseMinRankCard(CardsOnHands, false);
            if (Item == 100) // 100 -  there is no NonTrump cards on Hands
            {
                int attackCardIndex = Card.ChooseMinRankCard(CardsOnHands, true);
                Console.WriteLine($"CPU attacked you with {CardsOnHands[attackCardIndex].name}," +
                                    $"{CardsOnHands[attackCardIndex].suit}");
                Table.CardsOnTable.Add(CardsOnHands[attackCardIndex]);
                CardsOnHands.RemoveAt(attackCardIndex);
                return Table.CardsOnTable[Table.CardsOnTable.Count - 1];
            }
            else 
            {
                int attackCardIndex = Item;
                Console.WriteLine($"CPU attacked you with {CardsOnHands[attackCardIndex].name}," +
                                    $"{CardsOnHands[attackCardIndex].suit}");
                Table.CardsOnTable.Add(CardsOnHands[attackCardIndex]);
                CardsOnHands.RemoveAt(attackCardIndex);
                return Table.CardsOnTable[Table.CardsOnTable.Count - 1];
            }
        }

        internal Card CPUAttack(List<Card> PossibleCardsToAttack)
        {
            int ItemNonTrump = Card.ChooseMinRankCard(PossibleCardsToAttack, false);
            int ItemTrump = Card.ChooseMinRankCard(PossibleCardsToAttack, true);

            if (ItemNonTrump == 100) // 100 -  there is no NonTrump cards on Hands
            {
                //не может определить с чего холить если на руках только козыри
                int attackCardIndex = Card.CompareCards(CardsOnHands, PossibleCardsToAttack.ElementAt(ItemTrump));
                Console.WriteLine($"CPU attacked you with {CardsOnHands[attackCardIndex].name}," +
                                    $"{CardsOnHands[attackCardIndex].suit}");
                Table.CardsOnTable.Add(CardsOnHands[attackCardIndex]);
                CardsOnHands.RemoveAt(attackCardIndex);
                return Table.CardsOnTable[Table.CardsOnTable.Count - 1];
            }
            else
            {
                int attackCardIndex = Card.CompareCards(CardsOnHands, PossibleCardsToAttack.ElementAt(Card.ChooseMinRankCard(PossibleCardsToAttack, false)));

                Console.WriteLine($"CPU attacked you with {CardsOnHands[attackCardIndex].name}," +
                                    $"{CardsOnHands[attackCardIndex].suit}");
                Table.CardsOnTable.Add(CardsOnHands[attackCardIndex]);
                CardsOnHands.RemoveAt(attackCardIndex);
                return Table.CardsOnTable[Table.CardsOnTable.Count - 1];
            }
        }


        internal bool CPUDefense(Card attackCard)
        {
            bool defSucces=false;
            int defCardIndex;
            List<Card> CardsForDefense = new List<Card>();
            if (attackCard.trump == false)
            {
                for (int i = 1; i <= CardsOnHands.Count; i++)
                {
                    if (attackCard.suit == (CardsOnHands.ElementAt(i - 1)).suit)
                        if (attackCard.rank < (CardsOnHands.ElementAt(i - 1)).rank)
                            CardsForDefense.Add(CardsOnHands.ElementAt(i - 1));
                }

                if (CardsForDefense.Count != 0)
                {
                    defCardIndex = Card.ChooseMinRankCard(CardsForDefense, false); //выбор самой маленькой карты из НЕ козырей
                    int indexOfCardOnHands = Card.CompareCards(CardsOnHands, CardsForDefense[defCardIndex]); //поиск карты.defCardIndex среди CardsOnHands)
                    Table.CardsOnTable.Add(CardsOnHands[indexOfCardOnHands]); //добавление карты "на стол"
                    CardsOnHands.RemoveAt(indexOfCardOnHands); //удаление карты из "На руках"

                    Console.WriteLine($"Card was covered with {CardsForDefense[defCardIndex].name}," +
                                    $"{CardsForDefense[defCardIndex].suit}");
                    return defSucces = true;
                }
                else //CardsForDefense.Count == 0
                {
                    for (int i = 1; i <= CardsOnHands.Count; i++)
                    {
                            if (CardsOnHands[i-1].trump == true)
                            CardsForDefense.Add(CardsOnHands.ElementAt(i - 1));
                    }
                    defCardIndex = Card.ChooseMinRankCard(CardsForDefense, true); //выбор самой маленькой карты из козырей
                    if (defCardIndex == 100)
                    {
                        Console.WriteLine("CPU took all the cards from table!");
                        return defSucces = false;
                    }
                    else
                    {
                        int indexOfCardOnHands = Card.CompareCards(CardsOnHands, CardsForDefense[defCardIndex]); //поиск карты.defCardIndex среди CardsOnHands)
                        Table.CardsOnTable.Add(CardsOnHands[indexOfCardOnHands]); //добавление карты "на стол"
                        CardsOnHands.RemoveAt(indexOfCardOnHands); //удаление карты из "На руках"

                        Console.WriteLine($"Card was covered with {CardsForDefense[defCardIndex].name}," +
                                        $"{CardsForDefense[defCardIndex].suit}");
                        return defSucces = true;
                    }
                }
            }
            
            else
            {
                for (int i = 1; i <= CardsOnHands.Count; i++)
                {
                    if (attackCard.suit == (CardsOnHands.ElementAt(i - 1)).suit)
                        if (attackCard.rank < (CardsOnHands.ElementAt(i - 1)).rank)
                            CardsForDefense.Add(CardsOnHands.ElementAt(i - 1));
                }

                if (CardsForDefense.Count != 0 )
                {
                    defCardIndex = Card.ChooseMinRankCard(CardsForDefense, true); //выбор самой маленькой карты из козырей
                    int indexOfCardOnHands = Card.CompareCards(CardsOnHands, CardsForDefense[defCardIndex]); //поиск карты.defCardIndex среди CardsOnHands)
                    Table.CardsOnTable.Add(CardsOnHands[indexOfCardOnHands]);
                    CardsOnHands.RemoveAt(indexOfCardOnHands);

                    Console.WriteLine($"Card was covered with {CardsForDefense[defCardIndex].name}," +
                                    $"{CardsForDefense[defCardIndex].suit}");
                    defSucces = true;
                }
                else
                {
                    Console.WriteLine("CPU took all the cards from table!");
                    defSucces = false;
                }
                return defSucces;
            }
        }

        internal List<Card> IfCanCPUAttack(List<Card> CardsOnTable) //check the cards on table with the cards on hand
        {
            List<Card> PossibleAttackCards = new List<Card>();
            if (CardsOnTable.Count == 0)
                return null;
            else
            {
                for (int i = 0; i <= CardsOnHands.Count - 1; i++)
                {
                    for (int j = 1; j <= Table.CardsOnTable.Count; j++)
                    {
                        if (CardsOnHands[i].rank == Table.CardsOnTable[j - 1].rank)
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
