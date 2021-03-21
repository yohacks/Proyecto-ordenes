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
using System.IO;
using ExcelDataReader;

namespace OrdenCompraAPI.Controllers
{
    public class OrdenCompraFiltroController : ApiController
    {
        private ModelOrdenDB db = new ModelOrdenDB();

        // GET: api/ORDEN_COMPRA
        public IQueryable<ORDEN_COMPRA> GetORDEN_COMPRA()
        {
            return db.ORDEN_COMPRA;
        }

        // GET: api/OrdenCompraPorId/5
        [ResponseType(typeof(ORDEN_COMPRA))]
        public IHttpActionResult GetOrdenCompraPorId(int id)
        {
            ORDEN_COMPRA orden = db.ORDEN_COMPRA.Where(o => o.ID_ORDEN == id).FirstOrDefault();
            if (orden == null)
            {
                return NotFound();
            }

            return Ok(orden);

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
        public IHttpActionResult ORDEN_COMPRA(ORDEN_COMPRA oRDEN_COMPRA)
        {

            //Ruta del fichero Excel
            string filePath = "ArchivosServer/ORDEN_COMPRA.xlsx";

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    DataTable table = result.Tables[0];
                    DataRow row = table.Rows[1];
                    string cell = row[0].ToString();

                    if (table.Rows.Count > 0)
                    {
                        //for (int i = 0; i < table.Rows.Count; i++)
                        //{

                        //    orden.FECHA_REGISTRO=  DateTime.Parse(row[0].ToString()); 
                        //    var variable = row[0].ToString();
                        //}

                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (table.Rows[i][1].ToString() != "ID")
                            {

                                ORDEN_COMPRA orden = new ORDEN_COMPRA();
                                var guidVacio = Guid.Parse("00000000-0000-0000-0000-000000000000");
                                if (orden.GUID == guidVacio)
                                {
                                    orden.GUID = Guid.NewGuid();
                                }
                                orden.FECHA_REGISTRO = DateTime.Parse(table.Rows[i][0].ToString());
                                orden.ID_ORDEN = Int32.Parse(table.Rows[i][1].ToString());
                                orden.NOMBRE_VENDEDOR = table.Rows[i][2].ToString();
                                orden.DIRECCION_VENDEDOR = table.Rows[i][3].ToString();
                                orden.TELEFONO_VENDEDOR = table.Rows[i][4].ToString();
                                orden.NOMBRE_COMPRADOR = table.Rows[i][5].ToString();
                                orden.DIRECCION_COMPRADOR = table.Rows[i][6].ToString();
                                orden.TELEFONO_COMPRADOR = table.Rows[i][7].ToString();
                                orden.CIUDAD_ENTREGA = table.Rows[i][8].ToString();
                                orden.VALOR = Int32.Parse(table.Rows[i][9].ToString());
                                orden.VALOR_IVA = Int32.Parse(table.Rows[i][10].ToString());
                                orden.AUTORIZADO_POR = table.Rows[i][11].ToString();
                                orden.OBSERVACIONES = table.Rows[i][12].ToString();
                                orden.PROCEDENCIA = "Automático";

                                //orden.FECHA_REGISTRO = item.ItemArray[0];
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
                            }

                        }
                    }
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ORDEN_COMPRAExists(oRDEN_COMPRA.GUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(true);
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