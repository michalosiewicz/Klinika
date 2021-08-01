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
    class TerminarzWizyt
    {
        public ObservableCollection<Wizyta> Wizyty { get; set; } = new ObservableCollection<Wizyta>();

        public TerminarzWizyt()
        {
            try
            {
                var wizyty = RepozytoriumWizyt.PobierzWszystkieWizyty();
                foreach (var w in wizyty)
                    Wizyty.Add(w);
            }
            catch
            {
                MessageBox.Show("Brak dostępu do bazy danych.");
            }
        }

        public bool DostepneDni(int numerDnia,int rok,int miesiac)
        {
            foreach(var w in Wizyty)
            {
                DateTime data = w.Data;
                if (data.Year == rok && data.Month == miesiac && data.Day == numerDnia)
                    return true;
            }
            return false;
        }

    }
}
