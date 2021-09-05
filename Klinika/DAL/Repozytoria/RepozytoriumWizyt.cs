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

        #region Metody
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

        public static bool EdytujWizyteWBazie(string pesel,uint idWizyty)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_WIZYTE = $"UPDATE wizyty SET pesel={pesel} WHERE id_w={idWizyty}";

                MySqlCommand command = new MySqlCommand(EDYTUJ_WIZYTE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }
        #endregion
    }
}
