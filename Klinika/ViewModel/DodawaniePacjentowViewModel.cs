﻿using System;
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
        public ListaPacjentowViewModel ListaPacjentow { get; set; }
        public Model MainModel { get; set; }

        public DodawaniePacjentowViewModel()
        {
            MainModel = Model.Instance;

            ListaPacjentow = new ListaPacjentowViewModel(MainModel.DaneZBazy.AktualniPacjenci);
        }

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
                        MainModel.Wizyty.ZapiszPacjentaNaWizyte(ListaPacjentow.Indeks);
                        App.OknoDodaniaPacjenta.Close();
                    },
                    p => ListaPacjentow.Indeks>-1
                    ));
            }
        }
    }
}
