using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using BaseClass;
    using Model;
    class FiltryViewModel : ViewModelBase
    {
        private Dane dane;

        private List<string> specjalizacje;

        public List<string> Specjalizcje
        {
            get { return specjalizacje; }
            set { specjalizacje = value; onPropertyChanged(nameof(Specjalizcje)); }
        }

        private List<string> lekarze;

        public List<string> Lekarze
        {
            get { return lekarze; }
            set { lekarze = value; onPropertyChanged(nameof(Lekarze)); }
        }

        private string wybranaSpecjalizacja;

        public string WybranaSpecjalizacja
        {
            get { return wybranaSpecjalizacja; }
            set { wybranaSpecjalizacja = value; onPropertyChanged(nameof(WybranaSpecjalizacja)); }
        }

        private string wybranyLekarz;

        public string WybranyLekarz
        {
            get { return wybranyLekarz; }
            set { wybranyLekarz = value; onPropertyChanged(nameof(WybranyLekarz)); }
        }

        public FiltryViewModel(Dane d)
        {
            dane = d;
            Specjalizcje = new List<string>();
            Specjalizcje.Add("Dowolna");
            foreach(var s in dane.Specjalizacje)
                Specjalizcje.Add(s.ToString());
            
            Lekarze = new List<string>();
            Lekarze.Add("Dowolny");
            foreach (var l in dane.Lekarze)
                Lekarze.Add(l.ToString());
            WybranaSpecjalizacja = "Dowolna";
            WybranyLekarz = "Dowolny";
        }
    }
}
