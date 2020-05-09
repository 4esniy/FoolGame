using Durak.Interfaces;
using System;
using Serilog;
using Serilog.Core;

namespace Durak
{
    internal class GameStarter
    {
        public GameStarter()
        {
            Logger logger = new LoggerConfiguration()
                .WriteTo.File("logfile.txt")
                .CreateLogger();
            Log.Logger = logger;

            try
            {
                IConsoleReadWrap consoleReadWrap = new ConsoleReadWrap();
                IManualInputProvider primaryManualInputProvider = new ManualInputProvider(consoleReadWrap);
                IConfigurationSetter languageSet = new ConfigurationSetter(primaryManualInputProvider);
                ISecondaryInputProvider secondaryManualInputProvider = new SecondaryInputProvider(languageSet,consoleReadWrap);
                IStrategyFactory strategyFactory = new StrategyFactory(languageSet);
                IPlayerFactory playerFactory = new PlayerFactory(languageSet);
                IPlayerSetter playerSetter = new PlayerSetter(languageSet, playerFactory, strategyFactory, secondaryManualInputProvider);
                IDeck deck = new Deck(new DeckBuilder(languageSet.CardAttributes));
                
                new Table(languageSet, deck, playerSetter);
            }
            catch (Exception e)
            {
                Log.Error($"{nameof(GameStarter)}, {e.Message}, {e.StackTrace}");
                Environment.Exit(0);
            }
        }
    }
}
