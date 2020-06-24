using System.Collections.Generic;
using Durak.Interfaces;

namespace Durak
{
    public class Table
    {
        private List<Player> _players { get; }
        private ICardGameRules _rules { get; }
        private Deck _deck { get; }

        public Table(Game game)
        {

            StartTheGame();
        }

        public Table(IGameSetter gameSetter, IDeck deck)
        {
            StartTheGame();
        }

        public void StartTheGame()
        {

        }
    }
}
