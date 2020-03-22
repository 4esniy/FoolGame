using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    internal class Computer : Player
    {
        internal Card CPUAttack()
        {
            var Item = ChooseMinRankCard(CardsOnHands, false);
            if (Item == 100) // 100 -  there is no NonTrump cards on Hands
            {
                int attackCardIndex = ChooseMinRankCard(CardsOnHands, true);
                Console.WriteLine($"CPU attacked you with {CardsOnHands[attackCardIndex].Name}," +
                                    $"{CardsOnHands[attackCardIndex].Suit}");
                Card Temp = CardsOnHands[attackCardIndex];
                CardsOnHands.RemoveAt(attackCardIndex);
                return Temp;
            }
            else
            {
                int attackCardIndex = Item;
                Console.WriteLine($"CPU attacked you with {CardsOnHands[attackCardIndex].Name}," +
                                    $"{CardsOnHands[attackCardIndex].Suit}");
                Card Temp = CardsOnHands[attackCardIndex];
                CardsOnHands.RemoveAt(attackCardIndex);
                return Temp;
            }
        }

        internal Card CPUAttack(List<Card> PossibleCardsToAttack)
        {
            int ItemNonTrump = ChooseMinRankCard(PossibleCardsToAttack, false);
            int ItemTrump = ChooseMinRankCard(PossibleCardsToAttack, true);

            if (ItemNonTrump == 100) // 100 -  there is no NonTrump cards on Hands
            {
                //не может определить с чего холить если на руках только козыри
                int attackCardIndex = CompareCards(CardsOnHands, PossibleCardsToAttack.ElementAt(ItemTrump));
                Console.WriteLine($"CPU attacked you with {CardsOnHands[attackCardIndex].Name}," +
                                    $"{CardsOnHands[attackCardIndex].Suit}");
                Card Temp = CardsOnHands[attackCardIndex];
                CardsOnHands.RemoveAt(attackCardIndex);
                return Temp;

            }
            else
            {
                int attackCardIndex = CompareCards(CardsOnHands, PossibleCardsToAttack.ElementAt(ItemNonTrump));

                Console.WriteLine($"CPU attacked you with {CardsOnHands[attackCardIndex].Name}," +
                                    $"{CardsOnHands[attackCardIndex].Suit}");
                Card Temp = CardsOnHands[attackCardIndex];
                CardsOnHands.RemoveAt(attackCardIndex);
                return Temp;
            }
        }


        internal Card CPUDefense(Card attackCard)
        {
            bool defSucces = false;
            int defCardIndex;
            List<Card> CardsForDefense = new List<Card>();
            if (attackCard.Trump == false)
            {
                for (int i = 1; i <= CardsOnHands.Count; i++)
                {
                    if (attackCard.Suit == (CardsOnHands.ElementAt(i - 1)).Suit)
                        if (attackCard.Rank < (CardsOnHands.ElementAt(i - 1)).Rank)
                            CardsForDefense.Add(CardsOnHands.ElementAt(i - 1));
                }

                if (CardsForDefense.Count != 0)
                {
                    defCardIndex = ChooseMinRankCard(CardsForDefense, false); //выбор самой маленькой карты из НЕ козырей
                    int indexOfCardOnHands = CompareCards(CardsOnHands, CardsForDefense[defCardIndex]); //поиск карты.defCardIndex среди CardsOnHands)
                    Card Temp = CardsOnHands[indexOfCardOnHands];
                    CardsOnHands.RemoveAt(indexOfCardOnHands); //удаление карты из "На руках"

                    Console.WriteLine($"Card was covered with {CardsForDefense[defCardIndex].Name}," +
                                    $"{CardsForDefense[defCardIndex].Suit}");
                    return Temp;
                }
                else //CardsForDefense.Count == 0
                {
                    for (int i = 1; i <= CardsOnHands.Count; i++)
                    {
                        if (CardsOnHands[i - 1].Trump == true)
                            CardsForDefense.Add(CardsOnHands.ElementAt(i - 1));
                    }
                    defCardIndex = ChooseMinRankCard(CardsForDefense, true); //выбор самой маленькой карты из козырей
                    if (defCardIndex == 100)
                    {
                        Console.WriteLine("CPU took all the cards from table!");
                        return null;
                    }
                    else
                    {
                        int indexOfCardOnHands = CompareCards(CardsOnHands, CardsForDefense[defCardIndex]); //поиск карты.defCardIndex среди CardsOnHands)
                        Card Temp = CardsOnHands[indexOfCardOnHands];
                        CardsOnHands.RemoveAt(indexOfCardOnHands); //удаление карты из "На руках"

                        Console.WriteLine($"Card was covered with {CardsForDefense[defCardIndex].Name}," +
                                        $"{CardsForDefense[defCardIndex].Suit}");
                        return Temp;
                    }
                }
            }

            else
            {
                for (int i = 1; i <= CardsOnHands.Count; i++)
                {
                    if (attackCard.Suit == (CardsOnHands.ElementAt(i - 1)).Suit)
                        if (attackCard.Rank < (CardsOnHands.ElementAt(i - 1)).Rank)
                            CardsForDefense.Add(CardsOnHands.ElementAt(i - 1));
                }

                if (CardsForDefense.Count != 0)
                {
                    defCardIndex = ChooseMinRankCard(CardsForDefense, true); //выбор самой маленькой карты из козырей
                    int indexOfCardOnHands = CompareCards(CardsOnHands, CardsForDefense[defCardIndex]); //поиск карты.defCardIndex среди CardsOnHands)
                    Card Temp = CardsOnHands[indexOfCardOnHands];
                    CardsOnHands.RemoveAt(indexOfCardOnHands);

                    Console.WriteLine($"Card was covered with {CardsForDefense[defCardIndex].Name}," +
                                    $"{CardsForDefense[defCardIndex].Suit}");
                    return Temp;
                }
                else
                {
                    Console.WriteLine("CPU took all the cards from table!");
                    return null;
                }
            }
        }
    }
}
