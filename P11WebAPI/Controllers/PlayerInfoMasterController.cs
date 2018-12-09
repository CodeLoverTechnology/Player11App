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
    public class PlayerInfoMasterController : ApiController
    {
        private P11DbEntities1 db = new P11DbEntities1();

        [HttpGet]
        [Route("api/PlayerInfoMaster/GetM_PlayerInfoMaster")]
        public IHttpActionResult GetM_PlayerInfoMaster()
        {
            IList<M_PlayerInfoMaster> ObjPlayerList = new List<M_PlayerInfoMaster>();

            var Result = db.M_PlayerInfoMaster.OrderByDescending(x => x.PlayerID);
            foreach (var s in Result)
            {
                ObjPlayerList.Add(
                    new M_PlayerInfoMaster()
                    {
                        PlayerID = s.PlayerID,
                        PlayerName = s.PlayerName,
                        PlayerSpecialization = s.PlayerSpecialization,
                        PlayerTypeID = s.PlayerTypeID,
                        TeamID = s.TeamID
                    }
                    );
            }
            return Ok(ObjPlayerList);
        }

        [HttpGet]
        [Route("api/PlayerInfoMaster/GetPlayerPics")]
        public IHttpActionResult GetPlayerPics()//(int PlayerID)
        {
            var Result = (from s in db.M_PlayerInfoMaster.OrderByDescending(x => x.PlayerID) select new { s.PlayerID, s.PlayerImage }).FirstOrDefault(); //.Where(x => x.PlayerID == PlayerID)
            return Ok(Result);
        }
        [HttpPost]
        [Route("api/PlayerInfoMaster/GetM_PlayerInfoMaster_WithID")]
        public async Task<IHttpActionResult> GetM_PlayerInfoMaster(int id)
        {
            M_PlayerInfoMaster m_PlayerInfoMaster = await db.M_PlayerInfoMaster.FindAsync(id);
            if (m_PlayerInfoMaster == null)
            {
                return NotFound();
            }

            return Ok(m_PlayerInfoMaster);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_PlayerInfoMaster(int id, M_PlayerInfoMaster m_PlayerInfoMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_PlayerInfoMaster.PlayerID)
            {
                return BadRequest();
            }

            db.Entry(m_PlayerInfoMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_PlayerInfoMasterExists(id))
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

        // POST: api/PlayerInfoMaster
        [ResponseType(typeof(M_PlayerInfoMaster))]
        public async Task<IHttpActionResult> PostM_PlayerInfoMaster(M_PlayerInfoMaster m_PlayerInfoMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_PlayerInfoMaster.Add(m_PlayerInfoMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = m_PlayerInfoMaster.PlayerID }, m_PlayerInfoMaster);
        }

        // DELETE: api/PlayerInfoMaster/5
        [ResponseType(typeof(M_PlayerInfoMaster))]
        public async Task<IHttpActionResult> DeleteM_PlayerInfoMaster(int id)
        {
            M_PlayerInfoMaster m_PlayerInfoMaster = await db.M_PlayerInfoMaster.FindAsync(id);
            if (m_PlayerInfoMaster == null)
            {
                return NotFound();
            }

            db.M_PlayerInfoMaster.Remove(m_PlayerInfoMaster);
            await db.SaveChangesAsync();

            return Ok(m_PlayerInfoMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_PlayerInfoMasterExists(int id)
        {
            return db.M_PlayerInfoMaster.Count(e => e.PlayerID == id) > 0;
        }
    }
}