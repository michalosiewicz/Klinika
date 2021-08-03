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
    using System.Windows;

    class Dane
    {
        public ObservableCollection<Specjalizacja> Specjalizacje { get; set; } = new ObservableCollection<Specjalizacja>();
        public ObservableCollection<Lekarz> Lekarze { get; set; } = new ObservableCollection<Lekarz>();
        public ObservableCollection<Wizyta> Wizyty { get; set; } = new ObservableCollection<Wizyta>();
        public ObservableCollection<Posiada> Posiadaja { get; set; } = new ObservableCollection<Posiada>();

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
            }
            catch
            {
                MessageBox.Show("Brak dostępu do bazy danych.");
            }
        }

        private  Lekarz ZnajdzLekarzaPoID(uint id)
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

        public bool DostepneDni(int numerDnia, int rok, int miesiac)
        {
            foreach (var w in Wizyty)
            {
                DateTime data = w.Data;
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia)
                    return true;
            }
            return false;
        }

        public List<string> ListaWizyt(int numerDnia, int rok, int miesiac)
        {
            List<string> listaWizyt = new List<string>();
            string statusWizyty="Dostępna";
            foreach (var w in Wizyty)
            {
                DateTime data = w.Data;
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia)
                {
                    Lekarz l = ZnajdzLekarzaPoID(w.IdLekarza);
                    if (w.Pesel != "")
                        statusWizyty = "Zarezerwowana";
                    listaWizyt.Add(w.ToString()+"  "+l.ToString()+"  "+l.Sala+"  "+statusWizyty);
                }
            }
            return listaWizyt;
        }

        public List<string> ListaSpecjalizacji()
        {
            List<string> listaSpecjalizacji = new List<string>();
            listaSpecjalizacji.Add("Dowolna");
            foreach(var s in Specjalizacje)
            {
                listaSpecjalizacji.Add(s.ToString());
            }
            return listaSpecjalizacji;
        }

        public List<string> ListaLekarzy()
        {
            List<string> listaLekarzy = new List<string>();
            listaLekarzy.Add("Dowolny");
            foreach (var l in Lekarze)
            {
                listaLekarzy.Add(l.ToString());
            }
            return listaLekarzy;
        }
    }
}
