using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Encje
{
    public class Pacjent:IComparable<Pacjent>
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

        public int CompareTo(Pacjent other)
        {
            if (this.Nazwisko.CompareTo(other.Nazwisko) == 0)
                return this.Imie.CompareTo(other.Imie);
            else
                return this.Nazwisko.CompareTo(other.Nazwisko);
        }
    }
}
