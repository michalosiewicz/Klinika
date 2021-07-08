using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Encje
{
    class Lekarz
    {
        public uint Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public uint Sala { get; set; }

        public Lekarz(MySqlDataReader reader)
        {
            Id = uint.Parse(reader["id_l"].ToString());
            Imie = reader["imie"].ToString();
            Nazwisko = reader["nazwisko"].ToString();
            Sala = uint.Parse(reader["sala"].ToString());
        }

        public override string ToString()
        {
            return $"Doktor {Nazwisko} {Imie}";
        }

    }
}
