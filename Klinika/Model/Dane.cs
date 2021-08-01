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
    }
}
