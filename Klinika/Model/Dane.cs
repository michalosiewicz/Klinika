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
            }
            catch (Exception)
            {
                MessageBox.Show("Brak dostępu do bazy danych.");
            }
        }
    }
}
