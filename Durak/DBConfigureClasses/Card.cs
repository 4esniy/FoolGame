using System;
using System.ComponentModel.DataAnnotations;

namespace Durak
{
    public class Card
    {
        /// <summary>
        /// Set identifier to a card instance
        /// </summary>
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public bool Trump { get; set; }

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
