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

        public FiltryViewModel(Dane d)
        {
            dane = d;
            Specjalizcje = new List<string>();
            Specjalizcje.Add("Dowolna");
            foreach(var s in dane.Specjalizacje)
                Specjalizcje.Add(s.ToString());
        }
    }
}
