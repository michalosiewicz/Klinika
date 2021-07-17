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
    /// Logika interakcji dla klasy Filtry.xaml
    /// </summary>
    public partial class Filtry : UserControl
    {
        public Filtry()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SpecjalizacjeDP =
            DependencyProperty.Register(nameof(Specjalizacje), typeof(List<string>), typeof(Filtry));

        public List<string> Specjalizacje
        {
            get { return (List<string>)GetValue(SpecjalizacjeDP); }
            set { SetValue(SpecjalizacjeDP, value); }
        }

        public static readonly DependencyProperty LekarzeDP =
            DependencyProperty.Register(nameof(Lekarze), typeof(List<string>), typeof(Filtry));

        public List<string> Lekarze
        {
            get { return (List<string>)GetValue(LekarzeDP); }
            set { SetValue(LekarzeDP, value); }
        }

        public static readonly DependencyProperty SpecjalizacjeTextDP =
            DependencyProperty.Register(nameof(SpecjalizacjeText), typeof(string), typeof(Filtry));

        public string SpecjalizacjeText
        {
            get { return (string)GetValue(SpecjalizacjeTextDP); }
            set { SetValue(SpecjalizacjeTextDP, value); }
        }

        public static readonly DependencyProperty LekarzeTextDP =
            DependencyProperty.Register(nameof(LekarzeText), typeof(string), typeof(Filtry));

        public string LekarzeText
        {
            get { return (string)GetValue(LekarzeTextDP); }
            set { SetValue(LekarzeTextDP, value); }
        }
    }
}
