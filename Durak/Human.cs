using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    class Human : Player
    {

        internal Card ManAttack()
        {
            #region Check input data
            string Input = "";
            int Enter = 0;
            bool Continue = true;
            Console.WriteLine($"Choose the card to attack!");
            while (Continue)
            {
                Input = Console.ReadLine();
                bool Cont = true;
                while (Cont)
                {
                    try
                    {
                        int m = Convert.ToInt32(Input);
                        Cont = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You should enter a integer");
                        Input = Console.ReadLine();
                    }
                }
                Enter = int.Parse(Input);
                if (Enter > CardsOnHands.Count)
                    Console.WriteLine($"Enter not bigger than {CardsOnHands.Count}");
                else if (Enter <= 0)
                    Console.WriteLine("Enter positive number");
                else
                    Continue = false;
                #endregion
            }
            Card Temp = CardsOnHands[Enter - 1];
            CardsOnHands.RemoveAt(Enter - 1);
            return Temp;
        }

        internal Card ManAttack(List<Card> PossibleAttackCards) //check if Player chosed right card to beat
        {
            #region Check input data
            string Input = null;
            int Enter = 0;
            bool Continue = true;
            Console.WriteLine($"Choose the card to attack or print 100 to skip!");
            while (Continue)
            {
                Input = Console.ReadLine();
                bool Cont = true;
                while (Cont)
                {
                    try
                    {
                        int m = Convert.ToInt32(Input);
                        Cont = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You should enter a integer");
                        Input = Console.ReadLine();
                    }
                }
                Enter = int.Parse(Input);
                if (Enter > CardsOnHands.Count && Enter != 100)
                    Console.WriteLine($"Enter not bigger than {CardsOnHands.Count}");
                else if (Enter == 100)
                    Continue = false;
                else if (Enter <= 0)
                    Console.WriteLine("Enter positive number");
                else // Enter == 0
                {

                    int[] CardOnHandsIndex = new int[PossibleAttackCards.Count];
                    for (int i = 0; i < PossibleAttackCards.Count; i++)
                    {
                        CardOnHandsIndex[i] = CompareCards(CardsOnHands, PossibleAttackCards[i]);
                    }
                    foreach (int item in CardOnHandsIndex)
                    {
                        if (Enter == item + 1)
                            Continue = false;
                        else
                            Console.WriteLine($"You can't attack with ths Card");
                    }
                }
                #endregion
            }
            if (Enter != 100)
            {
                Card Temp = CardsOnHands[Enter - 1];
                CardsOnHands.RemoveAt(Enter - 1);
                return Temp;
            }
            else
                return null;

        }

        internal override List<Card> IfCanAttack(List<Card> CardsOnTable) ///check the cards on table with the cards on hand
        {
            List<Card> PossibleAttackCards = new List<Card>();
            if (CardsOnTable.Count == 0)
                return CardsOnHands;
            else
            {
                for (int i = 0; i <= CardsOnHands.Count - 1; i++)
                {
                    for (int j = 1; j <= CardsOnTable.Count; j++)
                    {
                        if (CardsOnHands[i].Rank == CardsOnTable[j - 1].Rank)
                        {
                            PossibleAttackCards.Add(CardsOnHands[i]);
                        }
                    }
                }
                return PossibleAttackCards;
            }
        }

        internal Card ManDefense(Card attackCard)
        {
            Card defSucces = null;
            #region Check input
            string Input = "";
            int Enter = 0;
            bool Continue = true;
            Console.WriteLine($"Choose the card to defense!");
            Console.WriteLine($"Choose 0 to take all cards on the table on hands");

            while (Continue)
            {
                Input = Console.ReadLine();
                bool Cont = true;
                while (Cont)
                {
                    try
                    {
                        int m = Convert.ToInt32(Input);
                        Cont = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You should enter a integer");
                        Input = Console.ReadLine();
                    }
                }
                Enter = int.Parse(Input);
                if (Enter > CardsOnHands.Count)
                    Console.WriteLine($"Enter not bigger than {CardsOnHands.Count}");
                else if (Enter < 0)
                    Console.WriteLine("Enter positive number");
                else if (Enter == 0)
                {
                    Console.WriteLine("You take all the cards from table!");
                    defSucces = null;
                    Continue = false;

                }
                else if (Enter != 0)
                {
                    if (attackCard.Trump == false)
                    {
                        if (attackCard.Suit != (CardsOnHands.ElementAt(Enter - 1)).Suit)
                        {
                            if (CardsOnHands.ElementAt(Enter - 1).Trump == true)
                            {
                                defSucces = CardsOnHands[Enter - 1];
                                CardsOnHands.RemoveAt(Enter - 1);
                                Continue = false;
                            }
                            else
                                Console.WriteLine("You can't defend with ths Card");
                        }
                        else if (attackCard.Rank > (CardsOnHands.ElementAt(Enter - 1)).Rank)
                            Console.WriteLine("You can't defend with ths Card");
                        else
                        {
                            defSucces = CardsOnHands[Enter - 1];
                            CardsOnHands.RemoveAt(Enter - 1);
                            Continue = false;
                        }
                    }
                    else // attackCard.trump == true
                    {
                        if (attackCard.Suit != (CardsOnHands.ElementAt(Enter - 1)).Suit)
                            Console.WriteLine("You can't defend with ths Card");
                        else if (attackCard.Rank > (CardsOnHands.ElementAt(Enter - 1)).Rank)
                            Console.WriteLine("You can't defend with ths Card");
                        else
                        {
                            defSucces = CardsOnHands[Enter - 1];
                            CardsOnHands.RemoveAt(Enter - 1);
                            Continue = false;
                        }
                    }
                }
            }
            return defSucces;
            #endregion
        }
    }
}
