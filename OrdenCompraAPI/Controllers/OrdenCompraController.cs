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
using OrdenCompraAPI.Models;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace OrdenCompraAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdenCompraController : ApiController
    {
        private ModelOrdenDB db = new ModelOrdenDB();

        // GET: api/ORDEN_COMPRA
        public IQueryable<ORDEN_COMPRA> GetORDEN_COMPRA()
        {
            return db.ORDEN_COMPRA;
        }

        // GET: api/ORDEN_COMPRA/5
        [ResponseType(typeof(ORDEN_COMPRA))]
        public IHttpActionResult GetORDEN_COMPRA(Guid id)
        {
            ORDEN_COMPRA oRDEN_COMPRA = db.ORDEN_COMPRA.Find(id);
            if (oRDEN_COMPRA == null)
            {
                return NotFound();
            }

            return Ok(oRDEN_COMPRA);
        }

        // PUT: api/ORDEN_COMPRA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORDEN_COMPRA(Guid id, ORDEN_COMPRA oRDEN_COMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRDEN_COMPRA.GUID)
            {
                return BadRequest();
            }

            db.Entry(oRDEN_COMPRA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDEN_COMPRAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ORDEN_COMPRA
        [ResponseType(typeof(ORDEN_COMPRA))]
        public IHttpActionResult PostORDEN_COMPRA(ORDEN_COMPRA orden)
        {
            var guidVacio = Guid.Parse("00000000-0000-0000-0000-000000000000");
            if (orden.GUID == guidVacio)
            {
                orden.GUID = Guid.NewGuid();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORDEN_COMPRA.Add(orden);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ORDEN_COMPRAExists(orden.GUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orden.GUID }, orden);
        }

        // DELETE: api/ORDEN_COMPRA/5
        [ResponseType(typeof(ORDEN_COMPRA))]
        public IHttpActionResult DeleteORDEN_COMPRA(Guid id)
        {
            ORDEN_COMPRA oRDEN_COMPRA = db.ORDEN_COMPRA.Find(id);
            if (oRDEN_COMPRA == null)
            {
                return NotFound();
            }

            db.ORDEN_COMPRA.Remove(oRDEN_COMPRA);
            db.SaveChanges();

            return Ok(oRDEN_COMPRA);
        }

   
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORDEN_COMPRAExists(Guid id)
        {
            return db.ORDEN_COMPRA.Count(e => e.GUID == id) > 0;
        }
    }
}