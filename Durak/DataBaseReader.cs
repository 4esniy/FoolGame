using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Durak.Interfaces;

namespace Durak
{
    class DataBaseReader : IDataReader
    {
        private readonly int _languageType;
        private Dictionary<string, string> _textCollection = new Dictionary<string, string>();

        public DataBaseReader(int languageType)
        {
            _languageType = languageType;
        }

        public Dictionary<string, string> Read()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Language_config"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = null;
                switch (_languageType)
                {
                    case 1:
                        using (command = new SqlCommand("SELECT * FROM [App-eng]", con)) ;
                        break;
                    case 2:
                        using (command = new SqlCommand("SELECT * FROM [App-rus]", con)) ;
                        break;
                }

                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _textCollection.Add((string)reader["key_word"], (string)reader["text_value"]);
                    }
                }
                Console.WriteLine(_textCollection.Count());
            }
            return _textCollection;
        }
    }
}
