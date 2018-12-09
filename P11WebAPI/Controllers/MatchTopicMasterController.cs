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
    public class MatchTopicMasterController : ApiController
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: api/M_MatchTopicMaster
        public IQueryable<M_MatchTopicMaster> GetM_MatchTopicMaster()
        {
            return db.M_MatchTopicMaster;
        }

        // GET: api/M_MatchTopicMaster/5
        [ResponseType(typeof(M_MatchTopicMaster))]
        public async Task<IHttpActionResult> GetM_MatchTopicMaster(int id)
        {
            M_MatchTopicMaster m_MatchTopicMaster = await db.M_MatchTopicMaster.FindAsync(id);
            if (m_MatchTopicMaster == null)
            {
                return NotFound();
            }

            return Ok(m_MatchTopicMaster);
        }

        // PUT: api/M_MatchTopicMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_MatchTopicMaster(int id, M_MatchTopicMaster m_MatchTopicMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_MatchTopicMaster.MatchTopicID)
            {
                return BadRequest();
            }

            db.Entry(m_MatchTopicMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_MatchTopicMasterExists(id))
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

        // POST: api/M_MatchTopicMaster
        [ResponseType(typeof(M_MatchTopicMaster))]
        public async Task<IHttpActionResult> PostM_MatchTopicMaster(M_MatchTopicMaster m_MatchTopicMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_MatchTopicMaster.Add(m_MatchTopicMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = m_MatchTopicMaster.MatchTopicID }, m_MatchTopicMaster);
        }

        // DELETE: api/M_MatchTopicMaster/5
        [ResponseType(typeof(M_MatchTopicMaster))]
        public async Task<IHttpActionResult> DeleteM_MatchTopicMaster(int id)
        {
            M_MatchTopicMaster m_MatchTopicMaster = await db.M_MatchTopicMaster.FindAsync(id);
            if (m_MatchTopicMaster == null)
            {
                return NotFound();
            }

            db.M_MatchTopicMaster.Remove(m_MatchTopicMaster);
            await db.SaveChangesAsync();

            return Ok(m_MatchTopicMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_MatchTopicMasterExists(int id)
        {
            return db.M_MatchTopicMaster.Count(e => e.MatchTopicID == id) > 0;
        }
    }
}