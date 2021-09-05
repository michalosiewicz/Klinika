using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.DAL.Encje
{
    class Wizyta:IComparable<Wizyta>
    {
        #region Właściwości
        public uint IdWizyty { get; set; }
        public uint IdLekarza { get; set; }
        public string Pesel { get; set; }
        public DateTime Data { get; set; }
        #endregion

        #region Konstruktor
        public Wizyta(MySqlDataReader reader)
        {
            IdWizyty = uint.Parse(reader["id_w"].ToString());
            IdLekarza = uint.Parse(reader["id_l"].ToString());
            Pesel = reader["pesel"].ToString();
            Data = DateTime.Parse(reader["data"].ToString());
        }
        #endregion

        public override string ToString()
        {
            return Data.ToShortTimeString();
        }

        public int CompareTo(Wizyta other)
        {
            if (this.Pesel != "" && other.Pesel == "")
                return 1;
            else if (this.Pesel == "" && other.Pesel != "")
                return -1;
            else
                return this.Data.CompareTo(other.Data);
        }
    }
}
