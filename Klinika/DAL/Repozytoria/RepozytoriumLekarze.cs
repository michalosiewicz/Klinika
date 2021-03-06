using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Klinika.DAL.Repozytoria
{
    using Encje;

    static class RepozytoriumLekarze
    {
        private const string WSZYSCY_LEKARZE = "SELECT * FROM lekarze";

        public static List<Lekarz> PobierzWszystkichLekarzy()
        {
            List<Lekarz> lekarze = new List<Lekarz>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_LEKARZE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    lekarze.Add(new Lekarz(reader));
                connection.Close();
            }
            return lekarze;
        }
    }
}
