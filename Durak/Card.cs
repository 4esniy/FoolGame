using System;

namespace Durak
{
    public class Card
    {
        /// <summary>
        /// Set identifier to a card instance
        /// </summary>
        public int Rank { get; }
        public string Name { get; }
        public string Suit { get; }
        public bool Trump { get; }

        public Card(int rank, string name, string suit, bool trump)
        {
            Rank = rank;
            if (name == null || suit == null)
                throw new ArgumentNullException(nameof(Card), "Unable to create Card");
            Name = name;
            Suit = suit;
            Trump = trump;
        }

        public string Show()
        {
            string nameAndSuit = Trump ? $"{Name}, {Suit.ToUpper()}" : $"{Name}, {Suit}";
            Console.WriteLine(nameAndSuit);
            return nameAndSuit;
        }

    }
}
