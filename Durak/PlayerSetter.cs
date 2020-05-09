using Durak.Interfaces;
using System;
using Serilog;

namespace Durak
{
    public class PlayerSetter : IPlayerSetter
    {
        public Player player1 => _player1;
        private Player _player1 { get; set; }
        public Player player2 => _player2;
        private Player _player2 { get; set; }
        public string UserName => _userName;
        private string _userName { get; set; }
        public IConfigurationSetter Configuration { get; }
        public IPlayerFactory PlayerFactory { get; }
        public IStrategyFactory StrategyFactory { get; }
        public ISecondaryInputProvider InputProvider { get; }


        public PlayerSetter(IConfigurationSetter configuration, IPlayerFactory playerFactory, IStrategyFactory strategyFactory, ISecondaryInputProvider inputProvider)
        {
            if (configuration == null || playerFactory == null || strategyFactory == null || inputProvider== null)
                throw new NullReferenceException(nameof(PlayerSetter));

            Configuration = configuration;
            PlayerFactory = playerFactory;
            StrategyFactory = strategyFactory;
            InputProvider = inputProvider;
        }

        public void CreatePlayers()
        {
            _player1 = PlayerFactory.CreatePlayer(StrategyFactory.CreateHumanStrategy());
            _userName = InputProvider.ReturnUserNameInputValue();
            Log.Information($"Created Player {_player1}, name is {_userName}, in {nameof(CreatePlayers)}");

            string cpuStrategyType = InputProvider.ReturnStrategyTypeInputValue();
            Log.Information($"Made manual choose. Chosen {cpuStrategyType} type");
            if (cpuStrategyType == Configuration.Constant.strategy_1_4_)
                _player2 = PlayerFactory.CreatePlayer(StrategyFactory.CreateStrategyA());
            if (cpuStrategyType == Configuration.Constant.strategy_2_5_)
                _player2 = PlayerFactory.CreatePlayer(StrategyFactory.CreateStrategyB());
            Log.Information($"Created Player {_player2}");
        }

    }
}
