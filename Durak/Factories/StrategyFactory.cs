using System.Diagnostics;
using Durak.Interfaces;
using Durak.Strategies;

namespace Durak
{
    public class StrategyFactory : IStrategyFactory
    {
        private IConfigurationSetter _configurationSetter;
        private IConsoleReadWrap _consoleRead;

        public StrategyFactory(IConfigurationSetter configurationSetter , IConsoleReadWrap consoleRead)
        {
            _configurationSetter = configurationSetter;
            _consoleRead = consoleRead;
        }

        public IStrategy CreateHumanStrategy()
        {
            return new HumanStrategy(_configurationSetter, _consoleRead);
        }

        public IStrategy CreateStrategyA()
        {
            return new StrategyA(_configurationSetter, _consoleRead);
        }

        public IStrategy CreateStrategyB()
        {
            return new StrategyB(_configurationSetter, _consoleRead);
        }
    }
}
