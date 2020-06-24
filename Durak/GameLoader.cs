using System;
using System.Collections.Generic;
using Durak.Interfaces;
using Serilog;

namespace Durak
{
    class GameLoader : IGameLoader
    {
        public Game Game { get; }
        private int GameNum { get; }
        private List<Game> _gameList = new List<Game>();
        private ISecondaryInputProvider _inputProvider;
        private IDBManager _dbManager;
        private IUserIdetifier _userIdetifier;
        /// <summary>
        /// If user Identified in UserIdetifier class, than GamePicker loads games and Save choice to the Game linked with User,
        /// if New User, than Game remains null.
        /// </summary>
        /// <param name="inputProvider"></param>
        /// <param name="userIdetifier"></param>
        /// <param name="dbManager"></param>
        public GameLoader(ISecondaryInputProvider inputProvider, IUserIdetifier userIdetifier, IDBManager dbManager)
        {
            // DB manager load GameNames from DB linked with Name: GameType, Deck, Players
            //DBManager.load => returns List<Game>
            _inputProvider = inputProvider;
            _dbManager = dbManager;
            _userIdetifier = userIdetifier;

            
            Console.WriteLine("0: Play New Game");
            //DBManager return List<Game> _gameList; _gameList = gameList
            for (int i = 1; i <= _gameList.Count; i++)
            {
                Console.WriteLine($"{i}: {_gameList[i - 1]}");
            }

            GameNum = ReturnUsersChoice();
            if (GameNum > 1 && GameNum < _gameList.Count)
            {
                //Game = DBManager.Load(_gameList[GameType];
                Log.Information($"Creater List of available saved games, in {nameof(GameLoader)}");
                //DB Creates new entity with This name in DB
            }
        }

        private int ReturnUsersChoice()
        {
            string choice = _inputProvider._consoleReadWrap.ConsoleReadLine();
            bool result = int.TryParse(choice, out int intChoiceResult);
            if (!result || intChoiceResult > _gameList.Count)
                ReturnUsersChoice();
            return intChoiceResult;
        }
    }
}
