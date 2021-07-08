using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumSpecjalizacje
    {
        private const string WSZYSTKIE_SPECJALIZACJE = "SELECT * FROM specjalizacje";

        public static List<Specjalizacja> PobierzWszystkieSpecjalizacje()
        {
            List<Specjalizacja> specjalizacje = new List<Specjalizacja>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_SPECJALIZACJE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    specjalizacje.Add(new Specjalizacja(reader));
                connection.Close();
            }
            return specjalizacje;
        }
    }
}
