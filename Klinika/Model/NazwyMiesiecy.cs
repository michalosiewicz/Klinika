using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    static class NazwyMiesiecy
    {
        private enum Miesiace { Styczeń=1,Luty=2,Marzec=3,Kwiecień=4,Maj=5,Czerwiec=6,Lipiec=7,Sierpień=8,
            Wrzesień=9,Październik=10,Listopad=11,Grudzień=12 };
        
        public static string NazwaMiesiaca(int numerMiesiaca)
        {
            return ((Miesiace)numerMiesiaca).ToString();
        }

    }
}
