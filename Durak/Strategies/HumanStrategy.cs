using System;
using System.Collections.Generic;
using Durak.Interfaces;
using Durak.Properties;

namespace Durak.Strategies
{
    public class HumanStrategy : IStrategy
    {
        private IMessages _message;
        private IAlerts _alert;

        public HumanStrategy(IConfigurationSetter configuration)
        {
            try
            {
                _message = configuration.Message;
                _alert = configuration.Alert;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"{nameof(HumanStrategy)}received empty parameters. {e.Message}");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }

        //check if Player chosed right card to beat CardsOnHands or PossibleAttackCards
        public Card Attack(List<Card> CardsOnHands, List<Card> CardsOnTable)
        {
            string Input = null;
            int Enter = 0;
            bool Continue = true;
            List<Card> possibleAttackCards = null;

            if (CardsOnTable.Count != 0)
            {
                possibleAttackCards = PossibleAttackCards(CardsOnHands, CardsOnTable);
            }
            else
            {
                possibleAttackCards = CardsOnHands;
            }

            Console.WriteLine($"{_message.chooseAttackCard_3_}"); //Choose the card to attack or print 100 to skip!

            if (possibleAttackCards.Count != 0)
            {
                if (CardsOnTable.Count != 0)
                {
                    Console.WriteLine($"{_message.youMayUseTheseCards_4_}");  // You may use these card(s):  
                    foreach (Card i in possibleAttackCards)
                    {
                        if (i.Trump == false && CardsOnTable != null)
                            Console.WriteLine($"{i.Name} , {i.Suit}");
                        else
                            Console.WriteLine($"{i.Name} , {(i.Suit).ToUpper()}");
                    }
                }

                Card Temp = null;
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
                            Console.WriteLine($"{_alert.enterInteger_1_}"); //You should enter an integer
                            Input = Console.ReadLine();
                        }
                    }
                    Enter = int.Parse(Input);
                    if (Enter > 0 && Enter <= CardsOnHands.Count)
                    {
                        foreach (Card i in possibleAttackCards)
                        {
                            if (CardsOnHands[Enter - 1].Equals(i))
                            {
                                Temp = CardsOnHands[Enter - 1];
                                Continue = false;
                            }
                            else
                                Console.WriteLine($"{_message.youCannotUseCard_5_}"); //You can not use this card
                        }
                    }
                    else if (Enter > CardsOnHands.Count && Enter != 100)
                        Console.WriteLine($"{_alert.enterNotBiggerThan_2_} {CardsOnHands.Count}"); //Enter not bigger than 
                    else if (Enter == 100)
                        Continue = false;
                    else if (Enter <= 0)
                        Console.WriteLine($"{_alert.enterPositiveNumber_3_}"); //Enter positive number
                }
                return Temp;
            }
            else
            {
                Console.WriteLine($"{_message.haveNoCardsToAttack_6_}"); //You have no cards to attack, press any key to continue
                Console.ReadKey();
                return null;
            }


        }

        public Card Defend(List<Card> CardsOnTable, List<Card> CardsOnHands, Card CardToBeat)
        {
            Card defCard = null;
            string Input = "";
            int Enter = 0;
            bool Continue = true;
            List<Card> possibleDefendCards = PossibleDefendCards(CardsOnHands, CardToBeat);

            Console.WriteLine($"{_message.chooseDefendCard_7_}"); //Choose the card to defense!
            Console.WriteLine($"{_message.chooseToTakeAllCards_8_}"); //Choose 0 to take all cards on the table on hands

            if (possibleDefendCards.Count != 0)
            {
                while (Continue)
                {
                    Input = Console.ReadLine();
                    bool Contin = true;
                    while (Contin)
                    {
                        try
                        {
                            int m = Convert.ToInt32(Input);
                            Contin = false;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"{_alert.enterInteger_1_}"); //You should enter an integer
                            Input = Console.ReadLine();
                        }
                    }

                    Enter = int.Parse(Input);

                    if (Enter > 0 && Enter <= CardsOnHands.Count)
                    {
                        foreach (Card i in possibleDefendCards)
                        {
                            if (CardsOnHands[Enter - 1].Equals(i))
                                defCard = CardsOnHands[Enter - 1];
                        }

                        if (defCard != null)
                            Continue = false;
                        else
                            Console.WriteLine($"{_message.youCannotUseCard_5_}"); //You can not use this card
                    }
                    else if (Enter > CardsOnHands.Count)
                        Console.WriteLine($"{_alert.enterNotBiggerThan_2_} {CardsOnHands.Count}"); //Enter not bigger than
                    else if (Enter < 0)
                        Console.WriteLine($"{_alert.enterPositiveNumber_3_}"); //Enter positive number
                    else if (Enter == 0)
                    {
                        Console.WriteLine($"{_message.youTakeAllCards_9_}"); //You take all the cards from table!
                        defCard = null;
                        Continue = false;
                    }
                }
                return defCard;
            }
            else
            {
                Console.WriteLine($"{_message.haveNoCardsToDefend_10_}"); //You have no cards to defend, press any key to take cards
                Console.ReadKey();
                return null;
            }

        }

        public List<Card> PossibleAttackCards(List<Card> CardsOnHands, List<Card> CardsOnTable) ///check the cards on table with the cards on hand
        {
            List<Card> possibleAttackCards = new List<Card>();
            for (int i = 0; i <= CardsOnHands.Count - 1; i++)
            {
                for (int j = 1; j <= CardsOnTable.Count; j++)
                {
                    if (CardsOnHands[i].Rank == CardsOnTable[j - 1].Rank)
                    {
                        possibleAttackCards.Add(CardsOnHands[i]);
                    }
                }
            }
            return possibleAttackCards;
        }

        public List<Card> PossibleDefendCards(List<Card> CardsOnHands, Card CardToBeat) ///check the cards on table with the cards on hand
        {
            List<Card> possibleDefendCards = new List<Card>();
            for (int i = 0; i <= CardsOnHands.Count - 1; i++)
            {
                if (CardToBeat.Trump == true)
                {
                    if (CardsOnHands[i].Trump == true && CardsOnHands[i].Rank > CardToBeat.Rank)
                    {
                        possibleDefendCards.Add(CardsOnHands[i]);
                    }
                }
                else //CardToBeat.Trump == false
                {
                    if (CardsOnHands[i].Suit == CardToBeat.Suit && CardsOnHands[i].Trump == false && CardsOnHands[i].Rank > CardToBeat.Rank)
                    {
                        possibleDefendCards.Add(CardsOnHands[i]);
                    }
                    if (CardsOnHands[i].Trump == true)
                    {
                        possibleDefendCards.Add(CardsOnHands[i]);
                    }
                }
            }
            return possibleDefendCards;
        }



        public Card ChooseMinRankCard(List<Card> SomeCards, bool WithTrump)
        {
            return null;
        }
    }
}
