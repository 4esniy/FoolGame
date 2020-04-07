using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    public class Card
    {
        /// <summary>
        /// Each card have 4 identifiers
        /// </summary>
        //private int _rank;
        //private string _name;
        //private string _suit;
        //private bool _trump;

        /// <summary>
        /// Set indentifier to a card instance
        /// </summary>
        public int Rank { get ; }
        public string Name { get; }
        public string Suit { get; }
        public bool Trump { get; }

        public Card(int rank, string name, string suit, bool trump)
        {
            Rank = rank ;
            Name = name ;
            Suit = suit ;
            Trump = trump;
        }

        internal void Show()
        {
            if (Trump == true)
                Console.WriteLine($"{Name}, {Suit.ToUpper()}");
            else
                Console.WriteLine($"{Name}, {Suit}");
        }

    }
}
