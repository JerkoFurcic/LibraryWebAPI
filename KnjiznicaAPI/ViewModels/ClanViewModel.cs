using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnjiznicaAPI.ViewModels
{
    public class ClanViewModel
    {
        public int ID { get; set; }
        public int KnjiznicaID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KontaktBroj { get; set; }
        public System.DateTime ClanarinaVrijediDo { get; set; }
    }
}