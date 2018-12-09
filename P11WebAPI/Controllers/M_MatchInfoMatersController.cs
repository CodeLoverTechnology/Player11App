using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using P11WebAPI.P11DbModel;

namespace P11WebAPI.Controllers
{
    public class M_MatchInfoMatersController : Controller
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: M_MatchInfoMaters
        public async Task<ActionResult> Index()
        {
            var m_MatchInfoMaters = db.M_MatchInfoMaters.Include(m => m.M_TeamInfoMaster).Include(m => m.M_TeamInfoMaster1);
            return View(await m_MatchInfoMaters.ToListAsync());
        }

        // GET: M_MatchInfoMaters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MatchInfoMaters m_MatchInfoMaters = await db.M_MatchInfoMaters.FindAsync(id);
            if (m_MatchInfoMaters == null)
            {
                return HttpNotFound();
            }
            return View(m_MatchInfoMaters);
        }

        // GET: M_MatchInfoMaters/Create
        public ActionResult Create()
        {
            ViewBag.Team1 = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName");
            ViewBag.Team2 = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName");
            return View();
        }

        // POST: M_MatchInfoMaters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MatchID,MatchLocation,Team1,Team2,MatchDate,Result,TotalOverMatch,LiveWatchingCount")] M_MatchInfoMaters m_MatchInfoMaters)
        {
            if (ModelState.IsValid)
            {
                m_MatchInfoMaters.CreatedBy = "System";
                m_MatchInfoMaters.CreatedDate = DateTime.Now;
                m_MatchInfoMaters.ModifiedBy = "System";
                m_MatchInfoMaters.ModifiedDate = DateTime.Now;
                m_MatchInfoMaters.Active = true;

                db.M_MatchInfoMaters.Add(m_MatchInfoMaters);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Team1 = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_MatchInfoMaters.Team1);
            ViewBag.Team2 = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_MatchInfoMaters.Team2);
            return View(m_MatchInfoMaters);
        }

        // GET: M_MatchInfoMaters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MatchInfoMaters m_MatchInfoMaters = await db.M_MatchInfoMaters.FindAsync(id);
            if (m_MatchInfoMaters == null)
            {
                return HttpNotFound();
            }
            ViewBag.Team1 = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_MatchInfoMaters.Team1);
            ViewBag.Team2 = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_MatchInfoMaters.Team2);
            return View(m_MatchInfoMaters);
        }

        // POST: M_MatchInfoMaters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MatchID,MatchLocation,Team1,Team2,MatchDate,Result,TotalOverMatch,LiveWatchingCount,CreatedBy,CreatedDate,Active")] M_MatchInfoMaters m_MatchInfoMaters)
        {
            if (ModelState.IsValid)
            {
                m_MatchInfoMaters.ModifiedBy = "System";
                m_MatchInfoMaters.ModifiedDate = DateTime.Now;
                db.Entry(m_MatchInfoMaters).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Team1 = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_MatchInfoMaters.Team1);
            ViewBag.Team2 = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_MatchInfoMaters.Team2);
            return View(m_MatchInfoMaters);
        }

        // GET: M_MatchInfoMaters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MatchInfoMaters m_MatchInfoMaters = await db.M_MatchInfoMaters.FindAsync(id);
            if (m_MatchInfoMaters == null)
            {
                return HttpNotFound();
            }
            return View(m_MatchInfoMaters);
        }

        // POST: M_MatchInfoMaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_MatchInfoMaters m_MatchInfoMaters = await db.M_MatchInfoMaters.FindAsync(id);
            db.M_MatchInfoMaters.Remove(m_MatchInfoMaters);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
