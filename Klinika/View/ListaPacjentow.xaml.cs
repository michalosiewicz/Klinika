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
    /// Logika interakcji dla klasy ListaPacjentow.xaml
    /// </summary>
    public partial class ListaPacjentow : UserControl
    {
        public ListaPacjentow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PacjenciDP =
            DependencyProperty.Register(nameof(Pacjenci), typeof(List<DAL.Encje.Pacjent>), typeof(ListaPacjentow));

        public List<DAL.Encje.Pacjent> Pacjenci
        {
            get { return (List<DAL.Encje.Pacjent>)GetValue(PacjenciDP); }
            set { SetValue(PacjenciDP, value); }
        }

        public static readonly DependencyProperty IndexDP =
            DependencyProperty.Register(nameof(Index), typeof(int), typeof(ListaPacjentow));

        public int Index
        {
            get { return (int)GetValue(IndexDP); }
            set { SetValue(IndexDP, value); }
        }

        public static readonly DependencyProperty NazwiskoDP =
           DependencyProperty.Register(nameof(Nazwisko), typeof(string), typeof(ListaPacjentow));

        public string Nazwisko
        {
            get { return (string)GetValue(NazwiskoDP); }
            set { SetValue(NazwiskoDP, value); }
        }

    }
}
