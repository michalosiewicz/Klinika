﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    class Model
    {
        public Dane DaneZBazy { get; set; }
        public Terminarz Kalendarz { get; set; }

        public Model()
        {
            DaneZBazy = new Dane();
            Kalendarz = new Terminarz(DaneZBazy);
        }
    }
}
