using KnjiznicaAPI.Models;
using KnjiznicaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnjiznicaAPI.Controllers
{
    public class PosudbaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string filter, int knjiznicaId)
        {
            IList<PosudbaViewModel> data = null;

            using (var ctx = new DBKNJIZNICAEntities())
            {
                if (String.IsNullOrEmpty(filter))
                {
                    data = ctx.Posudbas.Include("Knjiga").Include("Zaposlenik").Include("Clan")
                        .Where(w => w.KnjiznicaID == knjiznicaId)
                                .Select(s => new PosudbaViewModel()
                                {

                                    ID = s.ID,
                                    KnjiznicaID = s.KnjiznicaID,
                                    ClanID = s.ClanID,
                                    ZaposlenikID = s.ZaposlenikID,
                                    KnjigaID = s.KnjigaID,
                                    DatumPreuzimanja = s.DatumPreuzimanja,
                                    DatumPovratka = s.DatumPovratka,
                                    Clan = s.Clan.Ime + " " + s.Clan.Prezime,
                                    Knjiga = s.Knjiga.NazivKnjige + " " + s.Knjiga.Pisac,
                                    Zaposlenik = s.Zaposlenik.Ime + " " + s.Zaposlenik.Prezime,


                                }).ToList();
                }
                else
                {
                    data = ctx.Posudbas.Include("Knjiga").Include("Zaposlenik").Include("Clan")
                        .Where(w => w.Knjiga.NazivKnjige.Contains(filter) && w.KnjiznicaID == knjiznicaId ||
                        w.Clan.Ime.Contains(filter) && w.KnjiznicaID == knjiznicaId || w.Clan.Prezime.Contains(filter) && w.KnjiznicaID == knjiznicaId)
                                .Select(s => new PosudbaViewModel()
                                {
                                    ID = s.ID,
                                    KnjiznicaID = s.KnjiznicaID,
                                    ClanID = s.ClanID,
                                    ZaposlenikID = s.ZaposlenikID,
                                    KnjigaID = s.KnjigaID,
                                    DatumPreuzimanja = s.DatumPreuzimanja,
                                    DatumPovratka = s.DatumPovratka,
                                    Clan = s.Clan.Ime + " " + s.Clan.Prezime,
                                    Knjiga = s.Knjiga.NazivKnjige + " " + s.Knjiga.Pisac,
                                    Zaposlenik = s.Zaposlenik.Ime + " " + s.Zaposlenik.Prezime
                                }).ToList();
                }
            }

            if (data.Count == 0)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(PosudbaViewModel posudbaVM)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {
                var data = new Posudba();

                data.KnjiznicaID = posudbaVM.KnjiznicaID;
                data.KnjigaID = posudbaVM.KnjigaID;
                data.ClanID = posudbaVM.ClanID;
                data.ZaposlenikID = posudbaVM.ZaposlenikID;
                data.DatumPreuzimanja = posudbaVM.DatumPreuzimanja;
                data.DatumPovratka = posudbaVM.DatumPovratka;

                ctx.Posudbas.Add(data);

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(PosudbaViewModel posudbaVM)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {

                var data = ctx.Posudbas
                    .Where(w => w.ID == posudbaVM.ID).SingleOrDefault();

                if (data == null)
                {
                    return NotFound();
                }

                //data.KnjiznicaID = posudbaVM.KnjiznicaID;
                data.KnjigaID = posudbaVM.KnjigaID;
                data.ClanID = posudbaVM.ClanID;
                data.ZaposlenikID = posudbaVM.ZaposlenikID;
                data.DatumPreuzimanja = posudbaVM.DatumPreuzimanja;
                data.DatumPovratka = posudbaVM.DatumPovratka;

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int ID)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {

                var data = ctx.Posudbas
                    .Where(w => w.ID == ID).SingleOrDefault();

                if (data == null)
                {
                    return NotFound();
                }

                ctx.Posudbas.Remove(data);

                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}

