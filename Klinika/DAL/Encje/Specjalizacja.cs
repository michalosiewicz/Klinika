using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Encje
{
    class Specjalizacja
    {
        public string Nazwa { get; set; }

        public Specjalizacja(MySqlDataReader reader)
        {
            Nazwa = reader["nazwa"].ToString();
            
        }

        public override string ToString()
        {
            return $"{Nazwa}";
        }
    }
}
