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
        private DostepneWizyty wizyty;
        public DateTime DataAktualna {get;set;}
        public DateTime DataKalendarza { get; set; }
        public Calendar Kalendarz { get; set; }

        public uint[] DniMiesaca { get; set; }

        public string[] Widoczne { get; set; }

        public string NazwaMiesiaca { get; set; }

        public int PierwszyDzienMiesiaca { get; set; }


        public Terminarz(DostepneWizyty w)
        {
            wizyty = w;
            DataAktualna = DateTime.Now;
            Kalendarz = new GregorianCalendar();
            UluzKalendarz(DataAktualna.Year, DataAktualna.Month);
        }

        private void UluzKalendarz(int rok,int miesiac)
        {
            DataKalendarza = new DateTime(rok, miesiac, 1);
            DniMiesaca = new uint[37];
            Widoczne = new string[15];

            PierwszyDzienMiesiaca = (int)DataKalendarza.DayOfWeek;
            PierwszyDzienMiesiaca--;
            if (PierwszyDzienMiesiaca == -1)
                PierwszyDzienMiesiaca = 6;
            NazwaMiesiaca = NazwyMiesiecy.NazwaMiesiaca(miesiac)+" "+rok;
            uint numer = 1;
            
            for (int i = 0; i < PierwszyDzienMiesiaca; i++)
            {
                Widoczne[i] = "Collapsed";
            }
            int indeks = 14;
            for (int i = PierwszyDzienMiesiaca; i < DniMiesaca.Length; i++)
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
            numerDnia -= PierwszyDzienMiesiaca;
            if(numerDnia<DataAktualna.Day)
                return false;
            if (wizyty.DostepneDni(numerDnia, DataKalendarza.Year, DataKalendarza.Month))
                return true;
            return false;
        }

        public string WybranoDzien(int numerDnia)
        {
            numerDnia++;
            numerDnia -= PierwszyDzienMiesiaca;
            return numerDnia.ToString() +" "+ NazwyMiesiecy.NazwaMiesiaca(DataKalendarza.Month) +" "+ DataKalendarza.Year;
        }

        public List<OpisanaWizyta> WizytyDanegoDnia(int numerDnia,int miesiac,int rok,int pierwszydzien)
        {
            numerDnia++;
            numerDnia -= pierwszydzien;
            return wizyty.ListaWizyt(numerDnia, rok, miesiac);
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

        public void PierwszyMiesac()
        {
            UluzKalendarz(DataAktualna.Year, DataAktualna.Month);
        }
        
        public bool CzyMoznaZmienicMiesiac(int przesuniecie)
        {
            if (DataAktualna.Year == DataKalendarza.Year && DataKalendarza.Month + przesuniecie < DataAktualna.Month)
                return false;
            return true;
        }
    }
}
