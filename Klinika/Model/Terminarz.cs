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
        private Dane dane;
        public DateTime DataAktualna {get;set;}
        public DateTime DataKalendarza { get; set; }
        public Calendar Kalendarz { get; set; }

        public uint[] DniMiesaca { get; set; }

        public string[] Widoczne { get; set; }

        public string NazwaMiesiaca { get; set; }

        private int pierwszyDzienMiesiaca;


        public Terminarz(Dane d)
        {
            dane = d;
            DataAktualna = DateTime.Now;
            Kalendarz = new GregorianCalendar();
            UluzKalendarz(DataAktualna.Year,DataAktualna.Month);
        }
       
        public void AktualizujDate()
        {
            DataAktualna = DateTime.Now;
        }

        private void UluzKalendarz(int rok,int miesiac)
        {
            DataKalendarza = new DateTime(rok, miesiac, 1);
            DniMiesaca = new uint[37];
            Widoczne = new string[15];

            pierwszyDzienMiesiaca = (int)DataKalendarza.DayOfWeek;
            pierwszyDzienMiesiaca--;
            if (pierwszyDzienMiesiaca == -1)
                pierwszyDzienMiesiaca = 6;
            NazwaMiesiaca = NazwyMiesiecy.NazwaMiesiaca(miesiac)+" "+rok;
            uint numer = 1;
            
            for (int i = 0; i < pierwszyDzienMiesiaca; i++)
            {
                Widoczne[i] = "Collapsed";
            }
            int indeks = 14;
            for (int i = pierwszyDzienMiesiaca; i < DniMiesaca.Length; i++)
            {
                if (numer > Kalendarz.GetDaysInMonth(DataKalendarza.Year, DataKalendarza.Month))
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
            numerDnia++;
            numerDnia -= pierwszyDzienMiesiaca;
            if (dane.DostepneDni(numerDnia, DataKalendarza.Year, DataKalendarza.Month))
                return true;
            return false;
        }

        public string WybranoDzien(int numerDnia)
        {
            numerDnia++;
            numerDnia -= pierwszyDzienMiesiaca;
            return numerDnia.ToString() +" "+ NazwyMiesiecy.NazwaMiesiaca(DataKalendarza.Month) +" "+ DataKalendarza.Year;
        }

        public List<string> WizytyDanegoDnia(int numerDnia)
        {
            numerDnia++;
            numerDnia -= pierwszyDzienMiesiaca;
            return dane.ListaWizyt(numerDnia, DataKalendarza.Year, DataKalendarza.Month);
        }

        public void NastepnyMiesiac(int przesuniecie)
        {
            int rok = DataKalendarza.Year;
            int miesiac = DataKalendarza.Month+przesuniecie;
            for(int i = 0; i < Widoczne.Length; i++)
            {
                Widoczne[i] = "Visible";
            }
            if (miesiac == 13)
            {
                miesiac = 1;
                rok += 1;
            }
            if (miesiac == 0)
            {
                miesiac = 12;
                rok -= 1;
            }
               
            UluzKalendarz(rok,miesiac);
        }

        public bool CzyMoznaZmienicMiesiac(int przesuniecie)
        {
            if (DataAktualna.Year == DataKalendarza.Year && DataKalendarza.Month + przesuniecie < DataAktualna.Month)
                return false;
            return true;
        }
    }
}
