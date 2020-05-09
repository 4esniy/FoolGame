using Durak.Interfaces;

namespace Durak
{
    public interface IPlayerFactory
    {
        Player CreatePlayer(IStrategy strategy);
    }
}