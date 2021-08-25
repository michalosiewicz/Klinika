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

        private View.DodawaniePacjenta okno;

        public DostepneWizyty DostepneWizyty { get; set; }

        public int IndeksWizyty { get; set; }

        private List<string> pacjenci;

        public List<string> Pacjenci
        {
            get { return pacjenci; }
            set { pacjenci = value; onPropertyChanged(nameof(Pacjenci)); }
        }

        private int indeks=-1;

        public int Indeks
        {
            get { return indeks; }
            set { indeks = value; onPropertyChanged(nameof(Indeks)); }
        }

        //SINGLETON
        private static DodawaniePacjentowViewModel instance = null;
        public static DodawaniePacjentowViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DodawaniePacjentowViewModel();

                }
                return instance;
            }
        }

        public void StworzOkno()
        {
            okno = new View.DodawaniePacjenta();
            okno.Show();
        }

        private ICommand anuluj;
        public ICommand Anuluj
        {

            get
            {
                return anuluj ?? (anuluj = new RelayCommand(
                    p => { okno.Close(); }, // niepoprawnie
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
                    p => { DostepneWizyty.ZapiszPacjentaNaWizyte(IndeksWizyty, Indeks);
                        okno.Close();
                    },
                    p => true
                    ));
            }
        }
    }
}
