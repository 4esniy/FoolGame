using Durak.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;

namespace Durak
{
    public class GameSetter : IGameSetter
    {
        public List<Player> Players { get; } = new List<Player>();
        public int GameType { get; }

        public ISecondaryInputProvider InputProvider { get; }
        public IConfigurationSetter LanguageSet { get; }
        public IPlayerFactory PlayerFactory { get; }
        public IStrategyFactory StrategyFactory { get; }


        public GameSetter(IConfigurationSetter languageSet, ISecondaryInputProvider inputProvider,
            IPlayerFactory playerFactory, IStrategyFactory strategyFactory)
        {
            if (languageSet == null || playerFactory == null || strategyFactory == null || inputProvider == null)
                throw new NullReferenceException(nameof(GameSetter));

            LanguageSet = languageSet;
            PlayerFactory = playerFactory;
            StrategyFactory = strategyFactory;
            InputProvider = inputProvider;

            GameType = inputProvider.ReturnTypeOfGame();
            if (GameType == 1)
            {
                CreatePlayersFor36CardGame();
            }

            if (GameType == 2)
            {
                CreatePlayersFor54CardGame();
            }
        }

        public void CreatePlayersFor36CardGame()
        {
            Players.Add(PlayerFactory.CreatePlayer(StrategyFactory.CreateHumanStrategy()));
            Log.Information($"Created Player {Players[0]}");

            string cpuStrategyType = InputProvider.ReturnStrategyTypeInputValue();
            Log.Information($"Made manual choose. Chosen {cpuStrategyType} type");
            if (cpuStrategyType == LanguageSet.Constant.strategy_1_4_)
                Players.Add(PlayerFactory.CreatePlayer(StrategyFactory.CreateStrategyA()));
            if (cpuStrategyType == LanguageSet.Constant.strategy_2_5_)
                Players.Add(PlayerFactory.CreatePlayer(StrategyFactory.CreateStrategyB()));
            Log.Information($"Created Player {Players[1]}");
        }

        public void CreatePlayersFor54CardGame()
        {
            NotImplementedException e;
        }

    }
}
