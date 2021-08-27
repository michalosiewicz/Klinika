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
        public Model MainModel { get; set; }

        public MainViewModel()
        {
            MainModel = Model.Instance;
            
            Dzien = new DzienViewModel(MainModel.Kalendarz,MainModel.Wizyty);
            Miesiac = new MiesiacViewModel(MainModel.Kalendarz,Dzien);
            Filtry = new FiltryViewModel(MainModel.Filtry,MainModel.Kalendarz,Miesiac,Dzien);
        }

        private ICommand nastepnyMiesiac;
        public ICommand NastepnyMiesiac
        {

            get
            {
                return nastepnyMiesiac ?? (nastepnyMiesiac = new RelayCommand(
                    p => { MainModel.Kalendarz.NastepnyMiesiac(1); Miesiac.Aktualizacja(); },
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
                    p => { MainModel.Kalendarz.NastepnyMiesiac(-1); Miesiac.Aktualizacja(); },
                    p => MainModel.Kalendarz.CzyMoznaZmienicMiesiac(-1)
                    )) ;
            }
        }
    }
}
