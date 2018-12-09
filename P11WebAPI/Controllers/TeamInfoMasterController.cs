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
    public class TeamInfoMasterController : ApiController
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: api/TeamInfoMaster
        public IQueryable<M_TeamInfoMaster> GetM_TeamInfoMaster()
        {
            return db.M_TeamInfoMaster;
        }

        // GET: api/TeamInfoMaster/5
        [ResponseType(typeof(M_TeamInfoMaster))]
        public async Task<IHttpActionResult> GetM_TeamInfoMaster(int id)
        {
            M_TeamInfoMaster m_TeamInfoMaster = await db.M_TeamInfoMaster.FindAsync(id);
            if (m_TeamInfoMaster == null)
            {
                return NotFound();
            }

            return Ok(m_TeamInfoMaster);
        }

        // PUT: api/TeamInfoMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_TeamInfoMaster(int id, M_TeamInfoMaster m_TeamInfoMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_TeamInfoMaster.TeamID)
            {
                return BadRequest();
            }

            db.Entry(m_TeamInfoMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_TeamInfoMasterExists(id))
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

        // POST: api/TeamInfoMaster
        [ResponseType(typeof(M_TeamInfoMaster))]
        public async Task<IHttpActionResult> PostM_TeamInfoMaster(M_TeamInfoMaster m_TeamInfoMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_TeamInfoMaster.Add(m_TeamInfoMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = m_TeamInfoMaster.TeamID }, m_TeamInfoMaster);
        }

        // DELETE: api/TeamInfoMaster/5
        [ResponseType(typeof(M_TeamInfoMaster))]
        public async Task<IHttpActionResult> DeleteM_TeamInfoMaster(int id)
        {
            M_TeamInfoMaster m_TeamInfoMaster = await db.M_TeamInfoMaster.FindAsync(id);
            if (m_TeamInfoMaster == null)
            {
                return NotFound();
            }

            db.M_TeamInfoMaster.Remove(m_TeamInfoMaster);
            await db.SaveChangesAsync();

            return Ok(m_TeamInfoMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_TeamInfoMasterExists(int id)
        {
            return db.M_TeamInfoMaster.Count(e => e.TeamID == id) > 0;
        }
    }
}