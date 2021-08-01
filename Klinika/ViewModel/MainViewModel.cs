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
        public FiltryViewModel Filtry { get; set; }
        public DzienViewModel Dzien { get; set; }

        public Terminarz Kalendarz { get; set; }
        public Dane DaneZBazy { get; set; }

        public MainViewModel()
        {
            Kalendarz = new Terminarz();
            DaneZBazy = new Dane();
            Miesiac = new MiesiacViewModel(Kalendarz);
            Filtry = new FiltryViewModel(DaneZBazy);
            Dzien = new DzienViewModel();
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
