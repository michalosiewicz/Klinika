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

        public static readonly DependencyProperty WidocznyDP =
            DependencyProperty.Register(nameof(Widoczny), typeof(string[]), typeof(Miesiac));

        public string[] Widoczny
        {
            get { return (string[])GetValue(WidocznyDP); }
            set { SetValue(WidocznyDP, value); }
        }

        public static readonly RoutedEvent WybranoDzienEvent =
            EventManager.RegisterRoutedEvent("WybranoDzien",
                    RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                    typeof(Miesiac));

        public event RoutedEventHandler WybranoDzien
        {
            add { AddHandler(WybranoDzienEvent, value); }
            remove { RemoveHandler(WybranoDzienEvent, value); }
        }

        void RaiseWybranoDzien()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(Miesiac.WybranoDzienEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseWybranoDzien();
        }
    }
}
