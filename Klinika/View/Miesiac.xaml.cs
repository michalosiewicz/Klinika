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
    /// Logika interakcji dla klasy Miesiac.xaml
    /// </summary>
    public partial class Miesiac : UserControl
    {
        public Miesiac()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty DzienMiesiacaDP =
            DependencyProperty.Register(nameof(DzienMiesiaca), typeof(uint[][]), typeof(Miesiac));

        public uint[][] DzienMiesiaca
        {
            get { return (uint[][])GetValue(DzienMiesiacaDP); }
            set { SetValue(DzienMiesiacaDP, value); }
        }
    }
}
