using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using Model;
    class MainViewModel
    {
        public MiesiacViewModel Miesiac { get; set; }

        public Terminarz Kalendarz { get; set; }

        public MainViewModel()
        {
            Kalendarz = new Terminarz();
            Miesiac = new MiesiacViewModel(Kalendarz);
        }
    }
}
