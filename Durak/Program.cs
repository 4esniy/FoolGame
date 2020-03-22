using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Durak
{
    class Program
    {
        static void Main(string[] args)
        {
            string WantToContinue = "Y";
            while (WantToContinue == "Y")
            {
                bool Continue = true;
                string UserName = "";

                Console.WriteLine("Welcome to DURAK game!!!");

                while (Continue)
                {
                    Console.WriteLine("Enter YOUR name and press Enter button:");
                    UserName = Convert.ToString(Console.ReadLine());
                    if (UserName.Length > 10)
                        Console.WriteLine("Enter not less than 10 characters");
                    else if (string.IsNullOrWhiteSpace(UserName))
                        Console.WriteLine("User name can not be empty");
                    else
                        Continue = false;
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"Hello {UserName}!");
                Console.WriteLine("-----------------------------------------------------------------------------------------------");

                Table GameTable = new Table();
                Human Man = new Human();
                Computer CPU = new Computer();
                Deck DeckOnTable = new Deck();
                //Console.ReadKey();
                Random Random1 = new Random();
                int Trump = Random1.Next(0, 4);

                Console.WriteLine($"This time your Trump card is {DeckOnTable.Suits[Trump].ToUpper()}");

                DeckOnTable.CreateDeck(Trump); //Creation of Deck
                DeckOnTable.ShuffleDeck(); //Shuffle all cards in Deck
                DeckOnTable.GiveCardFromDeck(6, Man); // Give 6 cards to Man
                DeckOnTable.GiveCardFromDeck(6, CPU); // Give 6 cards to CPU
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Random Random2 = new Random(); // Automaticaly who's turn is choosen
                int Turn = Random2.Next(0, 2);

                while (Man.CardsOnHands.Count > 0 && CPU.CardsOnHands.Count > 0)
                {

                    if (Turn == 0 && Man.CardsOnHands.Count > 0 && CPU.CardsOnHands.Count > 0)
                    {
                        //tempdefence = null;
                        Console.WriteLine("-----------------------------------------------------------------------------------------------");
                        Console.WriteLine($"Your turn to GO!");
                        if (GameTable.CardsOnTable.Count == 0) //Check to put any or certain card
                        {
                            Man.ShowOnHands();
                            Console.WriteLine($"There are {CPU.CardsOnHands.Count} cards in CPU hands");
                            var Attack = Man.ManAttack();
                            GameTable.AddCardsToTable(Attack);
                            if (Attack != null)
                            {
                                Card tempdefence = CPU.CPUDefense(Attack);
                                if (tempdefence != null)
                                {
                                    GameTable.AddCardsToTable(tempdefence);
                                    Console.WriteLine($"Cards on table are:");
                                    for (int i = 1; i <= GameTable.CardsOnTable.Count; i++)
                                    {
                                        Console.WriteLine($"{i} - {GameTable.CardsOnTable[i - 1].Name}, {GameTable.CardsOnTable[i - 1].Suit}");
                                    }
                                }
                                else // (tempdefence == null)
                                {
                                    DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                                    for (int i = 0; i <= GameTable.CardsOnTable.Count - 1; i++)
                                    {
                                        CPU.CardsOnHands.Add(GameTable.CardsOnTable[i]);
                                    }
                                    GameTable.CardsOnTable.Clear();
                                    Console.WriteLine($"There are {DeckOnTable._deckOfCards.Count} cards in Deck");
                                    Turn = 0;
                                }
                            }
                            else
                            {
                                DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                                DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                                GameTable.CardsOnTable.Clear();
                                Turn = 1;
                            }

                        }
                        else //Table.CardsOnTable.Count != 0
                        {
                            var possibleAttackCards = Man.IfCanAttack(GameTable.CardsOnTable);
                            Man.ShowOnHands();
                            Console.WriteLine($"You can use these card(s):");
                            foreach (Card i in possibleAttackCards)
                                i.Show();
                            if (possibleAttackCards.Count != 0 && CPU.CardsOnHands.Count != 0)
                            {
                                Console.WriteLine($"There are {CPU.CardsOnHands.Count} cards in CPU hands");
                                var Attack = Man.ManAttack(possibleAttackCards);
                                GameTable.AddCardsToTable(Attack);
                                if (Attack != null)
                                {
                                    Card tempdefence = CPU.CPUDefense(Attack);
                                    if (tempdefence != null)
                                    {
                                        GameTable.AddCardsToTable(tempdefence);
                                        Console.WriteLine($"Cards on table are:");
                                        for (int i = 1; i <= GameTable.CardsOnTable.Count; i++)
                                        {
                                            Console.WriteLine($"{i} - {GameTable.CardsOnTable[i - 1].Name}, {GameTable.CardsOnTable[i - 1].Suit}");
                                        }
                                    }
                                    else // (tempdefence == null)
                                    {
                                        DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                                        for (int i = 0; i <= GameTable.CardsOnTable.Count - 1; i++)
                                        {
                                            CPU.CardsOnHands.Add(GameTable.CardsOnTable[i]);
                                        }
                                        GameTable.CardsOnTable.Clear();
                                        Console.WriteLine($"There are {DeckOnTable._deckOfCards.Count} cards in Deck");
                                        Turn = 0;
                                    }
                                }
                                else
                                {
                                    DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                                    DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                                    GameTable.CardsOnTable.Clear();
                                    Console.WriteLine($"There are {DeckOnTable._deckOfCards.Count} cards in Deck");
                                    Turn = 1;
                                }
                            }
                            else // (possibleAttackCards == 0)
                            {
                                Console.WriteLine($"No cards to attack");
                                DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                                DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                                GameTable.CardsOnTable.Clear();
                                Console.WriteLine($"There are {DeckOnTable._deckOfCards.Count} cards in Deck");
                                Turn = 1;
                            }
                        }

                    }
                    else//turn ==1
                    {
                        if (Man.CardsOnHands.Count > 0 && CPU.CardsOnHands.Count > 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"CPU's turn to GO!");
                            Console.WriteLine($"There are {CPU.CardsOnHands.Count} cards in CPU hands");
                            if (GameTable.CardsOnTable.Count == 0)
                            {
                                //CPU.ShowOnHands();
                                Man.ShowOnHands();
                                var Attack = CPU.CPUAttack();
                                GameTable.AddCardsToTable(Attack);
                                Card tempdefence = Man.ManDefense(Attack);
                                if (tempdefence != null)
                                {
                                    GameTable.AddCardsToTable(tempdefence);
                                    Console.WriteLine($"Cards on table are:");
                                    for (int i = 1; i <= GameTable.CardsOnTable.Count; i++)
                                    {
                                        Console.WriteLine($"{i} - {GameTable.CardsOnTable[i - 1].Name}, {GameTable.CardsOnTable[i - 1].Suit}");
                                    }
                                }
                                else // (tempdefence == null)
                                {
                                    DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                                    for (int i = 0; i <= GameTable.CardsOnTable.Count - 1; i++)
                                    {
                                        Man.CardsOnHands.Add(GameTable.CardsOnTable[i]);
                                    }
                                    GameTable.CardsOnTable.Clear();
                                    Console.WriteLine($"There are {DeckOnTable._deckOfCards.Count} cards in Deck");
                                    Turn = 1;
                                }
                            }
                            else //Table.CardsOnTable.Count >0
                            {
                                var possibleAttackCards = CPU.IfCanAttack(GameTable.CardsOnTable);
                                if (possibleAttackCards != null && Man.CardsOnHands.Count != 0)
                                {
                                    //CPU.ShowOnHands();
                                    Man.ShowOnHands();
                                    var Attack = CPU.CPUAttack(possibleAttackCards);
                                    GameTable.AddCardsToTable(Attack);
                                    Card tempdefence = Man.ManDefense(Attack);
                                    if (tempdefence != null)
                                    {
                                        GameTable.AddCardsToTable(tempdefence);
                                        Console.WriteLine($"Cards on table are:");
                                        for (int i = 1; i <= GameTable.CardsOnTable.Count; i++)
                                        {
                                            Console.WriteLine($"{i} - {GameTable.CardsOnTable[i - 1].Name}, {GameTable.CardsOnTable[i - 1].Suit}");
                                        }
                                    }
                                    else // (tempdefence == null)
                                    {
                                        DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                                        for (int i = 0; i <= GameTable.CardsOnTable.Count - 1; i++)
                                        {
                                            Man.CardsOnHands.Add(GameTable.CardsOnTable[i]);
                                        }
                                        GameTable.CardsOnTable.Clear();
                                        Console.WriteLine($"There are {DeckOnTable._deckOfCards.Count} cards in Deck");
                                        Turn = 1;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"CPU has no cards to attack");
                                    DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                                    DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                                    GameTable.CardsOnTable.Clear();
                                    Console.WriteLine($"There are {DeckOnTable._deckOfCards.Count} cards in Deck");
                                    Turn = 0;
                                }
                            }
                        }
                    }
                }

                if (Man.CardsOnHands.Count == 0 && CPU.CardsOnHands.Count == 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"It is draw in this Game!!!!!!");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else if (Man.CardsOnHands.Count == 0 && CPU.CardsOnHands.Count > 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Congratulations {UserName}, you are winner!!!!!!");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{UserName} you lose this time");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");

                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine("--------------Press Y to start again or any button to EXIT-------------------------------------");
                string TempWantToContinue = Console.ReadLine();
                WantToContinue = TempWantToContinue.ToUpper();
            }
                Environment.Exit(0);
        }
            
    }
}
