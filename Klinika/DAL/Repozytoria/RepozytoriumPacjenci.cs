using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Klinika.DAL.Repozytoria
{
    using Encje;

    static class RepozytoriumPacjenci
    {
        private const string WSZYSCY_PACJENCI = "SELECT * FROM pacjenci";

        public static List<Pacjent> PobierzWszystkichPacjentow()
        {
            List<Pacjent> pacjenci = new List<Pacjent>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_PACJENCI, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    pacjenci.Add(new Pacjent(reader));
                connection.Close();
            }
            return pacjenci;
        }
    }
}
