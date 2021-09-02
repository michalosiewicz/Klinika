using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Klinika.View
{
    /// <summary>
    /// Logika interakcji dla klasy Dzien.xaml
    /// </summary>
    public partial class Dzien : UserControl
    {
        public Dzien()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty WizytyDP =
            DependencyProperty.Register(nameof(Wizyty), typeof(List<Model.OpisanaWizyta>), typeof(Dzien));

        public List<Model.OpisanaWizyta> Wizyty
        {
            get { return (List<Model.OpisanaWizyta>)GetValue(WizytyDP); }
            set { SetValue(WizytyDP, value); }
        }

        public static readonly DependencyProperty DataDP =
            DependencyProperty.Register(nameof(Data), typeof(string), typeof(Dzien));

        public string Data
        {
            get { return (string)GetValue(DataDP); }
            set { SetValue(DataDP, value); }
        }

        public static readonly DependencyProperty IndexDP =
            DependencyProperty.Register(nameof(Index), typeof(int), typeof(Dzien));

        public int Index
        {
            get { return (int)GetValue(IndexDP); }
            set { SetValue(IndexDP, value); }
        }

        public static readonly DependencyProperty WidoczneDP =
            DependencyProperty.Register(nameof(Widoczne), typeof(string), typeof(Dzien));

        public string Widoczne
        {
            get { return (string)GetValue(WidoczneDP); }
            set { SetValue(WidoczneDP, value); }
        }

        public static readonly DependencyProperty WidoczneInformacjeOPacjencieDP =
            DependencyProperty.Register(nameof(WidoczneInformacjeOPacjencie), typeof(string), typeof(Dzien));

        public string WidoczneInformacjeOPacjencie
        {
            get { return (string)GetValue(WidoczneInformacjeOPacjencieDP); }
            set { SetValue(WidoczneInformacjeOPacjencieDP, value); }
        }

        public static readonly DependencyProperty NazwiskoImieDP =
            DependencyProperty.Register(nameof(NazwiskoImie), typeof(string), typeof(Dzien));

        public string NazwiskoImie
        {
            get { return (string)GetValue(NazwiskoImieDP); }
            set { SetValue(NazwiskoImieDP, value); }
        }

        public static readonly DependencyProperty PeselDP =
            DependencyProperty.Register(nameof(Pesel), typeof(string), typeof(Dzien));

        public string Pesel
        {
            get { return (string)GetValue(PeselDP); }
            set { SetValue(PeselDP, value); }
        }

        public static readonly DependencyProperty ZapiszDP =
            DependencyProperty.Register(nameof(Zapisz), typeof(ICommand), typeof(Dzien));
        public ICommand Zapisz
        {
            get { return (ICommand)GetValue(ZapiszDP); }
            set { SetValue(ZapiszDP, value); }
        }

        public static readonly DependencyProperty UsunDP =
            DependencyProperty.Register(nameof(Usun), typeof(ICommand), typeof(Dzien));
        public ICommand Usun
        {
            get { return (ICommand)GetValue(UsunDP); }
            set { SetValue(UsunDP, value); }
        }

    }
}
