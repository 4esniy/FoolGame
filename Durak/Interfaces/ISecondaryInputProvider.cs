using Durak.Interfaces;

namespace Durak
{
    public interface ISecondaryInputProvider
    {
        IConsoleReadWrap _consoleReadWrap { get; }
        string ReturnUserNameInputValue();
        string ReturnStrategyTypeInputValue();
        int ReturnTypeOfGame();
    }
}