using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using P11WebAPI.P11DbModel;

namespace P11WebAPI.Controllers
{
    public class PlayerTypeMasterController : ApiController
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: api/PlayerTypeMaster
        public IQueryable<M_PlayerTypeMaster> GetM_PlayerTypeMaster()
        {
            return db.M_PlayerTypeMaster;
        }

        // GET: api/PlayerTypeMaster/5
        [ResponseType(typeof(M_PlayerTypeMaster))]
        public async Task<IHttpActionResult> GetM_PlayerTypeMaster(int id)
        {
            M_PlayerTypeMaster m_PlayerTypeMaster = await db.M_PlayerTypeMaster.FindAsync(id);
            if (m_PlayerTypeMaster == null)
            {
                return NotFound();
            }

            return Ok(m_PlayerTypeMaster);
        }

        // PUT: api/PlayerTypeMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_PlayerTypeMaster(int id, M_PlayerTypeMaster m_PlayerTypeMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_PlayerTypeMaster.PlayerTypeID)
            {
                return BadRequest();
            }

            db.Entry(m_PlayerTypeMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_PlayerTypeMasterExists(id))
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

        // POST: api/PlayerTypeMaster
        [ResponseType(typeof(M_PlayerTypeMaster))]
        public async Task<IHttpActionResult> PostM_PlayerTypeMaster(M_PlayerTypeMaster m_PlayerTypeMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_PlayerTypeMaster.Add(m_PlayerTypeMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = m_PlayerTypeMaster.PlayerTypeID }, m_PlayerTypeMaster);
        }

        // DELETE: api/PlayerTypeMaster/5
        [ResponseType(typeof(M_PlayerTypeMaster))]
        public async Task<IHttpActionResult> DeleteM_PlayerTypeMaster(int id)
        {
            M_PlayerTypeMaster m_PlayerTypeMaster = await db.M_PlayerTypeMaster.FindAsync(id);
            if (m_PlayerTypeMaster == null)
            {
                return NotFound();
            }

            db.M_PlayerTypeMaster.Remove(m_PlayerTypeMaster);
            await db.SaveChangesAsync();

            return Ok(m_PlayerTypeMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_PlayerTypeMasterExists(int id)
        {
            return db.M_PlayerTypeMaster.Count(e => e.PlayerTypeID == id) > 0;
        }
    }
}