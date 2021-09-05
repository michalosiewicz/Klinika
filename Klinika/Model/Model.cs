using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    class Model
    {
        #region Właściwości
        public Dane DaneZBazy { get; set; }
        public Terminarz Kalendarz { get; set; }
        public Filtry Filtry { get; set; }
        public DostepneWizyty Wizyty { get; set; }
        #endregion

        private static Model instance = null;
        public static Model Instance
        {
            get
            {
                if (instance == null)
                    instance = new Model();
                return instance;
            }
        }

        #region Konstruktor
        private Model()
        {
            DaneZBazy = new Dane();
            Wizyty = new DostepneWizyty(DaneZBazy);
            Filtry = new Filtry(DaneZBazy,Wizyty);
            Kalendarz = new Terminarz(Wizyty);
        }
        #endregion
    }
}
