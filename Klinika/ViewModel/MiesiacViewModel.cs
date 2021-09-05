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

    class MiesiacViewModel:ViewModelBase
    {
        #region Składowe prywatne
        private Terminarz terminarz;
        private DzienViewModel dzien;
        #endregion


        #region Właściwości
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
        #endregion

        #region Polecenia
        private ICommand wybranoDzien;
        public ICommand WybranoDzien
        {

            get
            {
                return wybranoDzien ?? (wybranoDzien = new RelayCommand(
                    p => {
                        AktualizacjaDnia(int.Parse(p.ToString()));
                    },
                    
                    p =>  terminarz.DniDostepne(int.Parse(p.ToString()))
                    )) ;
            }
        }
        #endregion

        #region Konstruktor
        public MiesiacViewModel(Terminarz t,DzienViewModel d)
        {
            terminarz = t;
            dzien = d;
            DniMiesiaca = terminarz.DniMiesaca;
            Widoczny = terminarz.Widoczne;
            NazwaMiesiaca = terminarz.NazwaMiesiaca;
        }
        #endregion

        #region Metody
        public void Aktualizacja()
        {
            DniMiesiaca = terminarz.DniMiesaca;
            Widoczny = terminarz.Widoczne;
            NazwaMiesiaca = terminarz.NazwaMiesiaca;
        }

        private void AktualizacjaDnia(int numerDnia)
        {
            int miesiac = terminarz.DataKalendarza.Month;
            int rok = terminarz.DataKalendarza.Year;
            dzien.Aktualizuj(
            terminarz.WybranoDzien(numerDnia),
            terminarz.WizytyDanegoDnia(numerDnia, miesiac, rok, terminarz.PierwszyDzienMiesiaca));
            dzien.NumerDnia = numerDnia;
            dzien.Miesiac = terminarz.DataKalendarza.Month;
            dzien.Rok = terminarz.DataKalendarza.Year;
            dzien.PierwszyDzienMiesiaca = terminarz.PierwszyDzienMiesiaca;
        }
        #endregion

    }
}
