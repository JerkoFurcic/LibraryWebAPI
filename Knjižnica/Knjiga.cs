using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Knjižnica
{
    class Knjiga
    {
        public int KnjiznicaID { get; set; }
        public int ID { get; set; }
        public string NazivKnjige { get; set; }
        public string Pisac { get; set; }
        public string ComboBoxName => $"{Pisac} {NazivKnjige} ";
    }
}
