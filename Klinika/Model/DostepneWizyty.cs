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
        public Dane Dane { get; set; }
        public Specjalizacja WybranaSpecjalizacja { get; set; }
        public Lekarz WybranyLekarz { get; set; }
        public List<Wizyta> AktualneWizyty { get; set; }

        //SINGLETON
        private static DostepneWizyty instance = null;
        public static DostepneWizyty Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DostepneWizyty();
                    
                }
                return instance;
            }
        }

        public bool DostepneDni(int numerDnia, int rok, int miesiac)
        {
            foreach (var w in Dane.Wizyty)
            {
                DateTime data = w.Data;
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia)
                {
                    if(WybranaSpecjalizacja==null && WybranyLekarz==null)
                        return true;
                    if (WybranyLekarz == null)
                    {
                        if (Dane.CzyLekarzPosiadaSpecjalizacje(WybranaSpecjalizacja, Dane.ZnajdzLekarzaPoID(w.IdLekarza)))
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
            AktualneWizyty = new List<Wizyta>();
            string statusWizyty;
            bool zgodnoscZFiltrem;
            foreach (var w in Dane.Wizyty)
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
                        if (Dane.CzyLekarzPosiadaSpecjalizacje(WybranaSpecjalizacja, Dane.ZnajdzLekarzaPoID(w.IdLekarza)))
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
                        Lekarz l = Dane.ZnajdzLekarzaPoID(w.IdLekarza);
                        if (w.Pesel != "")
                            statusWizyty = "Zarezerwowana";
                        listaWizyt.Add(w.ToString() + "  " + l.ToString() + "  " + l.Sala + "  " + statusWizyty);
                        AktualneWizyty.Add(w);
                    }
                }
            }
            return listaWizyt;
        }

        public void ZapiszPacjentaNaWizyte(int indeksWizyty,int indeksPacjenta)
        {
            RepozytoriumWizyt.EdytujWizyteWBazie(Dane.Pacjenci[indeksPacjenta].Pesel, AktualneWizyty[indeksWizyty].IdWizyty);
            Dane.AktualizujWizyty();
        }
    }
}
