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

        public static readonly RoutedEvent ZmianaIndeksuEvent =
           EventManager.RegisterRoutedEvent("ZmianaIndeksu",
                   RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                   typeof(Dzien));

        public event RoutedEventHandler ZmianaIndeksu
        {
            add { AddHandler(ZmianaIndeksuEvent, value); }
            remove { RemoveHandler(ZmianaIndeksuEvent, value); }
        }

        void RaiseZmianaIndeksu()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(Dzien.ZmianaIndeksuEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseZmianaIndeksu();
        }
    }
}
