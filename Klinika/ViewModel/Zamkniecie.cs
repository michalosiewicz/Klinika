using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Klinika.ViewModel
{
    static class Zamkniecie
    {
        private const string BRAK_DOSTEPU = "Brak dostępu do bazy danych.";
        public static void ZamknijProgram()
        {
            MessageBox.Show(BRAK_DOSTEPU);
            App.Current.MainWindow.Close();
        }
    }
}
