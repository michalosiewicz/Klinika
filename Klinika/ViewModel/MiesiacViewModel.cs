using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using BaseClass;
    using Model;
    using System.Windows;
    using System.Windows.Input;

    class MiesiacViewModel:ViewModelBase
    {
        private uint[][] dniMiesiaca;
        

        public uint[][] DniMiesiaca
        {
            get { return dniMiesiaca; }
            set { dniMiesiaca = value; onPropertyChanged(nameof(DniMiesiaca)); }
        }

        private string[] widoczny;


        public string[] Widoczny
        {
            get { return widoczny; }
            set { widoczny = value; onPropertyChanged(nameof(Widoczny)); }
        }

        public MiesiacViewModel(Terminarz terminarz)
        {
            DniMiesiaca = terminarz.DniMiesaca;
            Widoczny = terminarz.Widoczne;
        }

        private ICommand wybranoDzien;
        public ICommand WybranoDzien
        {

            get
            {
                return wybranoDzien ?? (wybranoDzien = new RelayCommand(
                    p => { MessageBox.Show("Click"); },
                    p => true
                    ));
            }
        }
    }
}
