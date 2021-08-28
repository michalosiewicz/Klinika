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
        public ListaPacjentowViewModel(List<DAL.Encje.Pacjent> lista)
        {
            Pacjenci = lista;
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
    }
}
