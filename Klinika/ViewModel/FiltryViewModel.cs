using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using BaseClass;
    using Model;
    using System.Windows.Input;

    class FiltryViewModel : ViewModelBase
    {
        #region Składowe Prywatne
        private Filtry filtry;
        private Terminarz terminarz;
        private MiesiacViewModel miesiac;
        private DzienViewModel dzien;
        #endregion

        #region Właściwości
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

        private int indexStatus;

        public int IndexStatus
        {
            get { return indexStatus; }
            set { indexStatus = value; onPropertyChanged(nameof(IndexStatus)); }
        }
        #endregion

        #region Polecenia
        private ICommand wybranoFiltry;
        public ICommand WybranoFiltry
        {

            get
            {
                return wybranoFiltry ?? (wybranoFiltry = new RelayCommand(
                    p =>
                    {
                        Wybrano();
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
        #endregion

        #region Metody
        private void Wybrano()
        {
            filtry.WybranoFiltry(IndexSpecjalizacji, IndexLekarza, IndexStatus);
            terminarz.PierwszyMiesac();
            miesiac.Aktualizacja();
            dzien.Reset();
        }
        #endregion

        #region Konstruktor
        public FiltryViewModel(Filtry f,Terminarz t,MiesiacViewModel m,DzienViewModel d)
        {
            filtry = f;
            terminarz = t;
            miesiac = m;
            dzien = d;
            Specjalizcje = filtry.ZnajdzSpecjalizacjeLekarzy(0);
            Lekarze = filtry.ZnajdzLekarzyPoSpecjalizacji(0);
        }
        #endregion
    }
}
