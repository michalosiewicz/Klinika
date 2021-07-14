using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Klinika.ViewModel
{
    using Model;
    using BaseClass;
    using System.Windows;

    class MainViewModel : ViewModelBase
    {
        public MiesiacViewModel Miesiac { get; set; }

        public Terminarz Kalendarz { get; set; }

        public MainViewModel()
        {
            Kalendarz = new Terminarz();
            Miesiac = new MiesiacViewModel(Kalendarz);
        }

        private ICommand nastepnyMiesiac;
        public ICommand NastepnyMiesiac
        {

            get
            {
                return nastepnyMiesiac ?? (nastepnyMiesiac = new RelayCommand(
                    p => { Kalendarz.NastepnyMiesiac(1); Miesiac.Aktualizacja(); },
                    p => true
                    )) ;
            }
        }

        private ICommand poprzedniMiesiac;
        public ICommand PoprzedniMiesiac
        {

            get
            {
                return poprzedniMiesiac ?? (poprzedniMiesiac = new RelayCommand(
                    p => { Kalendarz.NastepnyMiesiac(-1); Miesiac.Aktualizacja(); },
                    p => Kalendarz.CzyMoznaZmienicMiesiac(-1)
                    )) ;
            }
        }
    }
}
