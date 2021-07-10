using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using BaseClass;
    using Model;
    class MiesiacViewModel:ViewModelBase
    {
        private uint[][] dniMiesiaca;
        

        public uint[][] DniMiesiaca
        {
            get { return dniMiesiaca; }
            set { dniMiesiaca = value; onPropertyChanged(nameof(DniMiesiaca)); }
        }

        public MiesiacViewModel(Terminarz terminarz)
        {
            DniMiesiaca = terminarz.DniMiesaca;
        }
    }
}
