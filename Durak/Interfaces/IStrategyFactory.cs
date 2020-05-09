using Durak.Interfaces;

namespace Durak
{
    public interface IStrategyFactory
    {
        IStrategy CreateHumanStrategy();
        IStrategy CreateStrategyA();
        IStrategy CreateStrategyB();
    }
}