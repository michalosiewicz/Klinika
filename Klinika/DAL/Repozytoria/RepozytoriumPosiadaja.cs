using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumPosiadaja
    {
        private const string WSZYSTKIE_POSIADANIA = "SELECT * FROM posiadaja";

        public static List<Posiada> PobierzWszystkiePosiadania()
        {
            List<Posiada> posiadaja = new List<Posiada>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_POSIADANIA, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    posiadaja.Add(new Posiada(reader));
                connection.Close();
            }
            return posiadaja;
        }
    }
}
