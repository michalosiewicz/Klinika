using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    using DAL.Encje;
    using Klinika.DAL.Repozytoria;
    using System.Windows;

    class DostepneWizyty
    {
        private Dane dane;
        public Specjalizacja WybranaSpecjalizacja { get; set; }
        public Lekarz WybranyLekarz { get; set; }
        public List<Wizyta> AktualneWizyty { get; set; }
        public int IndeksWizyty { get; set; }

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

        public List<OpisanaWizyta> ListaWizyt(int numerDnia, int rok, int miesiac)
        {
            List<OpisanaWizyta> listaWizyt = new List<OpisanaWizyta>();
            AktualneWizyty = new List<Wizyta>();
            string statusWizyty;
            bool zgodnoscZFiltrem;
            foreach (var w in dane.Wizyty)
            {
                statusWizyty = "Dostępna";
                zgodnoscZFiltrem = false;
                DateTime data = w.Data;
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia)
                {
                    if (WybranaSpecjalizacja == null && WybranyLekarz == null)
                        zgodnoscZFiltrem= true;
                    else if (WybranyLekarz == null)
                    {
                        if (dane.CzyLekarzPosiadaSpecjalizacje(WybranaSpecjalizacja, dane.ZnajdzLekarzaPoID(w.IdLekarza)))
                            zgodnoscZFiltrem= true;
                    }
                    else
                    {
                        if (WybranyLekarz.Id == w.IdLekarza)
                        {
                            zgodnoscZFiltrem = true;
                        }
                    }
                    if (zgodnoscZFiltrem)
                    {
                        Lekarz l = dane.ZnajdzLekarzaPoID(w.IdLekarza);
                        if (w.Pesel != "")
                            statusWizyty = "Zajęta";
                        OpisanaWizyta opisanaWizyta = new OpisanaWizyta(w.ToString(), l.ToString(), l.Sala, statusWizyty);
                        listaWizyt.Add(opisanaWizyta);
                        AktualneWizyty.Add(w);
                    }
                }
            }
            listaWizyt.Sort();
            AktualneWizyty.Sort();
            return listaWizyt;
        }

        public void ZapiszPacjentaNaWizyte(int indeksPacjenta)
        {
            RepozytoriumWizyt.EdytujWizyteWBazie(dane.AktualniPacjenci[indeksPacjenta].Pesel, AktualneWizyty[IndeksWizyty].IdWizyty);
            dane.AktualizujWizyty();
        }

        public void UsunPacjnetaZWizyty()
        {
            RepozytoriumWizyt.EdytujWizyteWBazie("NULL", AktualneWizyty[IndeksWizyty].IdWizyty);
            dane.AktualizujWizyty();
        }
        public bool CzyWizytaJestZajeta()
        {
            if (AktualneWizyty[IndeksWizyty].Pesel == "")
                return false;
            return true;
        }

        public Pacjent PrzypisanyPacjent(int indekswizyty)
        {
            return dane.ZnajdzPacjnetaPoPesel(AktualneWizyty[indekswizyty].Pesel);
        }
    }
}
