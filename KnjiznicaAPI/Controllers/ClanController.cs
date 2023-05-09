using KnjiznicaAPI.Models;
using KnjiznicaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms;

namespace KnjiznicaAPI.Controllers
{
    public class ClanController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int knjiznicaId)
        {
            IList<ClanViewModel> data = null;

            using (var ctx = new DBKNJIZNICAEntities())
            {
                data = ctx.Clans.Where(w => w.KnjiznicaID == knjiznicaId)
                            .Select(s => new ClanViewModel()
                            {
                                KnjiznicaID = s.KnjiznicaID,
                                ID = s.ID,
                                Ime = s.Ime,
                                Prezime = s.Prezime,
                                Email = s.Email,
                                KontaktBroj = s.KontaktBroj,
                                ClanarinaVrijediDo = s.ClanarinaVrijediDo


                            }).ToList();
            }

            if (data.Count == 0)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(ClanViewModel clanVM)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {
                var data = new Clan();

                data.KnjiznicaID = clanVM.KnjiznicaID;
                data.Ime = clanVM.Ime;
                data.Prezime = clanVM.Prezime;
                data.Email = clanVM.Email;
                data.KontaktBroj = clanVM.KontaktBroj;
                data.ClanarinaVrijediDo = clanVM.ClanarinaVrijediDo;

                ctx.Clans.Add(data);

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(ClanViewModel clanVM)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {

                var data = ctx.Clans
                    .Where(w => w.ID == clanVM.ID).SingleOrDefault();

                if (data == null)
                {
                    return NotFound();
                }

                data.KnjiznicaID = clanVM.KnjiznicaID;
                data.ID = clanVM.ID;
                data.Ime = clanVM.Ime;
                data.Prezime = clanVM.Prezime;
                data.Email = clanVM.Email;
                data.KontaktBroj = clanVM.KontaktBroj;
                data.ClanarinaVrijediDo = clanVM.ClanarinaVrijediDo;

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int ID)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {
                try
                {
                    var data = ctx.Clans
                                        .Where(w => w.ID == ID).SingleOrDefault();

                    if (data == null)
                    {
                        return NotFound();
                    }

                    ctx.Clans.Remove(data);

                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Član se ne može izbrisati");
                }
                
            }

            return Ok();
        }
    }
}
