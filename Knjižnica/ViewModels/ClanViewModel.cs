using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjižnica.ViewModels
{
    class ClanViewModel
    {
        public int KnjiznicaID { get; set; }
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KontaktBroj { get; set; }
        public System.DateTime ClanarinaVrijediDo { get; set; }
        public string ComboBoxName => $"{Ime} {Prezime} {Email} ";
    }
}
