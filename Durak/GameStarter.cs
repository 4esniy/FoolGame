using Durak.Interfaces;
using Durak.Properties;

namespace Durak
{
    internal class GameStarter
    {
        public GameStarter()
        {
            IConfigurationSetter languageSet = new ConfigurationSetter();
            IPlayerSetter playerSetter = new PlayerSetter(languageSet);
            IDeck deck = new Deck(new DeckBuilder(languageSet.CardAttributes));
            var table = new Table(languageSet, deck, playerSetter);
        }
    }
}
