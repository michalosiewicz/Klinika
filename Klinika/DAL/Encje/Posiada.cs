using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Encje
{
    class Posiada
    {
        public string Nazwa { get; set; }
        public uint IdLekarza { get; set; }

        public Posiada(MySqlDataReader reader)
        {
            Nazwa = reader["nazwa"].ToString();
            IdLekarza = uint.Parse(reader["id_l"].ToString());
        }

    }
}
