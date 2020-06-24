namespace Durak.Interfaces
{
    public interface IGamesFactory
    {
         ICardGameRules Return36CardsFoolGame(IConfigurationSetter languageSet, IDeck deck,
             IGameSetter gameSetter, IConsoleReadWrap consoleReadWrap, IUserIdetifier userIdentifier);
         ICardGameRules Return54CardsFoolGame();
    }
}
