using System.Diagnostics;
using Durak.Interfaces;
using Durak.Strategies;

namespace Durak
{
    public class StrategyFactory : IStrategyFactory
    {
        private IConfigurationSetter _configurationSetter;

        public StrategyFactory(IConfigurationSetter configurationSetter)
        {
            _configurationSetter = configurationSetter;
        }
        public IStrategy CreateHumanStrategy()
        {
            return new HumanStrategy(_configurationSetter);
        }

        public IStrategy CreateStrategyA()
        {
            return new StrategyA(_configurationSetter);
        }

        public IStrategy CreateStrategyB()
        {
            return new StrategyB(_configurationSetter);
        }
    }
}
