﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjižnica.ViewModels
{
    class PosudbaViewModel
    {
        public int ID { get; set; }
        public int KnjiznicaID { get; set; }
        public int KnjigaID { get; set; }
        public int ClanID { get; set; }
        public int ZaposlenikID { get; set; }
        public System.DateTime DatumPreuzimanja { get; set; }
        public Nullable<System.DateTime> DatumPovratka { get; set; }
    }
}
