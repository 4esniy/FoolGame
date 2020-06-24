using System;
using System.Collections.Generic;
using Durak.Interfaces;
using Serilog;

namespace Durak
{
    class UserIdetifier : IUserIdetifier
    {
        public string UserName => _userName;
        private string _userName { get; set; }
        List<string> UserNames { get; } = new List<string> { "Vasya", "Petya" };
        private ISecondaryInputProvider _inputProvider;
        private IDBManager _dbManager;

        //TODO include DB Manager that reads Names from DataBase

        public UserIdetifier(ISecondaryInputProvider inputProvider, IDBManager dbManager)
        {
            _inputProvider = inputProvider;
            _dbManager = dbManager;

            Console.WriteLine("Enter you User Name");
            Console.WriteLine("0: Create New User");
            //DBManager return List<string> userNames; UserNames = userNames
            for (int i = 1; i <= UserNames.Count; i++)
            {
                Console.WriteLine($"{i}: {UserNames[i - 1]}");
            }

            int intChoiceResult = ReturnUsersChoice();
            if (intChoiceResult == 0)
            {
                _userName = ReturnNewUserName();
                while (UserNames.Contains(_userName))
                    _userName = ReturnNewUserName();

                Log.Information($"Created new user, name is {_userName}, in {nameof(UserIdetifier)}");
                //DB Creates new entity with This name in DB

            }
            else
            {
                _userName = UserNames[intChoiceResult-1];
            }

        }

        private int ReturnUsersChoice()
        {
            string choice = _inputProvider._consoleReadWrap.ConsoleReadLine();
            bool result = int.TryParse(choice, out int intChoiceResult);
            if (!result || intChoiceResult > UserNames.Count)
                ReturnUsersChoice();
            return intChoiceResult;
        }

        private string ReturnNewUserName()
        {
            string newName = _inputProvider.ReturnUserNameInputValue();
            return newName;
        }


    }
}
