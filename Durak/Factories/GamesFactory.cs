using System;
using Durak.Interfaces;

namespace Durak
{
    class GamesFactory : IGamesFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageSetter"></param>
        /// <param name="gamePicker"></param>


        public ICardGameRules Return36CardsFoolGame(IConfigurationSetter languageSet, IDeck deck, 
            IGameSetter gameSetter, IConsoleReadWrap consoleReadWrap, IUserIdetifier userIdetifier)
        {
            return new FoolGame36Cards(languageSet, deck, gameSetter, consoleReadWrap, userIdetifier);
        }

        public ICardGameRules Return54CardsFoolGame()
        {
            NotImplementedException e;
            return null;
        }
    }
}
