using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;

    class Dane
    {
        #region Właściwości
        public ObservableCollection<Specjalizacja> Specjalizacje { get; set; } = new ObservableCollection<Specjalizacja>();
        public ObservableCollection<Lekarz> Lekarze { get; set; } = new ObservableCollection<Lekarz>();
        public ObservableCollection<Wizyta> Wizyty { get; set; } = new ObservableCollection<Wizyta>();
        public ObservableCollection<Posiada> Posiadaja { get; set; } = new ObservableCollection<Posiada>();
        public ObservableCollection<Pacjent> Pacjenci { get; set; } = new ObservableCollection<Pacjent>();
        #endregion

        #region Konstruktor
        public Dane()
        {
            try
            {
                var specjalizacje = RepozytoriumSpecjalizacje.PobierzWszystkieSpecjalizacje();
                foreach (var o in specjalizacje)
                    Specjalizacje.Add(o);

                var lekarze = RepozytoriumLekarze.PobierzWszystkichLekarzy();
                foreach (var l in lekarze)
                    Lekarze.Add(l);
                
                var wizyty = RepozytoriumWizyt.PobierzWszystkieWizyty();
                foreach (var w in wizyty)
                    Wizyty.Add(w);

                var posiadaja = RepozytoriumPosiadaja.PobierzWszystkiePosiadania();
                foreach (var p in posiadaja)
                    Posiadaja.Add(p);

                var pacjenci = RepozytoriumPacjenci.PobierzWszystkichPacjentow();
                foreach (var p in pacjenci)
                    Pacjenci.Add(p);
            }
            catch
            {
                ViewModel.Zamkniecie.ZamknijProgram();
            }
        }
        #endregion

        #region Metody
        public Lekarz ZnajdzLekarzaPoID(uint id)
        {
            foreach (var l in Lekarze)
            {
                if (l.Id == id)
                    return l;
            }
            return null;
        }

        public List<Lekarz> ZnajdzLekarzyPoSpecjalizacji(Specjalizacja s)
        {
            List<Lekarz> lista = new List<Lekarz>();
            foreach (var l in Lekarze)
            {
                foreach (var p in Posiadaja)
                {
                    if (l.Id == p.IdLekarza && p.Nazwa == s.Nazwa)
                        lista.Add(l);
                }
            }
            return lista;
        }

        public List<Specjalizacja> ZnajdzSpecjalizacjeLekarzy(Lekarz l)
        {
            List<Specjalizacja> lista = new List<Specjalizacja>();
            foreach (var s in Specjalizacje)
            {
                foreach (var p in Posiadaja)
                {
                    if (s.Nazwa == p.Nazwa && p.IdLekarza == l.Id)
                        lista.Add(s);
                }
            }
            return lista;
        }

        public Pacjent ZnajdzPacjnetaPoPesel(string pesel)
        {
            Pacjent pacjent = new Pacjent();
            foreach(var p in Pacjenci)
            {
                if (p.Pesel == pesel)
                    pacjent = p;
            }
            return pacjent;
        }

        public bool CzyLekarzPosiadaSpecjalizacje(Specjalizacja s,Lekarz l)
        {
            foreach(var p in Posiadaja)
            {
                if (s.Nazwa == p.Nazwa && l.Id == p.IdLekarza)
                    return true;
            }
            return false;
        }

        public void AktualizujWizyty()
        {
            try
            {
                Wizyty = new ObservableCollection<Wizyta>();
                var wizyty = RepozytoriumWizyt.PobierzWszystkieWizyty();
                foreach (var w in wizyty)
                    Wizyty.Add(w);
            }
            catch
            {
                ViewModel.Zamkniecie.ZamknijProgram();
            }
        }
        #endregion
    }
}
