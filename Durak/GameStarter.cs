using Durak.Interfaces;
using System;
using Serilog;
using Serilog.Core;

namespace Durak
{
    internal class GameStarter
    {
        /// <summary>
        /// Start new Game if user new, or if User known loads previous saved games
        /// </summary>
        public GameStarter()
        {
            Logger logger = new LoggerConfiguration()
                .WriteTo.File("logfile.txt")
                .CreateLogger();
            Log.Logger = logger;

            try
            {
                IDBManager dbManager = new DBManager();
                IConsoleReadWrap consoleReadWrap = new ConsoleReadWrap();
                IManualInputProvider primaryManualInputProvider = new ManualInputProvider(consoleReadWrap);
                IConfigurationSetter languageSet = new ConfigurationSetter(primaryManualInputProvider);
                ISecondaryInputProvider secondaryInputProvider = new SecondaryInputProvider(languageSet, consoleReadWrap);
                IUserIdetifier userIdetifier = new UserIdetifier(secondaryInputProvider, dbManager);
                IGameLoader gameLoader = new GameLoader(secondaryInputProvider, userIdetifier, dbManager);

                //for new games
                if (gameLoader.Game == null)
                {
                    IGamesFactory gameCreator = new GamesFactory();
                    IStrategyFactory strategyFactory = new StrategyFactory(languageSet, consoleReadWrap);
                    IPlayerFactory playerFactory = new PlayerFactory(languageSet);
                    IGameSetter gameSetter = new GameSetter(languageSet, secondaryInputProvider, playerFactory, strategyFactory);
                    IDeck deck = new Deck(new DeckBuilder(languageSet.CardAttributes, gameSetter.GameType));
                    if (gameSetter.GameType == 1)
                    {
                        gameCreator.Return36CardsFoolGame(languageSet, deck, gameSetter, consoleReadWrap, userIdetifier); 
                    }

                    if (gameSetter.GameType == 2)
                    {
                        gameCreator.Return54CardsFoolGame();
                    }

                }
                // gameCreator.Return36CardsFoolGame(languageSet, gameLoader.Game, consoleReadWrap, userIdetifier); 

            }
            catch (Exception e)
            {
                Log.Error($"{nameof(GameStarter)}, {e.Message}, {e.StackTrace}");
                Environment.Exit(0);
            }
        }
    }
}
