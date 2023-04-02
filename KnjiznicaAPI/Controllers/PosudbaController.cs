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
        public IHttpActionResult Get()
        {
            IList<PosudbaViewModel> data = null;

            using (var ctx = new DBKNJIZNICAEntities())
            {
                data = ctx.Posudbas
                            .Select(s => new PosudbaViewModel()
                            {
                                ID = s.ID,
                                KnjiznicaID = s.KnjiznicaID,
                                KnjigaID = s.KnjigaID,
                                ClanID = s.ClanID,
                                ZaposlenikID = s.ZaposlenikID,
                                DatumPreuzimanja = s.DatumPreuzimanja,
                                DatumPovratka = s.DatumPovratka
                                
                            }).ToList();
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

                data.KnjiznicaID = posudbaVM.KnjiznicaID;
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

