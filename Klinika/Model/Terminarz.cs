using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Klinika.Model
{
    class Terminarz
    {
        public DateTime Data {get;set;}
        public Calendar Kalendarz { get; set; }

        public uint[][] DniMiesaca { get; set; }


        public Terminarz()
        {
            Data = DateTime.Now;
            DniMiesaca = new uint[6][];
            for(int i = 0; i < DniMiesaca.Length; i++)
            {
                DniMiesaca[i] = new uint[7];
            }
            Kalendarz = new GregorianCalendar();
            UluzKalendarz();
        }
       
        public void AktualizujDate()
        {
            Data = DateTime.Now;
        }

        private void UluzKalendarz()
        {
            uint numer = 1;
            Data = new DateTime(Data.Year, Data.Month, 1);
            int dzien = (int)Data.DayOfWeek;
            dzien--;
            if (dzien == -1)
                dzien = 6;
            for (int i = dzien; i < DniMiesaca[0].Length; i++)
            {
                DniMiesaca[0][i] = numer;
                numer++;
            }
            for (int i = 1; i < DniMiesaca.Length; i++)
            {
                for (int j = 0; j < DniMiesaca[i].Length; j++)
                {
                    if (numer > Kalendarz.GetDaysInMonth(Data.Year, Data.Month))
                        break;
                    DniMiesaca[i][j] = numer;
                    numer++;
                }
            }
        }
    }
}
