using System.Collections.Generic;

namespace Durak.Interfaces
{
    interface IDeck
    {
        List<Card> _deckOfCards { get; }
        void GiveCardFromDeck(int i, Player T);
        string ShowTrumpCard();
        int HowManyCardsInDeck();
    }
}
