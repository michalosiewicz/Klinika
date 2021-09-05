using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    using DAL.Encje;
    using System.Windows;

    class Filtry
    {
        #region Składowe prywatne
        private Dane dane;
        private DostepneWizyty wizyta;
        #endregion

        #region Właściwości
        public List<Specjalizacja> AktualneSpecjalizacje { get; set; }
        public List<Lekarz> AktualniLekarze { get; set; }
        #endregion

        #region Konstruktor
        public Filtry(Dane d,DostepneWizyty w)
        {
            dane = d;
            wizyta = w;
            AktualneSpecjalizacje = dane.Specjalizacje.ToList();
            AktualniLekarze = dane.Lekarze.ToList();
        }
        #endregion

        #region Metody
        public List<string> ZnajdzLekarzyPoSpecjalizacji(int index)
        {
            if (index == 0)
                AktualniLekarze = dane.Lekarze.ToList();
            else
                AktualniLekarze = dane.ZnajdzLekarzyPoSpecjalizacji(AktualneSpecjalizacje[index - 1]);
            List<string> lista = new List<string>();
            lista.Add("Dowolny");
            foreach (var l in AktualniLekarze)
                lista.Add(l.ToString());
            return lista;
        }

        public List<string> ZnajdzSpecjalizacjeLekarzy(int index)
        {
            if (index == 0)
                AktualneSpecjalizacje = dane.Specjalizacje.ToList();
            else
                AktualneSpecjalizacje = dane.ZnajdzSpecjalizacjeLekarzy(AktualniLekarze[index - 1]);
            List<string> lista = new List<string>();
            lista.Add("Dowolna");
            foreach (var s in AktualneSpecjalizacje)
                lista.Add(s.ToString());
            return lista;
        }

        public void WybranoFiltry(int indexSpecjalizacji,int indexLekarza,int indexStatus)
        {
            if (indexSpecjalizacji > 0)
                wizyta.WybranaSpecjalizacja = AktualneSpecjalizacje[indexSpecjalizacji - 1];
            else
                wizyta.WybranaSpecjalizacja = null;
            if (indexLekarza > 0)
                wizyta.WybranyLekarz = AktualniLekarze[indexLekarza - 1];
            else
                wizyta.WybranyLekarz = null;
            if (indexStatus > 0)
            {
                if (indexStatus == 1)
                    wizyta.Dostepnosc = "Dostępna";
                else
                    wizyta.Dostepnosc = "Zajęta";
            }
            else
                wizyta.Dostepnosc = null;
        }
        #endregion
    }
}
