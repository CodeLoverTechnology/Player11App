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
using P11WebAPI.Models;
using P11WebAPI.P11DbModel;

namespace P11WebAPI.Controllers
{
    public class MatchInfoMatersController : ApiController
    {
        private P11DbEntities1 db = new P11DbEntities1();

        [Route("api/MatchInfoMaters/GetM_MatchInfoMaters")]
        // GET: api/MatchInfoMaters
        public IHttpActionResult GetM_MatchInfoMaters()
        {
            IList<C_MatchInfoModel> ObjMatchList = new List<C_MatchInfoModel>();
            M_TeamInfoMaster ObjTeam1 = new M_TeamInfoMaster();
            M_TeamInfoMaster ObjTeam2 = new M_TeamInfoMaster();
            var Result = db.M_MatchInfoMaters.OrderByDescending(x => x.MatchID);
            foreach (var s in Result)
            {
                ObjMatchList.Add(
                    new C_MatchInfoModel()
                    {
                        MatchID = s.MatchID,
                        MatchDate = s.MatchDate,
                        Team1 = s.Team1,
                        Team1Code=s.M_TeamInfoMaster.TeamCode,
                        Team1Logo=s.M_TeamInfoMaster.TeamLogo,
                        Team1Name=s.M_TeamInfoMaster.TeamName,                        
                        Team2 = s.Team2,
                        Team2Code = s.M_TeamInfoMaster1.TeamCode,
                        Team2Logo = s.M_TeamInfoMaster1.TeamLogo,
                        Team2Name = s.M_TeamInfoMaster1.TeamName,
                        MatchLocation = s.MatchLocation,
                        MatchBanner = s.MatchBanner,
                        LiveWatchingCount = s.LiveWatchingCount,
                        TotalOverMatch = s.TotalOverMatch
                    }
                    );
            }
            return Ok(ObjMatchList);
        }

        // GET: api/MatchInfoMaters/5
        [ResponseType(typeof(M_MatchInfoMaters))]
        public async Task<IHttpActionResult> GetM_MatchInfoMaters(int id)
        {
            M_MatchInfoMaters m_MatchInfoMaters = await db.M_MatchInfoMaters.FindAsync(id);
            if (m_MatchInfoMaters == null)
            {
                return NotFound();
            }

            return Ok(m_MatchInfoMaters);
        }

        // PUT: api/MatchInfoMaters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_MatchInfoMaters(int id, M_MatchInfoMaters m_MatchInfoMaters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_MatchInfoMaters.MatchID)
            {
                return BadRequest();
            }

            db.Entry(m_MatchInfoMaters).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_MatchInfoMatersExists(id))
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

        // POST: api/MatchInfoMaters
        [ResponseType(typeof(M_MatchInfoMaters))]
        public async Task<IHttpActionResult> PostM_MatchInfoMaters(M_MatchInfoMaters m_MatchInfoMaters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_MatchInfoMaters.Add(m_MatchInfoMaters);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = m_MatchInfoMaters.MatchID }, m_MatchInfoMaters);
        }

        // DELETE: api/MatchInfoMaters/5
        [ResponseType(typeof(M_MatchInfoMaters))]
        public async Task<IHttpActionResult> DeleteM_MatchInfoMaters(int id)
        {
            M_MatchInfoMaters m_MatchInfoMaters = await db.M_MatchInfoMaters.FindAsync(id);
            if (m_MatchInfoMaters == null)
            {
                return NotFound();
            }

            db.M_MatchInfoMaters.Remove(m_MatchInfoMaters);
            await db.SaveChangesAsync();

            return Ok(m_MatchInfoMaters);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_MatchInfoMatersExists(int id)
        {
            return db.M_MatchInfoMaters.Count(e => e.MatchID == id) > 0;
        }
    }
}