using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ModelLibary.Models;
using REST_Service.Models;

namespace REST_Service.Controllers
{
    public class PakkeKontrolsController : ApiController
    {
        private PakkeKontrolEF db = new PakkeKontrolEF();

        // GET: api/PakkeKontrols
        public List<PakkeKontrol> GetPakkeKontrol()
        {
            IQueryable<PakkeKontrolEFM> EFMList = db.PakkeKontrol;
            List<PakkeKontrol> list = new List<PakkeKontrol>();

            foreach (PakkeKontrolEFM efm in EFMList)
            {
                list.Add(EFM2PakkeKontrol(efm));
            }
            return list;
        }

        // GET: api/PakkeKontrols/5
        //[ResponseType(typeof(PakkeKontrolEFM))]
        //public IHttpActionResult GetPakkeKontrol(int id)
        //{
        //    PakkeKontrolEFM pakkeKontrol = db.PakkeKontrol.Find(id);
        //    if (pakkeKontrol == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(pakkeKontrol);
        //}

        // PUT: api/PakkeKontrols/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPakkeKontrol(int id, PakkeKontrolEFM pakkeKontrol)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != pakkeKontrol.Process_Ordre_Nr)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(pakkeKontrol).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PakkeKontrolExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/PakkeKontrols
        [ResponseType(typeof(PakkeKontrol))]
        public IHttpActionResult PostPakkeKontrol(PakkeKontrol pakkeKontrol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PakkeKontrolEFM PKEFM = PakkeKontrol2EFM(pakkeKontrol);
            db.PakkeKontrol.Add(PKEFM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (PakkeKontrolExists(PKEFM.Process_Ordre_Nr, PKEFM.Tidspunkt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = PKEFM.Process_Ordre_Nr }, EFM2PakkeKontrol(PKEFM));
        }

        // DELETE: api/PakkeKontrols/5
        [ResponseType(typeof(PakkeKontrolEFM))]
        //public IHttpActionResult DeletePakkeKontrol(int id)
        //{
        //    PakkeKontrolEFM pakkeKontrol = db.PakkeKontrol.Find(id);
        //    if (pakkeKontrol == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PakkeKontrol.Remove(pakkeKontrol);
        //    db.SaveChanges();

        //    return Ok(pakkeKontrol);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PakkeKontrolExists(int id , DateTime time)
        {

            if (db.PakkeKontrol.Count(e => e.Process_Ordre_Nr == id) > 0)
            {
                if (db.PakkeKontrol.Count(f => f.Tidspunkt == time) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private PakkeKontrol EFM2PakkeKontrol(PakkeKontrolEFM EFM)
        {
            PakkeKontrol PK = new PakkeKontrol();

            PK.ProsessOrderNr = EFM.Process_Ordre_Nr;
            PK.Tidspunkt = EFM.Tidspunkt;
            PK.PaaBanerPaller = EFM.Paa_Baner_Paller;
            PK.FolieRaavareNr = EFM.Folie_Raavare_Nr;
            PK.KatonRåvareNr = EFM.Karton_Raavare_Nr;
            PK.HoldbarhedsDato = EFM.Holdbarheds_Dato;
            PK.ProduktionsDato = EFM.Produktions_Dato;
            PK.Print1HolDato = EFM.Printer1_Holdbarheds_Dato;
            PK.Print1ProDato = EFM.Printer1_Produktion_Dato;
            PK.Print2HolDato = EFM.Printer2_Holdbarheds_Dato;
            PK.Print2ProDato = EFM.Printer2_Produktion_Dato;
            PK.FyldeHojdeKontrol = EFM.FyldeHojde_Kontrol;
            PK.SkridlimKarton = EFM.Skridlim_Karton;
            PK.KontrolStabelMonster = EFM.Kontrol_StabelMonster;
            PK.KontrolAverylable = EFM.Kontrol_Averylabel;
            PK.PuTunnelV = EFM.Pu_Tunnelpasteur_V.GetValueOrDefault(-1);
            PK.PuTunnelM = EFM.Pu_Tunnelpasteur_M.GetValueOrDefault(-1);
            PK.PuTunnelH = EFM.Pu_Tunnelpasteur_H.GetValueOrDefault(-1);
            PK.HelhedsIndtryk = EFM.Helhedsindtryk;
            PK.KontrolPalleNr = EFM.Kontrol_Palle_Nr.GetValueOrDefault(-1);
            PK.FremmedDaaserKarton = EFM.Fremmede_Daaser_Karton;
            PK.Signatur = EFM.Signatur;

            return PK;
        }

        

        private PakkeKontrolEFM PakkeKontrol2EFM(PakkeKontrol PK)
        {
            PakkeKontrolEFM E = new PakkeKontrolEFM();

            E.Process_Ordre_Nr = PK.ProsessOrderNr;
            E.Tidspunkt = PK.Tidspunkt;
            E.Paa_Baner_Paller = PK.PaaBanerPaller;
            E.Folie_Raavare_Nr = PK.FolieRaavareNr;
            E.Karton_Raavare_Nr = PK.KatonRåvareNr;
            E.Holdbarheds_Dato = PK.HoldbarhedsDato;
            E.Produktions_Dato = PK.ProduktionsDato;
            E.Printer1_Holdbarheds_Dato = PK.Print1HolDato;
            E.Printer1_Produktion_Dato = PK.Print1ProDato;
            E.Printer2_Holdbarheds_Dato = PK.Print2HolDato;
            E.Printer2_Produktion_Dato = PK.Print2ProDato;
            E.FyldeHojde_Kontrol = PK.FyldeHojdeKontrol;
            E.Skridlim_Karton = PK.SkridlimKarton;
            E.Kontrol_StabelMonster = PK.KontrolStabelMonster;
            E.Kontrol_Averylabel = PK.KontrolStabelMonster;
            E.Pu_Tunnelpasteur_V = TjekNull(PK.PuTunnelV);
            E.Pu_Tunnelpasteur_M = TjekNull(PK.PuTunnelM);
            E.Pu_Tunnelpasteur_H = TjekNull(PK.PuTunnelH);
            E.Helhedsindtryk = PK.HelhedsIndtryk;
            E.Kontrol_Palle_Nr = TjekNullint(PK.KontrolPalleNr);
            E.Fremmede_Daaser_Karton = PK.FremmedDaaserKarton;
            E.Signatur = PK.Signatur;

            return E;
        }

        private double? TjekNull(double Pk)
        {
            if (Pk == -1)
            {
                return null;
            }

            return Pk;
        }

        private int? TjekNullint(int Pk)
        {
            if (Pk == -1)
            {
                return null;
            }

            return Pk;
        }
    }
}