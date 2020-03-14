using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    /// <summary>
    /// 
    /// </summary>
    internal class Card
    {
        private int _rank;

        /// <summary>
        /// 
        /// </summary>
        internal int Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
            }
        }
        internal int rank { get; private set; }
        internal string name { get; private set; }
        internal string suit { get; private set; }
        internal bool trump { get; private set; }
        internal static List<Card> Deck = new List<Card>();
        internal static string[] Names = { "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Lady", "King", "Ace" };
        internal static string[] Suits = { "Diamonds", "Spades", "Clubs", "Hearts" };

        private Card(int rank, string Name, string Suit, bool Trump)
        {
            _rank = rank;
            name = Name;
            this.suit = Suit;
            this.trump = Trump;
        }

        internal static void CreateCard(int Rank, string Name, string Suit, bool Trump)
        {
            Card c = new Card(Rank, Name, Suit, Trump);
            Deck.Add(c);
        }

        internal static void CreateDeck(int Trump)
        {

            foreach (string str in Suits)
            {
                for (int i = 0, j = 0; i < 9; i++, j++)
                {
                    if (str == Suits[Trump])
                        CreateCard(i, Names[j], str, true);
                    else
                        CreateCard(i, Names[j], str, false);
                }
            }
        }

        internal static void ShowCards() //Just to check that cards are created
        {
            foreach (Card i in Deck)
                i.Show();
        }

        internal void Show()
        {
            if (trump == true)
                Console.WriteLine($"{name}, {suit.ToUpper()}");
            else
                Console.WriteLine($"{name}, {suit}");
        }

        public static void ShuffleDeck(List<Card> Deck)
        {
            Random rnd = new Random();
            int n = Deck.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n);
                Card value = Deck[k];
                Deck[k] = Deck[n];
                Deck[n] = value;
            }
        }


        public static int ChooseMinRankCard(List<Card> SomeCards, bool WithTrump)
        {
            if (WithTrump == false) //If false than choosen min between NON-trump cards
            {
                List<Card> temp = new List<Card>();
                for (int i = 1; i <= SomeCards.Count; i++)
                {
                    if (SomeCards[i - 1].trump != true)
                        temp.Add(SomeCards[i - 1]);
                }
                if (temp.Count == 0)
                {
                    return 100;
                }
                else
                {
                    int n = temp.Count - 1;
                    int minCardRank = temp[n].rank;
                    int minIndex = n;

                    while (n > 0)
                    {
                        if (minCardRank - temp[n - 1].rank > 0)
                        {
                            minCardRank = temp[n - 1].rank;
                            minIndex = n - 1;
                            n--;
                        }
                        else
                        {
                            n--;
                        }
                    }
                    return CompareCards(SomeCards, temp[minIndex]);
                }
            }

            else //WithTrump == true
            {
                List<Card> temp = new List<Card>();
                for (int i = 1; i <= SomeCards.Count; i++)
                {
                    if (SomeCards[i - 1].trump == true)
                        temp.Add(SomeCards[i - 1]);
                }
                if (temp.Count == 0)
                {
                    return 100;
                }
                else
                {
                    int n = temp.Count - 1;
                    int minCardRank = temp[n].rank;
                    int minIndex = n;

                    while (n > 0)
                    {
                        if (minCardRank - temp[n - 1].rank > 0)
                        {
                            minCardRank = temp[n - 1].rank;
                            minIndex = n - 1;
                            n--;
                        }
                        else
                        {
                            n--;
                        }
                    }
                    return CompareCards(SomeCards, temp[minIndex]);
                }
            }
        }

        public static int CompareCards(List<Card> CardsOnHands, Card CardToCompare) //show index in Cards on hands with the compared card
        {
            int indexOfCard=0;
            for (int i = 0; i < CardsOnHands.Count; i++)
            {
                if (CardsOnHands[i].suit == CardToCompare.suit)
                    if (CardsOnHands[i].rank == CardToCompare.rank)
                        indexOfCard = i;
            }
            return indexOfCard;
        }
    }
}
