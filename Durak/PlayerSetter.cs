using System;
using Durak.Interfaces;
using Durak.Properties;
using Durak.Strategies;

namespace Durak
{
    class PlayerSetter : IPlayerSetter
    {
        public Player player1 { get; }
        public Player player2 { get; }
        public string UserName { get; }
        private IConfigurationSetter _configuration;

        public PlayerSetter(IConfigurationSetter configuration)
        {
            try
            {
                _configuration = configuration;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"{nameof(PlayerSetter)}received empty parameters. {e.Message}");
                Console.ReadKey();
                Environment.Exit(0);
            }

            bool flag1 = true;
            bool flag2 = true;
            IStrategy player1_strategy = new HumanStrategy(_configuration);
            player1 = new Player(_configuration, player1_strategy);
            string CPUstrategyType = null;

            while (flag1)
            {
                if (UserName == null)
                {
                    Console.WriteLine($"{_configuration.Message.enterName_12_}"); //Enter YOUR name and press Enter button:
                    UserName = Convert.ToString(Console.ReadLine());
                    if (UserName.Length > 10)
                        Console.WriteLine($"{_configuration.Alert.enterNotLessThan10_4_}"); //Enter not less than 10 characters
                    else if (string.IsNullOrWhiteSpace(UserName))
                        Console.WriteLine($"{_configuration.Alert.userNameNotEmpty_5_}"); //User name can not be empty
                    else
                        flag1 = false;
                }
                else
                    flag1 = false;

            }

            while (flag2)
            {
                Console.WriteLine($"{_configuration.Message.enterCpuStrategy_14_}"); //Enter Computer strategy type and press Enter button:
                Console.WriteLine($"{_configuration.Constant.strategy_1_4_} - {_configuration.Message.firstVar_15_}"); //First Variant
                Console.WriteLine($"{_configuration.Constant.strategy_2_5_} - {_configuration.Message.secondVar_16_}"); //Second Variant
                CPUstrategyType = (Convert.ToString(Console.ReadLine())).ToUpper();
                if (CPUstrategyType.Length > 1 || string.IsNullOrWhiteSpace(CPUstrategyType))
                    Console.WriteLine($"{_configuration.Alert.noSuchStrategy_6_}"); //There is no such strategy
                else if (CPUstrategyType.Equals(_configuration.Constant.strategy_1_4_))
                    flag2 = false;
                else if (CPUstrategyType.Equals(_configuration.Constant.strategy_2_5_))
                    flag2 = false;
            }

            if (CPUstrategyType == _configuration.Message.firstVar_15_)
            {
                IStrategy player2_strategy = new StrategyA(configuration);
                player2 = new Player(_configuration, player2_strategy);
            }
            else
            {
                IStrategy player2_strategy = new StrategyB(configuration);
                player2 = new Player(_configuration, player2_strategy);
            }
        }
    }
}
