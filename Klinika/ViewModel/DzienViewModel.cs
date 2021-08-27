﻿using System;
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

        private List<string> wizyty;

        public List<string> Wizyty
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
            set { index = value; onPropertyChanged(nameof(Index)); }
        }

        private ICommand zmianaIndeksu;
        public ICommand ZmianaIndeksu
        {

            get
            {
                return zmianaIndeksu ?? (zmianaIndeksu = new RelayCommand(
                    p =>
                    {
                        if (Index > -1)
                        {
                            dostepneWizyty.IndeksWizyty = Index;

                            if (dostepneWizyty.CzyWizytaJestZajeta())
                            {
                                var result=MessageBox.Show("Czy chcesz usunąć pacjenta z wybranej wizyty?",
                                    "Usuń pacjenta",MessageBoxButton.YesNo);
                                if(result==MessageBoxResult.Yes)
                                    dostepneWizyty.UsunPacjnetaZWizyty();
                                Wizyty = terminarz.WizytyDanegoDnia(NumerDnia);
                            }
                            else
                            {
                                App.OknoDodaniaPacjenta = new View.DodawaniePacjenta();
                                App.OknoDodaniaPacjenta.ShowDialog();
                                Wizyty = terminarz.WizytyDanegoDnia(NumerDnia);
                            }
                            Index = -1;
                        }

                    },

                    p => true
                    ));
            }
        }
        public void Aktualizuj(string data,List<string> wizyty)
        {
            Data = data;
            Wizyty = wizyty;
        }

        public void Reset()
        {
            Data = null;
            Wizyty = new List<string>();
        }

        public void Aktualizuj()
        {
            Wizyty = terminarz.WizytyDanegoDnia(NumerDnia);
        }

        public DzienViewModel(Terminarz t,DostepneWizyty dW)
        {
            terminarz = t;
            dostepneWizyty = dW;
        }
    }
}
