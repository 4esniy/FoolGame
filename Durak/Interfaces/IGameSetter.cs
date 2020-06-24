using System.Collections.Generic;

namespace Durak.Interfaces
{
    public interface IGameSetter
    {
        List<Player> Players { get; }
        int GameType { get; }
    }
}
