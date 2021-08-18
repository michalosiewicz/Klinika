﻿using System;
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
        public DodawaniePacjentowViewModel DodawaniePacjentow {get;set;}
        public Model MainModel { get; set; }

        public MainViewModel()
        {
            MainModel = new Model();
            Dzien = new DzienViewModel();
            Miesiac = new MiesiacViewModel(MainModel.Kalendarz,Dzien);
            Filtry = new FiltryViewModel(MainModel.Filtry,MainModel.Kalendarz,Miesiac,Dzien);
            DodawaniePacjentow = new DodawaniePacjentowViewModel(MainModel.DaneZBazy.ListaPacjentow());
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
