using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    using DAL.Encje;
    class DostepneWizyty
    {
        private Dane dane;
        public Specjalizacja WybranaSpecjalizacja { get; set; }
        public Lekarz WybranyLekarz { get; set; }

        public DostepneWizyty(Dane d)
        {
            dane = d;
        }

        public bool DostepneDni(int numerDnia, int rok, int miesiac)
        {
            foreach (var w in dane.Wizyty)
            {
                DateTime data = w.Data;
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia)
                {
                    if(WybranaSpecjalizacja==null && WybranyLekarz==null)
                        return true;
                    if (WybranyLekarz == null)
                    {
                        if (dane.CzyLekarzPosiadaSpecjalizacje(WybranaSpecjalizacja, dane.ZnajdzLekarzaPoID(w.IdLekarza)))
                            return true;
                    }
                    else
                    {
                        if (WybranyLekarz.Id == w.IdLekarza)
                            return true;
                    }
                }
            }
            return false;
        }

        public List<string> ListaWizyt(int numerDnia, int rok, int miesiac)
        {
            List<string> listaWizyt = new List<string>();
            string statusWizyty = "Dostępna";
            foreach (var w in dane.Wizyty)
            {
                DateTime data = w.Data;
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia)
                {
                    Lekarz l = dane.ZnajdzLekarzaPoID(w.IdLekarza);
                    if (w.Pesel != "")
                        statusWizyty = "Zarezerwowana";
                    listaWizyt.Add(w.ToString() + "  " + l.ToString() + "  " + l.Sala + "  " + statusWizyty);
                }
            }
            return listaWizyt;
        }
    }
}
