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
    public class DataBaseReader : IDataReader
    {
        public int _languageType { get; }
        private Dictionary<string, string> _textCollection;

        public DataBaseReader(int languageType)
        {
            _languageType = languageType;
        }


        public Dictionary<string, string> Read()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Language_config"].ConnectionString;
            var textCollection = new Dictionary<string, string>();
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
                        textCollection.Add((string)reader["key_word"], (string)reader["text_value"]);
                    }
                }
            }
            return _textCollection = textCollection;
        }
    }
}
