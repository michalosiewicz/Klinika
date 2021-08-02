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
        private Dane dane;

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

        private string wybranaSpecjalizacja;

        public string WybranaSpecjalizacja
        {
            get { return wybranaSpecjalizacja; }
            set { wybranaSpecjalizacja = value; onPropertyChanged(nameof(WybranaSpecjalizacja)); }
        }

        private string wybranyLekarz;

        public string WybranyLekarz
        {
            get { return wybranyLekarz; }
            set { wybranyLekarz = value; onPropertyChanged(nameof(WybranyLekarz)); }
        }

        private ICommand wybranoFiltry;
        public ICommand WybranoFiltry
        {

            get
            {
                return wybranoFiltry ?? (wybranoFiltry = new RelayCommand(
                    p =>
                    {
                        MessageBox.Show(WybranaSpecjalizacja + " " + WybranyLekarz);
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
                        Lekarze = dane.ZnajdzLekarzyPoSpecjalizacji(WybranaSpecjalizacja);
                    },

                    p => true
                    ));
            }
        }

        public FiltryViewModel(Dane d)
        {
            dane = d;
            Specjalizcje = dane.ListaSpecjalizacji();
            Lekarze = dane.ListaLekarzy();

            WybranaSpecjalizacja = "Dowolna";
            WybranyLekarz = "Dowolny";
        }
    }
}
