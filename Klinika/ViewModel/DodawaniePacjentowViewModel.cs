using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using Model;
    using BaseClass;
    class DodawaniePacjentowViewModel:ViewModelBase
    {

        private List<string> pacjenci;

        public List<string> Pacjenci
        {
            get { return pacjenci; }
            set { pacjenci = value; onPropertyChanged(nameof(Pacjenci)); }
        }

        public DodawaniePacjentowViewModel(List<string> lista)
        {
            Pacjenci = lista;
        }
    }
}
