using System;
using System.Collections.Generic;
using Durak.Interfaces;

namespace Durak
{
    class FoolGame36Cards : ICardGameRules
    {
        private List<Card> _cardsOnTable = new List<Card>();
        private List<Player> _players;
        private readonly IConfigurationSetter _languageSet;
        private readonly IDeck _deck;
        private readonly IGameSetter _gameSetter;
        private readonly IConsoleReadWrap _comReadWrap;
        //TODO Relocate to GameConfigurator
        private int MinCards { get; }
        private Player player1;
        private Player player2;

        public void CardsOnTableAre()
        {
            if (_cardsOnTable.Count == 0) return;
            Console.WriteLine($"{_languageSet.Message.cardOnTableAre_2_}");
            for (int i = 1; i <= _cardsOnTable.Count; i++)
            {
                Console.WriteLine($"{i} - {_cardsOnTable[i - 1].Name}, {_cardsOnTable[i - 1].Suit}");
            }
        }

        public void SetTurnToPlayers()
        {

            int? indexPlayerTurnTrue = null;
            for (int i = 1; i <= _players.Count; i++)
            {
                if (_players[i - 1].PlayerTurn)
                    indexPlayerTurnTrue = i;
            }

            if (indexPlayerTurnTrue == null)
            {
                Random random = new Random(); // Automaticaly who's turn is choosen
                int turn = random.Next(0, 2);
                _players[turn].PlayerTurn = true;
                player1 = _players[turn];
                if (_players[turn + 1] != null)
                    player2 = _players[turn + 1];
                else
                    player2 = _players[turn - 1];
            }
            else
            {
                player1 = _players[(int)indexPlayerTurnTrue];
                if (_players[(int)indexPlayerTurnTrue + 1] != null)
                    player2 = _players[(int)indexPlayerTurnTrue + 1];
                else
                    player2 = _players[(int)indexPlayerTurnTrue - 1];
            }

        }

        internal FoolGame36Cards(IConfigurationSetter languageSet, IDeck deck, IGameSetter gameSetter, IConsoleReadWrap comReadWrap, IUserIdetifier userIdetifier)
        {
            if (languageSet == null || deck == null || gameSetter == null || comReadWrap == null)
                throw new NullReferenceException(nameof(Table));

            _languageSet = languageSet;
            _deck = deck;
            _gameSetter = gameSetter;
            _comReadWrap = comReadWrap;

            _players = _gameSetter.Players;

            MinCards = _languageSet.Constant.numberOfCards_1_;
            string wantToContinue = _languageSet.Constant.WantToContinue_7_;
            string flag = wantToContinue;

            SetTurnToPlayers();

            while (flag == wantToContinue)
            {
                Console.Clear();
                Console.WriteLine("{0}", _languageSet.Message.welcome_11_);//Welcome to DURAK game!!!
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{_languageSet.Message.hello_13_} {userIdetifier.UserName}!"); //Hello
                Console.WriteLine("-----------------------------------------------------------------------------------------------");

                Console.WriteLine($"{_languageSet.Message.trumpCardIs_17_} {_deck.ShowTrumpCard()}"); //This time your Trump card is
                foreach (var player in _players)
                {
                    _deck.GiveCardFromDeck(MinCards, player); // Give 6 cards to every player
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");


                while (_players[0].HowManyCardsOnHands() > 0 && _players[1].HowManyCardsOnHands() > 0)
                {

                    //tempdefence = null;
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{_languageSet.Message.yourTurn_18_}"); //
                    _players[0].ShowOnHands();
                    Console.WriteLine($"{_languageSet.Message.thereIs_19_} {_players[1].HowManyCardsOnHands()} {_languageSet.Message.cardsInCpuHands_20_}"); //There is(are) XX card(s) in CPU hands
                                                                                                                                                             //CPU.ShowOnHands();
                    CardsOnTableAre();

                    Card Attack = player1.Attack(_cardsOnTable);
                    if (Attack != null)
                    {
                        player1.RemoveCardFromHands(Attack);
                        _cardsOnTable.Add(Attack);
                        Card defCard = player2.Defend(_cardsOnTable, Attack);
                        if (defCard != null)
                        {
                            player2.RemoveCardFromHands(defCard);
                            _cardsOnTable.Add(defCard);
                            CardsOnTableAre();
                        }
                        else // (tempdefence == null)
                        {
                            _deck.GiveCardFromDeck(player1.CardsToTake(), player1);
                            for (int i = 0; i <= _cardsOnTable.Count - 1; i++)
                            {
                                player2.AddCardToHands(_cardsOnTable[i]);
                            }
                            _cardsOnTable.Clear();
                            Console.WriteLine($"{_languageSet.Message.thereIs_19_} {_deck.HowManyCardsInDeck()} {_languageSet.Message.cardsInDeck_21_}"); //There is(are) XX card(s) in Deck
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{_languageSet.Message.turnChanges_22_}"); //Turn changes
                        _deck.GiveCardFromDeck(player1.CardsToTake(), player1);
                        _deck.GiveCardFromDeck(player2.CardsToTake(), player2);
                        _cardsOnTable.Clear();
                        Console.WriteLine($"{_languageSet.Message.thereIs_19_} {_deck.HowManyCardsInDeck()} {_languageSet.Message.cardsInDeck_21_}"); //
                        Player tempPlayer = player1;
                        player1 = player2;
                        player2 = tempPlayer;
                    }

                }

                if (player1.HowManyCardsOnHands() == 0 && player2.HowManyCardsOnHands() == 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{_languageSet.Message.drawThisTime_24_}"); //It is draw in this Game!!!!!!
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else if (player1.HowManyCardsOnHands() == 0 && player2.HowManyCardsOnHands() > 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{_languageSet.Message.congratulations_25_} {player1.PlayerName}, {_languageSet.Message.youAreWinner_26_}"); //Congratulations XX you are winner!!!!!!
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{player1.PlayerName}, {_languageSet.Message.youLoseThisGame_27_} "); //you lose this time
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");

                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"--------------{_languageSet.Message.press_28_} {wantToContinue} {_languageSet.Message.toStartAgain_29_}-------------------------------------");
                //Press __ to start again or any button to EXIT
                flag = (Console.ReadLine())?.ToUpper();
            }
            _comReadWrap.ReturnExit();
        }
    }
}
