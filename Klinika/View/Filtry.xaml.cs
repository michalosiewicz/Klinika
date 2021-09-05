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

        #region Właściowości
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

        public static readonly DependencyProperty SpecjalizacjeIndexDP =
            DependencyProperty.Register(nameof(SpecjalizacjeIndex), typeof(int), typeof(Filtry));

        public int SpecjalizacjeIndex
        {
            get { return (int)GetValue(SpecjalizacjeIndexDP); }
            set { SetValue(SpecjalizacjeIndexDP, value); }
        }

        public static readonly DependencyProperty LekarzeIndexDP =
            DependencyProperty.Register(nameof(LekarzeIndex), typeof(int), typeof(Filtry));

        public int LekarzeIndex
        {
            get { return (int)GetValue(LekarzeIndexDP); }
            set { SetValue(LekarzeIndexDP, value); }
        }

        public static readonly DependencyProperty StatusIndexDP =
            DependencyProperty.Register(nameof(StatusIndex), typeof(int), typeof(Filtry));

        public int StatusIndex
        {
            get { return (int)GetValue(StatusIndexDP); }
            set { SetValue(StatusIndexDP, value); }
        }
        #endregion

        #region Polecenia
        public static readonly DependencyProperty WybranoFiltryDP =
            DependencyProperty.Register(nameof(WybranoFiltry), typeof(ICommand), typeof(Filtry));
        public ICommand WybranoFiltry
        {
            get { return (ICommand)GetValue(WybranoFiltryDP); }
            set { SetValue(WybranoFiltryDP, value); }
        }

        public static readonly RoutedEvent ZmianaSpecjalizacjiEvent =
            EventManager.RegisterRoutedEvent("ZmianaSpecjalizacji",
                    RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                    typeof(Filtry));

        public event RoutedEventHandler ZmianaSpecjalizacji
        {
            add { AddHandler(ZmianaSpecjalizacjiEvent, value); }
            remove { RemoveHandler(ZmianaSpecjalizacjiEvent, value); }
        }

        void RaiseZmianaSpecjalizacji()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(Filtry.ZmianaSpecjalizacjiEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent ZmianaLekarzaEvent =
            EventManager.RegisterRoutedEvent("ZmianaLekarza",
                    RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                    typeof(Filtry));

        public event RoutedEventHandler ZmianaLekarza
        {
            add { AddHandler(ZmianaLekarzaEvent, value); }
            remove { RemoveHandler(ZmianaLekarzaEvent, value); }
        }

        void RaiseZmianaLekarza()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(Filtry.ZmianaLekarzaEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseZmianaSpecjalizacji();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            RaiseZmianaLekarza();
        }
        #endregion
    }
}
