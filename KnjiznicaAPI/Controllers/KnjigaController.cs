﻿using KnjiznicaAPI.Models;
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
    public class KnjigaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int knjiznicaId)
        {
            IList<KnjigaViewModel> data = null;

            using (var ctx = new DBKNJIZNICAEntities())
            {
                data = ctx.Knjigas.Where(w => w.KnjiznicaID == knjiznicaId)
                            .Select(s => new KnjigaViewModel()
                            {
                                ID = s.ID,
                                KnjiznicaID = s.KnjiznicaID,
                                NazivKnjige = s.NazivKnjige,
                                Pisac = s.Pisac

                            }).ToList();
            }

            if (data.Count == 0)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(KnjigaViewModel knjigaVM)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {
                var data = new Knjiga();

                data.NazivKnjige = knjigaVM.NazivKnjige;
                data.Pisac = knjigaVM.Pisac;
                data.KnjiznicaID = knjigaVM.KnjiznicaID;

                ctx.Knjigas.Add(data);
                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(KnjigaViewModel knjigaVM)
        {
            using (var ctx = new DBKNJIZNICAEntities())
            {

                var data = ctx.Knjigas
                    .Where(w => w.ID == knjigaVM.ID).SingleOrDefault();

                if (data == null)
                {
                    return NotFound();
                }

                data.NazivKnjige = knjigaVM.NazivKnjige;
                data.Pisac = knjigaVM.Pisac;

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
                    var data = ctx.Knjigas
                    .Where(w => w.ID == ID).SingleOrDefault();

                    if (data == null)
                    {
                        return NotFound();
                    }

                    ctx.Knjigas.Remove(data);

                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Knjiga se ne može izbrisati");
                }
                
            }

            return Ok();
        }
    }
}
