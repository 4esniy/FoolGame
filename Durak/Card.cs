using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    class Card 
    {
        /// <summary>
        /// Each card have 4 identifiers
        /// </summary>
        private int _rank;
        private string _name;
        private string _suit;
        private bool _trump;

        /// <summary>
        /// Set indentifier to a card instance
        /// </summary>
        internal int Rank
        {
            get {return _rank; }
        }

        internal string Name
        {
            get {return _name; }
        }

        internal string Suit
        {
            get {return _suit; }
        }

        internal bool Trump
        {
            get {return _trump; }
        }

        internal Card(int rank, string name, string suit, bool trump)
        {
            _rank = rank;
            _name = name;
            _suit = suit;
            _trump = trump;
        }

        internal void Show()
        {
            if (_trump == true)
                Console.WriteLine($"{_name}, {_suit.ToUpper()}");
            else
                Console.WriteLine($"{_name}, {_suit}");
        }

    }
}
