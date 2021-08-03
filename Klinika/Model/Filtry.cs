using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    using DAL.Encje;
    using System.Windows;

    class Filtry
    {
        private Dane dane;
        public List<Specjalizacja> AktualneSpecjalizacje { get; set; }
        public List<Lekarz> AktualniLekarze { get; set; }

        public Filtry(Dane d)
        {
            dane = d;
            AktualneSpecjalizacje = dane.Specjalizacje.ToList();
            AktualniLekarze = dane.Lekarze.ToList();
        }

        public List<string> ZnajdzLekarzyPoSpecjalizacji(int index)
        {
            if (index == 0)
                AktualniLekarze = dane.Lekarze.ToList();
            else
                AktualniLekarze = dane.ZnajdzLekarzyPoSpecjalizacji(AktualneSpecjalizacje[index - 1]);
            List<string> lista = new List<string>();
            lista.Add("Dowolny");
            foreach (var l in AktualniLekarze)
                lista.Add(l.ToString());
            return lista;
        }

        public List<string> ZnajdzSpecjalizacjeLekarzy(int index)
        {
            if (index == 0)
                AktualneSpecjalizacje = dane.Specjalizacje.ToList();
            else
                AktualneSpecjalizacje = dane.ZnajdzSpecjalizacjeLekarzy(AktualniLekarze[index - 1]);
            List<string> lista = new List<string>();
            lista.Add("Dowolna");
            foreach (var s in AktualneSpecjalizacje)
                lista.Add(s.ToString());
            return lista;
        }
    }
}
