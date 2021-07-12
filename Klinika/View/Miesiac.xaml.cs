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
            DependencyProperty.Register(nameof(DzienMiesiaca), typeof(uint[]), typeof(Miesiac));

        public uint[] DzienMiesiaca
        {
            get { return (uint[])GetValue(DzienMiesiacaDP); }
            set { SetValue(DzienMiesiacaDP, value); }
        }

        public static readonly DependencyProperty WidocznyDP =
            DependencyProperty.Register(nameof(Widoczny), typeof(string[]), typeof(Miesiac));

        public string[] Widoczny
        {
            get { return (string[])GetValue(WidocznyDP); }
            set { SetValue(WidocznyDP, value); }
        }

        public static readonly DependencyProperty WybranoDzienDP =
            DependencyProperty.Register(nameof(WybranoDzien), typeof(ICommand), typeof(Miesiac));

        public ICommand WybranoDzien
        {
            get { return (ICommand)GetValue(WybranoDzienDP); }
            set { SetValue(WybranoDzienDP, value); }
        }

        public static readonly DependencyProperty NazwaMiesiacaDP =
            DependencyProperty.Register(nameof(NazwaMiesiaca), typeof(string), typeof(Miesiac));

        public string NazwaMiesiaca
        {
            get { return (string)GetValue(NazwaMiesiacaDP); }
            set { SetValue(NazwaMiesiacaDP, value); }
        }
    }
}
