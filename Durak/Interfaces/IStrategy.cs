using System.Collections.Generic;

namespace Durak.Interfaces
{
    public interface IStrategy
    {
        Card Attack(List<Card> CardsOnHands, List<Card> CardsOnTable);
        Card Defend(List<Card> CardsOnHands, List<Card> CardsOnTable, Card CardToBeat);
        List<Card> PossibleAttackCards(List<Card> CardsOnHands, List<Card> CardsOnTable);
        List<Card> PossibleDefendCards(List<Card> CardsOnHands, Card CardToBeat);
        Card ChooseMinRankCard(List<Card> SomeCards, bool WithTrump);

    }
}
