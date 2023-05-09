using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjižnica.ViewModels
{
    class ZaposlenikViewModel
    {
        public int KnjiznicaID { get; set; }
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int Sifra { get; set; }
        public string KontaktBroj { get; set; }
        public System.DateTime PocetakRada { get; set; }
        public string ComboBoxName => $"{Ime} {Prezime} {Email} ";
    }
}
