    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    public interface IPlayer
    {
        List<Card> CardsOnHands { get; }
        Card Attack(List<Card> CardsOnTable);
        Card Defend(List<Card> CardsOnTable, Card CardToBeat);
        void RemoveCardFromHands(Card CardToRemove);
        void ShowOnHands();
        int HowManyCardsOnHands();
        void AddCardToHands(Card AnyCard);
        int CardsToTake();
    }
}
