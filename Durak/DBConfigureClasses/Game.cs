using System.Collections.Generic;
using Durak.Interfaces;

namespace Durak
{
    public class Game
    {
        public int GameID { get;}
        public List<Player> Players{ get;}
        public Deck Deck { get;}

        public Game(int gameId, List<Player> playersList, Deck deck)
        {
            GameID = gameId;
            Players = playersList;
            Deck = deck;
        }


    }
}
