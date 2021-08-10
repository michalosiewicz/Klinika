using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using BaseClass;
    class DzienViewModel : ViewModelBase
    {
        private List<string> wizyty;

        public List<string> Wizyty
        {
            get { return wizyty; }
            set { wizyty = value; onPropertyChanged(nameof(Wizyty)); }
        }

        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; onPropertyChanged(nameof(Data)); }
        }

        public void Aktualizuj(string data,List<string> wizyty)
        {
            Data = data;
            Wizyty = wizyty;
        }

        public void Reset()
        {
            Data = null;
            Wizyty = new List<string>();
        }
    }
}
