using Durak.Interfaces;

namespace Durak
{
    public class PlayerFactory : IPlayerFactory
    {
        public IConfigurationSetter ConfigurationSetter { get; }


        public PlayerFactory(IConfigurationSetter configurationSetter)
        {
            ConfigurationSetter = configurationSetter;
        }

        public Player CreatePlayer(IStrategy strategy)
        {
            return new Player(ConfigurationSetter, strategy);
        }
    }
}
