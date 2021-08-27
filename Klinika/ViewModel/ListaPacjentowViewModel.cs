using Klinika.Model;
using Klinika.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    class ListaPacjentowViewModel:ViewModelBase
    {
        public ListaPacjentowViewModel(List<string> lista)
        {
            Pacjenci = lista;
        }

        private List<string> pacjenci;

        public List<string> Pacjenci
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
    }
}
