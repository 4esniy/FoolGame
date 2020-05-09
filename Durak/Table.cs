using System;
using System.Collections.Generic;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak
{
    public class Table
    {
        private List<Card> _cardsOnTable = new List<Card>();
        private readonly IConfigurationSetter _languageSet;
        private readonly IDeck _deck;
        private readonly IPlayerSetter _playerSetter;


        internal void CardsOnTableAre()
        {
            if (_cardsOnTable.Count == 0) return;
            Console.WriteLine($"{_languageSet.Message.cardOnTableAre_2_}");
            for (int i = 1; i <= _cardsOnTable.Count; i++)
            {
                Console.WriteLine($"{i} - {_cardsOnTable[i - 1].Name}, {_cardsOnTable[i - 1].Suit}");
            }
        }

        internal Table (IConfigurationSetter languageSet, IDeck deck, IPlayerSetter playerSetter)
        {
            if (languageSet == null || deck == null || playerSetter == null)
                throw new NullReferenceException(nameof(Table));

            _languageSet = languageSet;
            _deck = deck;
            _playerSetter = playerSetter;

            _playerSetter.CreatePlayers();
            Player Man = _playerSetter.player1;
            Player CPU = _playerSetter.player2;
            string UserName = _playerSetter.UserName;
            string WantToContinue = _languageSet.Constant.WantToContinue_7_;
            string flag = WantToContinue;
            int minCards = _languageSet.Constant.numberOfCards_1_;

            while (flag == WantToContinue)
            {
                Console.Clear();
                Console.WriteLine("{0}", _languageSet.Message.welcome_11_);//Welcome to DURAK game!!!
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{_languageSet.Message.hello_13_} {UserName}!"); //Hello
                Console.WriteLine("-----------------------------------------------------------------------------------------------");

                Console.WriteLine($"{_languageSet.Message.trumpCardIs_17_} {_deck.ShowTrumpCard()}"); //This time your Trump card is

                _deck.GiveCardFromDeck(minCards, Man); // Give 6 cards to Man
                _deck.GiveCardFromDeck(minCards, CPU); // Give 6 cards to CPU
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Random random2 = new Random(); // Automaticaly who's turn is choosen
                int turn = random2.Next(0, 2);

                while (Man.HowManyCardsOnHands() > 0 && CPU.HowManyCardsOnHands() > 0)
                {
                    if (turn == 0)
                    {
                        //tempdefence = null;
                        Console.WriteLine("-----------------------------------------------------------------------------------------------");
                        Console.WriteLine($"{_languageSet.Message.yourTurn_18_}"); //
                        Man.ShowOnHands();
                        Console.WriteLine($"{_languageSet.Message.thereIs_19_} {CPU.HowManyCardsOnHands()} {_languageSet.Message.cardsInCpuHands_20_}"); //There is(are) XX card(s) in CPU hands
                        //CPU.ShowOnHands();
                        CardsOnTableAre();

                        Card Attack = Man.Attack(_cardsOnTable);
                        if (Attack != null)
                        {
                            Man.RemoveCardFromHands(Attack);
                            _cardsOnTable.Add(Attack);
                            Card defCard = CPU.Defend(_cardsOnTable, Attack);
                            if (defCard != null)
                            {
                                CPU.RemoveCardFromHands(defCard);
                                _cardsOnTable.Add(defCard);
                                CardsOnTableAre();
                                turn = 0;
                            }
                            else // (tempdefence == null)
                            {
                                _deck.GiveCardFromDeck(Man.CardsToTake(), Man);
                                for (int i = 0; i <= _cardsOnTable.Count - 1; i++)
                                {
                                    CPU.AddCardToHands(_cardsOnTable[i]);
                                }
                                _cardsOnTable.Clear();
                                Console.WriteLine($"{_languageSet.Message.thereIs_19_} {_deck.HowManyCardsInDeck()} {_languageSet.Message.cardsInDeck_21_}"); //There is(are) XX card(s) in Deck
                                turn = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{_languageSet.Message.turnChanges_22_}"); //Turn changes
                            _deck.GiveCardFromDeck(Man.CardsToTake(), Man);
                            _deck.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                            _cardsOnTable.Clear();
                            Console.WriteLine($"{_languageSet.Message.thereIs_19_} {_deck.HowManyCardsInDeck()} {_languageSet.Message.cardsInDeck_21_}"); //
                            turn = 1;
                        }

                    }
                    else//turn ==1
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine($"{_languageSet.Message.cpuTurn_23_}"); //CPU's turn to GO!
                        Man.ShowOnHands();
                        Console.WriteLine($"{_languageSet.Message.thereIs_19_} {CPU.HowManyCardsOnHands()} {_languageSet.Message.cardsInCpuHands_20_}");
                        //CPU.ShowOnHands();
                        CardsOnTableAre();

                        Card attack = CPU.Attack(_cardsOnTable);
                        if (attack != null)
                        {
                            CPU.RemoveCardFromHands(attack);
                            _cardsOnTable.Add(attack);
                            Card defCard = Man.Defend(_cardsOnTable, attack);

                            if (defCard != null)
                            {
                                Man.RemoveCardFromHands(defCard);
                                _cardsOnTable.Add(defCard);
                                CardsOnTableAre();
                                turn = 1;
                            }
                            else // (tempdefence == null)
                            {
                                _deck.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                                for (var i = 0; i <= _cardsOnTable.Count - 1; i++)
                                {
                                    Man.AddCardToHands(_cardsOnTable[i]);
                                }
                                _cardsOnTable.Clear();
                                Console.WriteLine($"{_languageSet.Message.thereIs_19_} {_deck.HowManyCardsInDeck()} {_languageSet.Message.cardsInDeck_21_}");
                                turn = 1;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{_languageSet.Message.turnChanges_22_}"); //Turn changes
                            _deck.GiveCardFromDeck(Man.CardsToTake(), Man);
                            _deck.GiveCardFromDeck(CPU.CardsToTake(), CPU);
                            _cardsOnTable.Clear();
                            Console.WriteLine($"{_languageSet.Message.thereIs_19_} {_deck.HowManyCardsInDeck()} {_languageSet.Message.cardsInDeck_21_}");
                            turn = 0;
                        }
                    }
                }

                if (Man.HowManyCardsOnHands() == 0 && CPU.HowManyCardsOnHands() == 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{_languageSet.Message.drawThisTime_24_}"); //It is draw in this Game!!!!!!
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else if (Man.HowManyCardsOnHands() == 0 && CPU.HowManyCardsOnHands() > 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{_languageSet.Message.congratulations_25_} {UserName}, {_languageSet.Message.youAreWinner_26_}"); //Congratulations XX you are winner!!!!!!
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{UserName}, {_languageSet.Message.youLoseThisGame_27_} "); //you lose this time
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");

                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"--------------{_languageSet.Message.press_28_} {WantToContinue} {_languageSet.Message.toStartAgain_29_}-------------------------------------");
                //Press __ to start again or any button to EXIT
                flag = (Console.ReadLine())?.ToUpper();
            }
            Environment.Exit(0);
        }
    }
}
