using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    public class Player
    {
        internal List<Card> CardsOnHands = new List<Card>();

        internal void ShowOnHands()
        {
            Console.WriteLine("You cards are:");
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
            Table.CardsOnTable.Add(CardsOnHands[Enter-1]);
            CardsOnHands.RemoveAt(Enter - 1);
            return Table.CardsOnTable[Table.CardsOnTable.Count-1];
        }

        internal Card ManAttack(List<Card> PossibleAttackCards) //check if Player chosed right card to beat
        {
            #region Check input data
            string Input = "";
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

                    int[] CardOnHandsIndex= new int[PossibleAttackCards.Count];
                    for (int i = 0; i < PossibleAttackCards.Count; i++)
                    {
                        CardOnHandsIndex[i] = Card.CompareCards(CardsOnHands, PossibleAttackCards[i]);
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
                Table.CardsOnTable.Add(CardsOnHands[Enter - 1]);
                CardsOnHands.RemoveAt(Enter - 1);
                return Table.CardsOnTable[Table.CardsOnTable.Count - 1];
            }
            else
                return null;
            
        }

        internal List<Card> IfCanAttack(List<Card> CardsOnTable) ///check the cards on table with the cards on hand
        {
            List<Card> PossibleAttackCards = new List<Card>();
            if (CardsOnTable.Count == 0)
                return CardsOnHands;
            else
            {
                for (int i = 0; i <= CardsOnHands.Count - 1; i++)
                {
                    for (int j = 1; j <= Table.CardsOnTable.Count; j++)
                    {
                        if (CardsOnHands[i].rank == Table.CardsOnTable[j - 1].rank)
                        {
                            PossibleAttackCards.Add(CardsOnHands[i]);
                        }
                    }
                }
                return PossibleAttackCards;
            }
        }

        internal bool ManDefense(Card attackCard)
        { 
            bool defSucces = false;
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
                    defSucces = false;
                    Continue = false;

                }
                else if (Enter != 0)
                {
                    if (attackCard.trump == false)
                    {
                        if (attackCard.suit != (CardsOnHands.ElementAt(Enter - 1)).suit)
                        {
                            if (CardsOnHands.ElementAt(Enter - 1).trump == true)
                                {
                                Table.CardsOnTable.Add(CardsOnHands[Enter - 1]);
                                CardsOnHands.RemoveAt(Enter - 1);
                                defSucces = true;
                                Continue = false;
                                }
                            else
                            Console.WriteLine("You can't defend with ths Card");
                        }
                        else if (attackCard.rank > (CardsOnHands.ElementAt(Enter - 1)).rank)
                            Console.WriteLine("You can't defend with ths Card");
                        else
                        {
                            Table.CardsOnTable.Add(CardsOnHands[Enter - 1]);
                            CardsOnHands.RemoveAt(Enter - 1);
                            defSucces = true;
                            Continue = false;
                        }
                    }
                    else // attackCard.trump == true
                    {
                        if (attackCard.suit != (CardsOnHands.ElementAt(Enter - 1)).suit)
                            Console.WriteLine("You can't defend with ths Card");
                        else if (attackCard.rank > (CardsOnHands.ElementAt(Enter - 1)).rank)
                            Console.WriteLine("You can't defend with ths Card");
                        else
                        {
                            Table.CardsOnTable.Add(CardsOnHands[Enter - 1]);
                            CardsOnHands.RemoveAt(Enter - 1);
                            defSucces = true;
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
