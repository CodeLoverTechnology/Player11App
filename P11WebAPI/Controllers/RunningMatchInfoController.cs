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
    public class RunningMatchInfoController : Controller
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: RunningMatchInfo
        public async Task<ActionResult> Index()
        {
            var t_RunningMatchInfo = db.T_RunningMatchInfo.Include(t => t.M_MatchInfoMaters);
            return View(await t_RunningMatchInfo.ToListAsync());
        }

        // GET: RunningMatchInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_RunningMatchInfo t_RunningMatchInfo = await db.T_RunningMatchInfo.Where(x=>x.MatchID==id).FirstOrDefaultAsync();
            if (t_RunningMatchInfo == null)
            {
                return HttpNotFound();
            }
            return View(t_RunningMatchInfo);
        }

        // GET: RunningMatchInfo/Create
        public ActionResult Create()
        {
            var MatchDetails = (from c in db.M_MatchInfoMaters
                                select new SelectListItem
                           {
                               Text = c.M_TeamInfoMaster.TeamCode + "-" + c.M_TeamInfoMaster1.TeamCode+"-"+ c.MatchLocation,
                               Value = c.MatchID.ToString()
                           });
            ViewBag.MatchID = new SelectList(MatchDetails, "Value", "Text");

            //ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "Team1"+ "Team2"+ "MatchLocation");
            return View();
        }

        // POST: RunningMatchInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,MatchID,MatchDescription,Notes")] T_RunningMatchInfo t_RunningMatchInfo)
        {
            if (ModelState.IsValid)
            {
                t_RunningMatchInfo.CreatedBy = "Admin";
                t_RunningMatchInfo.CreatedDate = DateTime.Now;
                t_RunningMatchInfo.ModifiedBy = "Admin";
                t_RunningMatchInfo.ModifiedDate = DateTime.Now;
                t_RunningMatchInfo.Active = true;
                db.T_RunningMatchInfo.Add(t_RunningMatchInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_RunningMatchInfo.MatchID);
            return View(t_RunningMatchInfo);
        }

        // GET: RunningMatchInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_RunningMatchInfo t_RunningMatchInfo = await db.T_RunningMatchInfo.FindAsync(id);
            if (t_RunningMatchInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_RunningMatchInfo.MatchID);
            return View(t_RunningMatchInfo);
        }

        // POST: RunningMatchInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,MatchID,MatchDescription,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] T_RunningMatchInfo t_RunningMatchInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_RunningMatchInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_RunningMatchInfo.MatchID);
            return View(t_RunningMatchInfo);
        }

        // GET: RunningMatchInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_RunningMatchInfo t_RunningMatchInfo = await db.T_RunningMatchInfo.FindAsync(id);
            if (t_RunningMatchInfo == null)
            {
                return HttpNotFound();
            }
            return View(t_RunningMatchInfo);
        }

        // POST: RunningMatchInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_RunningMatchInfo t_RunningMatchInfo = await db.T_RunningMatchInfo.FindAsync(id);
            db.T_RunningMatchInfo.Remove(t_RunningMatchInfo);
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
