//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnjiznicaAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Knjiga
    {
        public Knjiga()
        {
            this.Posudbas = new HashSet<Posudba>();
        }
    
        public int ID { get; set; }
        public int KnjiznicaID { get; set; }
        public string NazivKnjige { get; set; }
        public string Pisac { get; set; }
    
        public virtual Knjiznica Knjiznica { get; set; }
        public virtual ICollection<Posudba> Posudbas { get; set; }
    }
}
