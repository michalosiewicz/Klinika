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
            DependencyProperty.Register(nameof(Wizyty), typeof(List<string>), typeof(Dzien));

        public List<string> Wizyty
        {
            get { return (List<string>)GetValue(WizytyDP); }
            set { SetValue(WizytyDP, value); }
        }
    }
}
