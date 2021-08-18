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

    class DzienViewModel : ViewModelBase
    {
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
                            View.DodawaniePacjenta okno = new View.DodawaniePacjenta();
                            okno.Show();
                            // nie wiem czy dobrze
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
    }
}
