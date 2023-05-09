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
    public class ZaposlenikController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int knjiznicaId)
        {
            IList<ZaposlenikViewModel> data = null;

            using (var ctx = new DBKNJIZNICAEntities())
            {
                data = ctx.Zaposleniks
                            .Select(s => new ZaposlenikViewModel()
                            {
                                ID = s.ID,
                                KnjiznicaID = s.KnjiznicaID,
                                Ime = s.Ime,
                                Prezime = s.Prezime,
                                Email = s.Email,
                                KontaktBroj = s.KontaktBroj,
                                PocetakRada = s.PocetakRada,
                                Sifra = s.Sifra

                            }).ToList();
            }

            if (data.Count == 0)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(ZaposlenikViewModel zaposlenikVM)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {
                var data = new Zaposlenik();

                data.KnjiznicaID = zaposlenikVM.KnjiznicaID;
                data.Ime = zaposlenikVM.Ime;
                data.Prezime = zaposlenikVM.Prezime;
                data.Email = zaposlenikVM.Email;
                data.KontaktBroj = zaposlenikVM.KontaktBroj;
                data.PocetakRada = zaposlenikVM.PocetakRada;
                data.Sifra = zaposlenikVM.Sifra;

                ctx.Zaposleniks.Add(data);

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(ZaposlenikViewModel zaposlenikVM)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {

                var data = ctx.Zaposleniks
                    .Where(w => w.ID == zaposlenikVM.ID).SingleOrDefault();

                if (data == null)
                {
                    return NotFound();
                }

                //data.KnjiznicaID = zaposlenikVM.KnjiznicaID;
                data.Ime = zaposlenikVM.Ime;
                data.Prezime = zaposlenikVM.Prezime;
                data.Email = zaposlenikVM.Email;
                data.KontaktBroj = zaposlenikVM.KontaktBroj;
                data.PocetakRada = zaposlenikVM.PocetakRada;
                data.Sifra = zaposlenikVM.Sifra;

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
                    var data = ctx.Zaposleniks
                    .Where(w => w.ID == ID).SingleOrDefault();

                    if (data == null)
                    {
                        return NotFound();
                    }

                    ctx.Zaposleniks.Remove(data);

                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Zaposlenik se ne može izbrisati");
                }
                
            }

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetLogin(String email, int sifra)
        {
            ZaposlenikViewModel data = null;

            using (var ctx = new DBKNJIZNICAEntities())
            {
                data = ctx.Zaposleniks.Where(w => w.Email == email && w.Sifra == sifra)
                            .Select(s => new ZaposlenikViewModel()
                            {
                                ID = s.ID,
                                KnjiznicaID = s.KnjiznicaID,
                                Ime = s.Ime,
                                Prezime = s.Prezime,
                                Email = s.Email,
                                KontaktBroj = s.KontaktBroj,
                                PocetakRada = s.PocetakRada,
                                Sifra = s.Sifra

                            }).SingleOrDefault();
            }

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
