using System.Collections.Generic;

namespace Durak.Interfaces
{
    interface IDeck
    {
        List<Card> _deckOfCards { get; }
        void GiveCardFromDeck(int i, IPlayer player);
        string ShowTrumpCard();
        int HowManyCardsInDeck();
    }
}
