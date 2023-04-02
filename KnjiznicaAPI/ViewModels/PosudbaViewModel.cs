using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnjiznicaAPI.ViewModels
{
    public class PosudbaViewModel
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