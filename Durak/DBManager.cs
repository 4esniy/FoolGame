using System;
using System.Collections.Generic;
using Durak.Interfaces;

namespace Durak
{
    class DBManager : IDBManager
    {
        public void SaveDataInDB()
        {
            Console.WriteLine("Data saved in DB");
        }

        public void LoadDataFromDB()
        {
            Console.WriteLine("Data loaded fromDB");
        }

        public List<Game> LoadGamesFromDB()
        {
            Console.WriteLine("Data loaded fromDB");
            return null;
        }


    }
}
