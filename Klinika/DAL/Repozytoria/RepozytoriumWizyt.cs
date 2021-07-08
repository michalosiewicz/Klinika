using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumWizyt
    {
        private const string WSZYSTKIE_WIZYTY = "SELECT * FROM wizyty";

        public static List<Wizyta> PobierzWszystkieWizyty()
        {
            List<Wizyta> wizyty = new List<Wizyta>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_WIZYTY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    wizyty.Add(new Wizyta(reader));
                connection.Close();
            }
            return wizyty;
        }
    }
}
