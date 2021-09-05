using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.ViewModel
{
    using BaseClass;
    using System.Windows;
    using System.Windows.Input;
    using Model;

    class DzienViewModel : ViewModelBase
    {
        #region Prywatne składowe
        private Terminarz terminarz;

        private DostepneWizyty dostepneWizyty;

        private const string WIZYTA_NIEDOSTEPNA = "Wybrana wizyta nie jest dostępna.";

        private const string USUN_PACJENTA = "Czy chcesz usunąć pacjenta z wybranej wizyty?";

        private const string USUN = "Usuń pacjenta";

        private const string NAZWISKO_IMIE = "Nazwisko Imię : ";

        private const string PESEL = "Pesel : ";
        #endregion

        #region Właściwości
        public int NumerDnia { get; set; }
        public int Miesiac { get; set; }
        public int Rok { get; set; }
        public int PierwszyDzienMiesiaca { get; set; }

        private List<OpisanaWizyta> wizyty;

        public List<OpisanaWizyta> Wizyty
        {
            get { return wizyty; }
            set { wizyty = value; onPropertyChanged(nameof(Wizyty)); }
        }

        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; onPropertyChanged(nameof(Data)); }
        }

        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; onPropertyChanged(nameof(Index));
                ZmianaIndeksu();
            }
        }

        private string widoczne;

        public string Widoczne
        {
            get { return widoczne; }
            set { widoczne = value; onPropertyChanged(nameof(Widoczne)); }
        }

        private string widoczneInformacjeOPacjencie;

        public string WidoczneInformacjeOPacjencie
        {
            get { return widoczneInformacjeOPacjencie; }
            set { widoczneInformacjeOPacjencie = value; onPropertyChanged(nameof(WidoczneInformacjeOPacjencie)); }
        }

        private string nazwiskoImie;

        public string NazwiskoImie
        {
            get { return nazwiskoImie; }
            set { nazwiskoImie = value; onPropertyChanged(nameof(NazwiskoImie)); }
        }

        private string pesel;

        public string Pesel
        {
            get { return pesel; }
            set { pesel = value; onPropertyChanged(nameof(Pesel)); }
        }
        #endregion

        #region Polecenia
        private ICommand zapiszPacjenta;
        public ICommand ZapiszPacjenta
        {

            get
            {
                return zapiszPacjenta ?? (zapiszPacjenta = new RelayCommand(
                    p =>
                    {
                        ZapisywaniePacjenta();
                    },

                    p => Index >-1 && !dostepneWizyty.CzyWizytaJestZajeta()
                    ));
            }
        }

        private ICommand usunPacjenta;
        public ICommand UsunPacjenta
        {

            get
            {
                return usunPacjenta ?? (usunPacjenta = new RelayCommand(
                    p =>
                    {
                        UsuwaniePacjenta();
                    },

                    p => Index >-1 && dostepneWizyty.CzyWizytaJestZajeta()
                    ));
            }
        }
        #endregion

        #region Metody
        public void Aktualizuj(string data,List<OpisanaWizyta> wizyty)
        {
            Data = data;
            Wizyty = wizyty;
            Widoczne = "Visible";
        }

        public void Reset()
        {
            Data = null;
            Wizyty = new List<OpisanaWizyta>();
            Widoczne= "Collapsed";
            WidoczneInformacjeOPacjencie= "Collapsed";
        }

        private void ZmianaIndeksu()
        {
            dostepneWizyty.IndeksWizyty = Index;
            if (Index > -1)
            {
                if (dostepneWizyty.CzyWizytaJestZajeta())
                {
                    DAL.Encje.Pacjent pacjent = dostepneWizyty.PrzypisanyPacjent(Index);
                    NazwiskoImie = NAZWISKO_IMIE + pacjent.Nazwisko + " " + pacjent.Imie;
                    Pesel = PESEL + pacjent.Pesel;
                    WidoczneInformacjeOPacjencie = "Visible";
                }
                else
                    WidoczneInformacjeOPacjencie = "Collapsed";
            }
            else
                WidoczneInformacjeOPacjencie = "Collapsed";
        }

        private void ZapisywaniePacjenta()
        {
            if (dostepneWizyty.CzyWizytaJestAktualna())
            {
                App.OknoDodaniaPacjenta = new View.DodawaniePacjenta();
                App.OknoDodaniaPacjenta.ShowDialog();
            }
            else
                MessageBox.Show(WIZYTA_NIEDOSTEPNA);
            Wizyty = terminarz.WizytyDanegoDnia(NumerDnia, Miesiac, Rok, PierwszyDzienMiesiaca);
            Index = -1;
        }

        private void UsuwaniePacjenta()
        {
            if (dostepneWizyty.CzyWizytaJestAktualna())
            {
                var result = MessageBox.Show(USUN_PACJENTA,
                    USUN, MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    dostepneWizyty.UsunPacjnetaZWizyty();
            }
            else
                MessageBox.Show(WIZYTA_NIEDOSTEPNA);
            Wizyty = terminarz.WizytyDanegoDnia(NumerDnia, Miesiac, Rok, PierwszyDzienMiesiaca);
            Index = -1;
        }
        #endregion

        #region Konstruktor
        public DzienViewModel(Terminarz t,DostepneWizyty dW)
        {
            terminarz = t;
            dostepneWizyty = dW;
            Widoczne= "Collapsed";
            WidoczneInformacjeOPacjencie= "Collapsed";
            Index = -1;
        }
        #endregion
    }
}
