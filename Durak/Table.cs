using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    public class Table
    {
        internal List<Card> CardsOnTable = new List<Card>();

        internal void ShowCards() 
        {
            foreach (Card i in CardsOnTable)
                i.Show();
        }

        internal void AddCardsToTable(Card ActionCard)
        {
            CardsOnTable.Add(ActionCard);
        }

    }
}
