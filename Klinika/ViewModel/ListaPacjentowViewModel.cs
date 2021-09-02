using Klinika.Model;
using Klinika.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Klinika.ViewModel
{
    class ListaPacjentowViewModel:ViewModelBase
    {
        private DostepneWizyty dostepneWizyty;
        public ListaPacjentowViewModel(DostepneWizyty wizyty)
        {
            dostepneWizyty = wizyty;
            Pacjenci = wizyty.AktualniPacjenci;
        }

        private List<DAL.Encje.Pacjent> pacjenci;

        public List<DAL.Encje.Pacjent> Pacjenci
        {
            get { return pacjenci; }
            set { pacjenci = value; onPropertyChanged(nameof(Pacjenci)); }
        }

        private int indeks = -1;

        public int Indeks
        {
            get { return indeks; }
            set { indeks = value; onPropertyChanged(nameof(Indeks)); }
        }

        private string nazwisko;

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; onPropertyChanged(nameof(Nazwisko));
                Pacjenci = dostepneWizyty.ListaPacjentow(Nazwisko);
                Indeks = -1;
            }
        }

    }
}
