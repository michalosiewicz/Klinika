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

    class FiltryViewModel : ViewModelBase
    {
        private Filtry filtry;

        private List<string> specjalizacje;

        public List<string> Specjalizcje
        {
            get { return specjalizacje; }
            set { specjalizacje = value; onPropertyChanged(nameof(Specjalizcje)); }
        }

        private List<string> lekarze;

        public List<string> Lekarze
        {
            get { return lekarze; }
            set { lekarze = value; onPropertyChanged(nameof(Lekarze)); }
        }

        private int indexSpecjalizacji;

        public int IndexSpecjalizacji
        {
            get { return indexSpecjalizacji; }
            set { indexSpecjalizacji = value; onPropertyChanged(nameof(IndexSpecjalizacji)); }
        }

        private int indexLekarza;

        public int IndexLekarza
        {
            get { return indexLekarza; }
            set { indexLekarza = value; onPropertyChanged(nameof(IndexLekarza)); }
        }

        private ICommand wybranoFiltry;
        public ICommand WybranoFiltry
        {

            get
            {
                return wybranoFiltry ?? (wybranoFiltry = new RelayCommand(
                    p =>
                    {
                        filtry.WybranoFiltry(IndexSpecjalizacji,IndexLekarza);
                    },

                    p => true
                    )) ;
            }
        }

        private ICommand zmianaSpecjalizacji;
        public ICommand ZmianaSpecjalizacji
        {

            get
            {
                return zmianaSpecjalizacji ?? (zmianaSpecjalizacji = new RelayCommand(
                    p =>
                    {
                        Lekarze = filtry.ZnajdzLekarzyPoSpecjalizacji(IndexSpecjalizacji);
                    },

                    p => true
                    ));
            }
        }

        private ICommand zmianaLekarza;
        public ICommand ZmianaLekarza
        {

            get
            {
                return zmianaLekarza ?? (zmianaLekarza = new RelayCommand(
                    p =>
                    {
                        Specjalizcje = filtry.ZnajdzSpecjalizacjeLekarzy(IndexLekarza);
                    },

                    p => true
                    ));
            }
        }

        public FiltryViewModel(Filtry f)
        {
            filtry = f;
            Specjalizcje = filtry.ZnajdzSpecjalizacjeLekarzy(0);
            Lekarze = filtry.ZnajdzLekarzyPoSpecjalizacji(0);
        }
    }
}
