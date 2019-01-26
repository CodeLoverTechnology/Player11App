using P11WebAPI.P11DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace P11WebAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: M_MatchInfoMaters
        public async Task<ActionResult> Index()
        {
            var m_MatchInfoMaters = db.M_MatchInfoMaters.Include(m => m.M_TeamInfoMaster).Include(m => m.M_TeamInfoMaster1);
            return View(await m_MatchInfoMaters.ToListAsync());
        }

        public async Task<ActionResult> MatchInfo(int MatchID)
        {
            if (string.IsNullOrEmpty(MatchID.ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<T_Match_PlayerMappingTable> ObjT_Match_PlayerMappingTable = new List<T_Match_PlayerMappingTable>();
            M_MatchInfoMaters m_MatchInfoMaters = await db.M_MatchInfoMaters.FindAsync(MatchID);
            ObjT_Match_PlayerMappingTable = await db.T_Match_PlayerMappingTable.Where(x=>x.MatchID==MatchID).ToListAsync();
            if (m_MatchInfoMaters == null)
            {
                return HttpNotFound();
            }
            return View(ObjT_Match_PlayerMappingTable);
        }
    }
}