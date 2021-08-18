using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Encje
{
    class Pacjent
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }

        public Pacjent(MySqlDataReader reader)
        {
            Imie = reader["imie"].ToString();
            Nazwisko = reader["nazwisko"].ToString();
            Pesel = reader["pesel"].ToString();
        }

        public override string ToString()
        {
            return $"{Nazwisko} {Imie} {Pesel}";
        }
    }
}
