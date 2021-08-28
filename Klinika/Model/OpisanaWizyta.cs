using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    public class OpisanaWizyta:IComparable<OpisanaWizyta>
    {
        public string Sala { get; set; }
        public string Status { get; set; }
        public string Lekarz { get; set; }
        public string Godzina { get; set; }

        public OpisanaWizyta(string godzina,string lekarz,uint sala,string status)
        {
            Godzina = godzina;
            Lekarz = lekarz;
            Sala = sala.ToString();
            Status = status;
        }

        public int CompareTo(OpisanaWizyta opisanaWizyta)
        {
            if (this.Status.CompareTo(opisanaWizyta.Status) == 0)
                return this.Godzina.CompareTo(opisanaWizyta.Godzina);
            else
                return this.Status.CompareTo(opisanaWizyta.Status);
        }
    }
}
