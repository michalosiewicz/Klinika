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
        private Terminarz terminarz;


        private uint[] dniMiesiaca;
        

        public uint[] DniMiesiaca
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

        private string nazwaMiesiaca;

        public string NazwaMiesiaca
        {
            get { return nazwaMiesiaca; }
            set { nazwaMiesiaca = value; onPropertyChanged(nameof(NazwaMiesiaca)); }
        }

        private ICommand wybranoDzien;
        public ICommand WybranoDzien
        {

            get
            {
                return wybranoDzien ?? (wybranoDzien = new RelayCommand(
                    p => { MessageBox.Show("Click"); },
                    p =>  terminarz.DniDostepne(int.Parse(p.ToString()))
                    )) ;
            }
        }

        public MiesiacViewModel(Terminarz t)
        {
            terminarz = t;
            DniMiesiaca = terminarz.DniMiesaca;
            Widoczny = terminarz.Widoczne;
            NazwaMiesiaca = terminarz.NazwaMiesiaca;
        }

        public void Aktualizacja()
        {
            DniMiesiaca = terminarz.DniMiesaca;
            Widoczny = terminarz.Widoczne;
            NazwaMiesiaca = terminarz.NazwaMiesiaca;
        }
        
    }
}
