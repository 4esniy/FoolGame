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

            bool Continue = true;
            string UserName = "";
            bool tempdefence = true;

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


            //Console.ReadKey();

            Random Random1 = new Random();
            int Trump = Random1.Next(0, 4);

            Console.WriteLine($"This time your Trump card is {Card.Suits[Trump].ToUpper()}");

            Card.CreateDeck(Trump); //Creation of Deck
            Card.ShuffleDeck(Card.Deck); //Shuffle all cards in Deck
            Player Man = new Player();
            CPU CPU = new CPU();
            Table Table = new Table();
            Man.TakeCard(6); // Give 6 cards to CPU and Player
            CPU.TakeCard(6);
            Console.WriteLine("    ");
            Random Random2 = new Random(); // Automaticaly who's turn is choosen
            int Turn = Random2.Next(0, 2);

            while (Man.CardsOnHands.Count > 0 && CPU.CardsOnHands.Count > 0)
            {

                if (Turn == 0 && Man.CardsOnHands.Count > 0 && CPU.CardsOnHands.Count > 0)
                {
                    tempdefence = true;
                    Console.WriteLine("");
                    Console.WriteLine($"Your turn to GO!");
                    if (tempdefence == true)
                    {
                        
                        if (Table.CardsOnTable.Count == 0) //Check to put any or certain card
                        {
                            Man.ShowOnHands();
                            Console.WriteLine($"There are {CPU.CardsOnHands.Count} cards in CPU hands");
                            var Attack = Man.ManAttack();
                            if (Attack != null)
                            {
                                tempdefence = CPU.CPUDefense(Attack);
                                Console.WriteLine($"Cards on table are:");
                                for (int i = 1; i <= Table.CardsOnTable.Count; i++)
                                {
                                    Console.WriteLine($"{i} - {Table.CardsOnTable[i - 1].name}, {Table.CardsOnTable[i - 1].suit}");
                                }
                                if (tempdefence == false)
                                {
                                    Man.TakeCard(Man.CardsToTake());
                                    for (int i = 0; i <= Table.CardsOnTable.Count - 1; i++)
                                    {
                                        CPU.CardsOnHands.Add(Table.CardsOnTable[i]);
                                    }
                                    Table.CardsOnTable.Clear();
                                    Console.WriteLine($"There are {Card.Deck.Count} cards in Deck");
                                    Turn = 0;
                                }
                            }
                            else
                            {
                                Man.TakeCard(Man.CardsToTake());
                                CPU.TakeCard(CPU.CardsToTake());
                                Table.CardsOnTable.Clear();
                                Turn = 1;
                            }
                            
                        }
                        else //Table.CardsOnTable.Count != 0
                        {
                            var possibleAttackCards = Man.IfCanAttack(Table.CardsOnTable);
                            Man.ShowOnHands();
                            Console.WriteLine($"You can use these card(s):");
                            foreach (Card i in possibleAttackCards)
                                i.Show();
                            if (possibleAttackCards.Count != 0 && CPU.CardsOnHands.Count != 0)
                            {
                                Console.WriteLine($"There are {CPU.CardsOnHands.Count} cards in CPU hands");
                                var Attack = Man.ManAttack(possibleAttackCards);
                                if (Attack != null)
                                {
                                    tempdefence = CPU.CPUDefense(Attack);
                                    Console.WriteLine($"Cards on table are:");
                                    for (int i = 1; i <= Table.CardsOnTable.Count; i++)
                                    {
                                        Console.WriteLine($"{i} - {Table.CardsOnTable[i - 1].name}, {Table.CardsOnTable[i - 1].suit}");
                                    }
                                    if (tempdefence == false)
                                    {
                                        Man.TakeCard(Man.CardsToTake());

                                        for (int i = 0; i <= Table.CardsOnTable.Count - 1; i++)
                                        {
                                            CPU.CardsOnHands.Add(Table.CardsOnTable[i]);
                                        }
                                        Table.CardsOnTable.Clear();
                                        Console.WriteLine($"There are {Card.Deck.Count} cards in Deck");
                                        Turn = 0;
                                    }
                                }
                                else
                                {
                                    Man.TakeCard(Man.CardsToTake());
                                    CPU.TakeCard(CPU.CardsToTake());
                                    Table.CardsOnTable.Clear();
                                    Console.WriteLine($"There are {Card.Deck.Count} cards in Deck");
                                    Turn = 1;
                                }
                            }
                            else // (possibleAttackCards == 0)
                            {
                                Console.WriteLine($"No cards to attack");
                                Man.TakeCard(Man.CardsToTake());
                                CPU.TakeCard(CPU.CardsToTake());
                                Table.CardsOnTable.Clear();
                                Console.WriteLine($"There are {Card.Deck.Count} cards in Deck");
                                Turn = 1;
                            }
                        }
                    }

                }
                else//turn ==1
                {
                    if (Man.CardsOnHands.Count > 0 && CPU.CardsOnHands.Count > 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"CPU's turn to GO!");
                        tempdefence = true;
                        if (Table.CardsOnTable.Count == 0)
                        {
                            //CPU.ShowOnHands();
                            Man.ShowOnHands();
                            tempdefence = Man.ManDefense(CPU.CPUAttack()); ;
                            Console.WriteLine($"Cards on table are:");
                            for (int i = 1; i <= Table.CardsOnTable.Count; i++)
                            {
                                Console.WriteLine($"{i} - {Table.CardsOnTable[i - 1].name}, {Table.CardsOnTable[i - 1].suit}");
                            }
                            if (tempdefence == false)
                            {
                                CPU.TakeCard(CPU.CardsToTake());
                                for (int i = 0; i <= Table.CardsOnTable.Count - 1; i++)
                                {
                                    Man.CardsOnHands.Add(Table.CardsOnTable[i]);
                                }
                                Table.CardsOnTable.Clear();
                                Console.WriteLine($"There are {Card.Deck.Count} cards in Deck");
                                Turn = 1;
                            }
                        }
                        else //Table.CardsOnTable.Count >0
                        {
                            var possibleAttackCards = CPU.IfCanCPUAttack(Table.CardsOnTable);
                            if (possibleAttackCards != null && Man.CardsOnHands.Count != 0)
                            {
                                //CPU.ShowOnHands();
                                Man.ShowOnHands();
                                tempdefence = Man.ManDefense(CPU.CPUAttack(possibleAttackCards));
                                Console.WriteLine($"Cards on table are:");
                                for (int i = 1; i <= Table.CardsOnTable.Count; i++)
                                {
                                    Console.WriteLine($"{i} - {Table.CardsOnTable[i - 1].name}, {Table.CardsOnTable[i - 1].suit}");
                                }
                                if (tempdefence == false)
                                {
                                    CPU.TakeCard(CPU.CardsToTake());
                                    for (int i = 0; i <= Table.CardsOnTable.Count - 1; i++)
                                    {
                                        Man.CardsOnHands.Add(Table.CardsOnTable[i]);
                                    }
                                    Table.CardsOnTable.Clear();
                                    Console.WriteLine($"There are {Card.Deck.Count} cards in Deck");
                                    Turn = 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"CPU has no cards to attack");
                                Man.TakeCard(Man.CardsToTake());
                                CPU.TakeCard(CPU.CardsToTake());
                                Table.CardsOnTable.Clear();
                                Console.WriteLine($"There are {Card.Deck.Count} cards in Deck");
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
            Console.WriteLine($"{UserName} you lose this time");
            Console.ReadKey();
        }
    }
}
