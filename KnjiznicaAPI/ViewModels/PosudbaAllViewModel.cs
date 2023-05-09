using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnjiznicaAPI.ViewModels
{
    class PosudbaAllViewModel
    {
        public int ID { get; set; }
        public int KnjiznicaID { get; set; }
        public int KnjigaID { get; set; }
        public int ClanID { get; set; }
        public int ZaposlenikID { get; set; }
        public System.DateTime DatumPreuzimanja { get; set; }
        public Nullable<System.DateTime> DatumPovratka { get; set; }
        public string Zaposlenik { get; set; }
        public string Clan { get; set; }
        public string Knjiga { get; set; }
    }
}
