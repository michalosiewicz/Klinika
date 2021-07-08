using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Encje
{
    class Wizyta
    {
        public uint IdWizyty { get; set; }
        public uint IdLekarza { get; set; }
        public string Pesel { get; set; }
        public DateTime Data { get; set; }

        public Wizyta(MySqlDataReader reader)
        {
            IdWizyty = uint.Parse(reader["id_w"].ToString());
            IdLekarza = uint.Parse(reader["id_l"].ToString());
            Pesel = reader["pesel"].ToString();
            Data = DateTime.Parse(reader["data"].ToString());
        }
    }
}
