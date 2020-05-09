using Durak.Interfaces;

namespace Durak
{
    public class PlayerFactory : IPlayerFactory
    {
        private IConfigurationSetter _configurationSetter;


        public PlayerFactory(IConfigurationSetter configurationSetter)
        {
            _configurationSetter = configurationSetter;
        }

        public Player CreatePlayer(IStrategy strategy)
        {
            return new Player(_configurationSetter,strategy);
        }
    }
}
