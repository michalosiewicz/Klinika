using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using Model;
    using BaseClass;
    using System.Windows.Input;
    using System.Windows;

    class DodawaniePacjentowViewModel:ViewModelBase
    {
        private const string BRAK_WIZYTY = "Wybrana wizyta nie jest dostępna.";

        #region Właściwości
        public ListaPacjentowViewModel ListaPacjentow { get; set; }
        public Model MainModel { get; set; }
        #endregion

        #region Konstruktor
        public DodawaniePacjentowViewModel()
        {
            MainModel = Model.Instance;

            ListaPacjentow = new ListaPacjentowViewModel(MainModel.Wizyty);
        }
        #endregion

        #region Polecenia
        private ICommand anuluj;
        public ICommand Anuluj
        {

            get
            {
                return anuluj ?? (anuluj = new RelayCommand(
                    p => {
                        App.OknoDodaniaPacjenta.Close();
                    },
                    p => true
                    ));
            }
        }

        private ICommand zapisz;
        public ICommand Zapisz
        {

            get
            {
                return zapisz ?? (zapisz = new RelayCommand(
                    p =>
                    {
                        Zapisywanie();
                    },
                    p => ListaPacjentow.Indeks>-1
                    ));
            }
        }
        #endregion

        #region Metody
        private void Zapisywanie()
        {
            if (MainModel.Wizyty.CzyWizytaJestAktualna())
            {
                MainModel.Wizyty.ZapiszPacjentaNaWizyte(ListaPacjentow.Indeks);
                App.OknoDodaniaPacjenta.Close();
            }
            else
            {
                MessageBox.Show(BRAK_WIZYTY);
                App.OknoDodaniaPacjenta.Close();
            }
        }
        #endregion
    }
}
