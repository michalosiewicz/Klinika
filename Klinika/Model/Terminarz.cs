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

        public uint[] DniMiesaca { get; set; }

        public string[] Widoczne { get; set; }

        public string NazwaMiesiaca { get; set; }

        private int pierwszyDzienMiesiaca;


        public Terminarz()
        {
            Widoczne = new string[15];
            DniMiesaca = new uint[37];
            Data = DateTime.Now;
            Data = new DateTime(Data.Year, Data.Month, 1);
            
            pierwszyDzienMiesiaca= (int)Data.DayOfWeek;
            pierwszyDzienMiesiaca--;
            if (pierwszyDzienMiesiaca == -1)
                pierwszyDzienMiesiaca = 6;

            AktualizujDate();
            Kalendarz = new GregorianCalendar();
            UluzKalendarz();
        }
       
        public void AktualizujDate()
        {
            Data = DateTime.Now;
        }

        private void UluzKalendarz()
        {
            NazwaMiesiaca = NazwyMiesiecy.NazwaMiesiaca(Data.Month)+" "+Data.Year;
            uint numer = 1;
            
            for (int i = 0; i < pierwszyDzienMiesiaca; i++)
            {
                Widoczne[i] = "Collapsed";
            }
            int indeks = 14;
            for (int i = pierwszyDzienMiesiaca; i < DniMiesaca.Length; i++)
            {
                if (numer > Kalendarz.GetDaysInMonth(Data.Year, Data.Month))
                {
                    Widoczne[indeks] = "Collapsed";
                    indeks--;
                }
                else
                {
                    DniMiesaca[i] = numer;
                    numer++;
                }
            }
        }
        public bool DniDostepne(int numerDnia)
        {
            AktualizujDate();
            if (NazwaMiesiaca == NazwyMiesiecy.NazwaMiesiaca(Data.Month) + " " + Data.Year)
            {
                numerDnia++;
                numerDnia -= pierwszyDzienMiesiaca;
                if (numerDnia < Data.Day)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
    }
}
