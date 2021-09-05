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

        #region Właściwości
        public Specjalizacja WybranaSpecjalizacja { get; set; }
        public Lekarz WybranyLekarz { get; set; }
        public string Dostepnosc { get; set; }
        public List<Wizyta> AktualneWizyty { get; set; }
        public List<Pacjent> AktualniPacjenci { get; set; }
        public int IndeksWizyty { get; set; }
        DateTime AktualnaData { get; set; }
        #endregion

        #region Konstruktor
        public DostepneWizyty(Dane d)
        {
            dane = d;
            AktualniPacjenci = dane.Pacjenci.ToList();
            AktualniPacjenci.Sort();
            AktualnaData = DateTime.Now;
        }
        #endregion

        #region Metody
        public bool DostepneDni(int numerDnia, int rok, int miesiac,DateTime aktualnaData)
        {
            foreach (var w in dane.Wizyty)
            {
                DateTime data = w.Data;
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia && aktualnaData.Date <= data.Date)
                {
                    if (aktualnaData.Date!=data.Date||aktualnaData.TimeOfDay <= data.TimeOfDay)
                    {
                        if (ZgodnoscZFiltrami(w))
                            return true;
                    }
                }
            }
            return false;
        }

        public List<OpisanaWizyta> ListaWizyt(int numerDnia, int rok, int miesiac,DateTime aktualnaData)
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
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia&&aktualnaData.Date<=data.Date)
                {
                    if (aktualnaData.Date != data.Date || aktualnaData.TimeOfDay <= data.TimeOfDay)
                    {
                        if (ZgodnoscZFiltrami(w))
                            zgodnoscZFiltrem = true;
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

        private bool ZgodnoscZFiltrami(Wizyta w) 
        {
            if (WybranaSpecjalizacja == null && WybranyLekarz == null && Dostepnosc == null)
            {
                return true;
            }
            if (Dostepnosc == null)
            {
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
            if (Dostepnosc == "Dostępna" && w.Pesel == "")
            {
                if (WybranaSpecjalizacja == null && WybranyLekarz == null)
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
            if (Dostepnosc == "Zajęta" && w.Pesel != "")
            {
                if (WybranaSpecjalizacja == null && WybranyLekarz == null)
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
            return false;
        }

        public List<Pacjent> ListaPacjentow(string nazwisko)
        {
            AktualniPacjenci = new List<Pacjent>();
            if (nazwisko == "" || nazwisko==null)
            {
                AktualniPacjenci = dane.Pacjenci.ToList();
            }
            else
            {
                nazwisko = nazwisko.ToLower();
                foreach (var p in dane.Pacjenci)
                {
                    string nazwisko2 = p.Nazwisko.ToLower();
                    if (nazwisko.Length <= nazwisko2.Length)
                    {
                        nazwisko2 = nazwisko2.Substring(0, nazwisko.Length);
                        if (nazwisko == nazwisko2)
                            AktualniPacjenci.Add(p);
                    }
                }
            }
            AktualniPacjenci.Sort();
            return AktualniPacjenci;
        }

        public void ZapiszPacjentaNaWizyte(int indeksPacjenta)
        {
            RepozytoriumWizyt.EdytujWizyteWBazie(AktualniPacjenci[indeksPacjenta].Pesel, AktualneWizyty[IndeksWizyty].IdWizyty);
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
        public bool CzyWizytaJestAktualna()
        {
            AktualnaData = DateTime.Now;
            if (AktualnaData.Date <= AktualneWizyty[IndeksWizyty].Data.Date)
            {
                if (AktualnaData.Date < AktualneWizyty[IndeksWizyty].Data.Date || AktualnaData.TimeOfDay <= AktualneWizyty[IndeksWizyty].Data.TimeOfDay)
                    return true;
            }
            return false;
            
        }
        public Pacjent PrzypisanyPacjent(int indekswizyty)
        {
            return dane.ZnajdzPacjnetaPoPesel(AktualneWizyty[indekswizyty].Pesel);
        }
        #endregion
    }
}
