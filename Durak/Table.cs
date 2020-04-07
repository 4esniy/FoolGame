using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Durak
{
    public class Table
    {
        private List<Card> _cardsOnTable = new List<Card>();
        private IMessages _message;
        private IAlerts _alert;
        private IDefaultConstants _constant;
        private int languageType = 0;
        //----------------------------------------------------------------------------------------------
        // these messages are default
        string message = ConfigurationManager.AppSettings["Message"];
        string message_ = ConfigurationManager.AppSettings["Message_"];
        string message__ = ConfigurationManager.AppSettings["Message__"];
        //----------------------------------------------------------------------------------------------
        internal Table()
        {
            bool Continue = true;
            string input = null;

            #region Check the input
            
            while (Continue)
            {
                Console.WriteLine($"{message}"); //Choose language and press Enter: 1- English, 2 - Русский
                input = Console.ReadLine();

                bool Contin = true;
                while (Contin)
                {
                    try
                    {
                        if (input.Length > 1 || input==null)
                        {
                            Console.WriteLine($"{message__}"); //Choose 1 or 2
                            Contin = false;
                        }
                        else
                        {
                            int m = Convert.ToInt32(input);
                            if (m == 1 || m == 2)
                            {
                                Contin = false;
                                Continue = false;
                            }
                            else
                            {
                                Console.WriteLine($"{message__}"); //Choose 1 or 2
                                Contin = false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"{message_}"); //You should enter an integer
                        input = Console.ReadLine();
                    }
                }
            }
            #endregion
            languageType = int.Parse(input);

           _message = new Messages(languageType);
           _alert = new Alerts(languageType);
           _constant = new DefaultConstants(languageType);

        }

        internal void AddCardsToTable(Card ActionCard)
        {
            _cardsOnTable.Add(ActionCard);
        }

        internal void CardsOnTableAre()
        {
            if (_cardsOnTable.Count !=0)
            {
                Console.WriteLine($"{_message.cardOnTableAre_2_}");
                for (int i = 1; i <= _cardsOnTable.Count; i++)
                {
                    Console.WriteLine($"{i} - {_cardsOnTable[i - 1].Name}, {_cardsOnTable[i - 1].Suit}");
                }
            }
        }

        internal void RunTheGame()
        {
            string WantToContinue = _constant.WantToContinue_7_;
            string flag = WantToContinue;
            string names = _constant.cardNames_2_;
            string suits = _constant.cardSuits_3_;
            string Strategy_1char = _constant.strategy_1_4_;
            string Strategy_2char = _constant.strategy_2_5_;
            int minCards = _constant.numberOfCards_1_;

            while (flag == WantToContinue)
            {
                bool Continue1 = true;
                bool Continue2 = true;
                string UserName = null;
                string CPUName = "CPU_1";
                string StrategyType = null;
                Console.Clear();
                Console.WriteLine("{0}", _message.welcome_11_);//Welcome to DURAK game!!!
                while (Continue1)
                {
                    if (UserName == null)
                    {
                        Console.WriteLine($"{_message.enterName_12_}"); //Enter YOUR name and press Enter button:
                        UserName = Convert.ToString(Console.ReadLine());
                        if (UserName.Length > 10)
                            Console.WriteLine($"{_alert.enterNotLessThan10_4_}"); //Enter not less than 10 characters
                        else if (string.IsNullOrWhiteSpace(UserName))
                            Console.WriteLine($"{_alert.userNameNotEmpty_5_}"); //User name can not be empty
                        else
                            Continue1 = false;
                    }
                    else
                        Continue1 = false;

                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{_message.hello_13_} {UserName}!"); //Hello
                Console.WriteLine("-----------------------------------------------------------------------------------------------");

                while (Continue2)
                {
                    Console.WriteLine($"{_message.enterCpuStrategy_14_}"); //Enter Computer strategy type and press Enter button:
                    Console.WriteLine($"{_constant.strategy_1_4_} - {_message.firstVar_15_}"); //First Variant
                    Console.WriteLine($"{_constant.strategy_2_5_} - {_message.secondVar_16_}"); //Second Variant
                    StrategyType = (Convert.ToString(Console.ReadLine())).ToUpper();
                    if (StrategyType.Length > 1 || string.IsNullOrWhiteSpace(StrategyType))
                        Console.WriteLine($"{_alert.noSuchStrategy_6_}"); //There is no such strategy
                    else if (StrategyType.Equals(Strategy_1char))
                        Continue2 = false;
                    else if (StrategyType.Equals(Strategy_2char))
                        Continue2 = false;
                }

                //TODO: Include Multiplayer
                Deck DeckOnTable = new Deck(names, suits);
                Player Man = new Player(languageType, null, UserName);
                Player CPU = new Player(languageType, StrategyType, CPUName);

                //Choose randomly TrumpCard
                Random Random1 = new Random();
                int Trump = Random1.Next(0, 4);

                Console.WriteLine($"{_message.trumpCardIs_17_} {DeckOnTable.ShowTrumpCard(Trump)}"); //This time your Trump card is

                DeckOnTable.CreateDeck(Trump); //Creation of Deck
                //DeckOnTable.ShowCards();
                //Console.ReadKey();
                DeckOnTable.ShuffleDeck(); //Shuffle all cards in Deck
                DeckOnTable.GiveCardFromDeck(minCards, Man); // Give 6 cards to Man
                DeckOnTable.GiveCardFromDeck(minCards, CPU); // Give 6 cards to CPU
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Random Random2 = new Random(); // Automaticaly who's turn is choosen
                int Turn = Random2.Next(0, 2);

                while (Man.HowManyCardsOnHands() > 0 && CPU.HowManyCardsOnHands() > 0)
                {
                    if (Turn == 0)
                    {
                        //tempdefence = null;
                        Console.WriteLine("-----------------------------------------------------------------------------------------------");
                        Console.WriteLine($"{_message.yourTurn_18_}"); //
                        Man.ShowOnHands();
                        Console.WriteLine($"{_message.thereIs_19_} {CPU.HowManyCardsOnHands()} {_message.cardsInCpuHands_20_}"); //There is(are) XX card(s) in CPU hands
                        //CPU.ShowOnHands();
                        CardsOnTableAre();

                        Card Attack = Man.Attack(_cardsOnTable);
                        if (Attack != null)
                        {
                            Man.RemoveCardFromHads(Attack);
                            _cardsOnTable.Add(Attack);
                            Card defCard = CPU.Defend(_cardsOnTable, Attack);
                            if (defCard != null)
                            {
                                CPU.RemoveCardFromHads(defCard);
                                _cardsOnTable.Add(defCard);
                                CardsOnTableAre();
                                Turn = 0;
                            }
                            else // (tempdefence == null)
                            {
                                DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                                for (int i = 0; i <= _cardsOnTable.Count - 1; i++)
                                {
                                    CPU.AddCardToHands(_cardsOnTable[i]);
                                }
                                _cardsOnTable.Clear();
                                Console.WriteLine($"{_message.thereIs_19_} {DeckOnTable.HowManyCardsInDeck()} {_message.cardsInDeck_21_}"); //There is(are) XX card(s) in Deck
                                Turn = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{_message.turnChanges_22_}"); //Turn changes
                            DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                            DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                            _cardsOnTable.Clear();
                            Console.WriteLine($"{_message.thereIs_19_} {DeckOnTable.HowManyCardsInDeck()} {_message.cardsInDeck_21_}"); //
                            Turn = 1;
                        }

                    }
                    else//turn ==1
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine($"{_message.cpuTurn_23_}"); //CPU's turn to GO!
                        Man.ShowOnHands();
                        Console.WriteLine($"{_message.thereIs_19_} {CPU.HowManyCardsOnHands()} {_message.cardsInCpuHands_20_}");
                        //CPU.ShowOnHands();
                        CardsOnTableAre();

                        Card Attack = CPU.Attack(_cardsOnTable);
                        if (Attack != null)
                        {
                            CPU.RemoveCardFromHads(Attack);
                            _cardsOnTable.Add(Attack);
                            Card defCard = Man.Defend(_cardsOnTable, Attack);

                            if (defCard != null)
                            {
                                Man.RemoveCardFromHads(defCard);
                                _cardsOnTable.Add(defCard);
                                CardsOnTableAre();
                                Turn = 1;
                            }
                            else // (tempdefence == null)
                            {
                                DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                                for (int i = 0; i <= _cardsOnTable.Count - 1; i++)
                                {
                                    Man.AddCardToHands(_cardsOnTable[i]);
                                }
                                _cardsOnTable.Clear();
                                Console.WriteLine($"{_message.thereIs_19_} {DeckOnTable.HowManyCardsInDeck()} {_message.cardsInDeck_21_}");
                                Turn = 1;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{_message.turnChanges_22_}"); //Turn changes
                            DeckOnTable.GiveCardFromDeck(Man.CardsToTake(), Man);
                            DeckOnTable.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                            _cardsOnTable.Clear();
                            Console.WriteLine($"{_message.thereIs_19_} {DeckOnTable.HowManyCardsInDeck()} {_message.cardsInDeck_21_}");
                            Turn = 0;
                        }
                    }
                }

                if (Man.HowManyCardsOnHands() == 0 && CPU.HowManyCardsOnHands() == 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{_message.drawThisTime_24_}"); //It is draw in this Game!!!!!!
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else if (Man.HowManyCardsOnHands() == 0 && CPU.HowManyCardsOnHands() > 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{_message.congratulations_25_} {Man.PlayerName}, {_message.youAreWinner_26_}"); //Congratulations XX you are winner!!!!!!
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{Man.PlayerName}, {_message.youLoseThisGame_27_} "); //you lose this time
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");

                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"--------------{_message.press_28_} {WantToContinue} {_message.toStartAgain_29_}-------------------------------------");
                //Press __ to start again or any button to EXIT
                string TempWantToContinue = Console.ReadLine();
                flag = TempWantToContinue.ToUpper();
            }
            Environment.Exit(0);
        }
    }
}
