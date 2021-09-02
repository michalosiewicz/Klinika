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
        private Terminarz terminarz;

        private DostepneWizyty dostepneWizyty;
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

        private int index=-1;

        public int Index
        {
            get { return index; }
            set { index = value; onPropertyChanged(nameof(Index)); 
                dostepneWizyty.IndeksWizyty = Index;
                if (Index > -1)
                {
                    if (dostepneWizyty.CzyWizytaJestZajeta())
                    {
                        DAL.Encje.Pacjent pacjent = dostepneWizyty.PrzypisanyPacjent(Index);
                        NazwiskoImie = "Nazwisko Imię : " + pacjent.Nazwisko + " " + pacjent.Imie;
                        Pesel = "Pesel : " + pacjent.Pesel;
                        WidoczneInformacjeOPacjencie = "Visible";
                    }
                    else
                        WidoczneInformacjeOPacjencie = "Collapsed";
                }
                else
                    WidoczneInformacjeOPacjencie = "Collapsed";
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

        private ICommand zapiszPacjenta;
        public ICommand ZapiszPacjenta
        {

            get
            {
                return zapiszPacjenta ?? (zapiszPacjenta = new RelayCommand(
                    p =>
                    {
                        App.OknoDodaniaPacjenta = new View.DodawaniePacjenta();
                        App.OknoDodaniaPacjenta.ShowDialog();
                        Wizyty = terminarz.WizytyDanegoDnia(NumerDnia, Miesiac, Rok, PierwszyDzienMiesiaca);
                        Index = -1;
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
                        var result = MessageBox.Show($"Czy chcesz usunąć pacjenta z wybranej wizyty?",
                            "Usuń pacjenta", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                            dostepneWizyty.UsunPacjnetaZWizyty();
                        Wizyty = terminarz.WizytyDanegoDnia(NumerDnia, Miesiac, Rok, PierwszyDzienMiesiaca);
                        Index = -1;
                    },

                    p => Index >-1 && dostepneWizyty.CzyWizytaJestZajeta()
                    ));
            }
        }

        public void Aktualizuj(string data,List<OpisanaWizyta> wizyty)
        {
            Data = data;
            Wizyty = wizyty;
        }

        public void Reset()
        {
            Data = null;
            Wizyty = new List<OpisanaWizyta>();
            Widoczne= "Collapsed";
            WidoczneInformacjeOPacjencie= "Collapsed";
        }

        public DzienViewModel(Terminarz t,DostepneWizyty dW)
        {
            terminarz = t;
            dostepneWizyty = dW;
            Widoczne= "Collapsed";
            WidoczneInformacjeOPacjencie= "Collapsed";
        }
    }
}
