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
    
    public partial class Clan
    {
        public Clan()
        {
            this.Posudbas = new HashSet<Posudba>();
        }
    
        public int ID { get; set; }
        public int KnjiznicaID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KontaktBroj { get; set; }
        public System.DateTime ClanarinaVrijediDo { get; set; }
    
        public virtual Knjiznica Knjiznica { get; set; }
        public virtual ICollection<Posudba> Posudbas { get; set; }
    }
}
