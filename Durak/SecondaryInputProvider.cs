using System;
using Durak.Interfaces;

namespace Durak
{
    class SecondaryInputProvider : ISecondaryInputProvider
    {
        public IConsoleReadWrap _consoleReadWrap { get; }
        public IConfigurationSetter _configurationSetter { get; }

        public SecondaryInputProvider(IConfigurationSetter configurationSetter, IConsoleReadWrap consoleReadWrap)
        {
            _consoleReadWrap = consoleReadWrap;
            _configurationSetter = configurationSetter;
        }

        public string ReturnUserNameInputValue()
        {
            string userName = null;
            Console.WriteLine($"{_configurationSetter.Message.enterName_12_}"); //Enter YOUR name and press Enter button:
            try
            {
                userName = Convert.ToString(_consoleReadWrap.ConsoleReadLine());
                if (userName.Length > 10 || userName.Length == 0)
                    throw new ArgumentOutOfRangeException(_configurationSetter.Alert.enterNotLessThan10_4_);
                if (string.IsNullOrWhiteSpace(userName))
                    throw new ArgumentNullException(_configurationSetter.Alert.userNameNotEmpty_5_);
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                ReturnUserNameInputValue();
            }
            catch (ArgumentNullException)
            {
                //log
                ReturnUserNameInputValue();
            }
            return userName;
        }

        public string ReturnStrategyTypeInputValue()
        {
            string CPUstrategyType = null;
            Console.WriteLine($"{_configurationSetter.Message.enterCpuStrategy_14_}"); //Enter Computer strategy type and press Enter button:
            Console.WriteLine($"{_configurationSetter.Constant.strategy_1_4_} - {_configurationSetter.Message.firstVar_15_}"); //First Variant
            Console.WriteLine($"{_configurationSetter.Constant.strategy_2_5_} - {_configurationSetter.Message.secondVar_16_}"); //Second Variant
            try
            {
                CPUstrategyType = (Convert.ToString(_consoleReadWrap.ConsoleReadLine())).ToUpper();
                if (!CPUstrategyType.Equals(_configurationSetter.Constant.strategy_1_4_) &&
                    !CPUstrategyType.Equals(_configurationSetter.Constant.strategy_2_5_))
                    throw new ArgumentOutOfRangeException(_configurationSetter.Alert.noSuchStrategy_6_);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //log
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                ReturnStrategyTypeInputValue();
            }

            return CPUstrategyType;
        }

    }
}
