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
    public class M_Match_PlayerMappingTableController : Controller
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: Match_PlayerMappingTable
        public async Task<ActionResult> Index()
        {
            var t_Match_PlayerMappingTable = db.T_Match_PlayerMappingTable.Include(t => t.M_MatchInfoMaters).Include(t => t.M_PlayerInfoMaster);
            return View(await t_Match_PlayerMappingTable.ToListAsync());
        }

        // GET: Match_PlayerMappingTable/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Match_PlayerMappingTable t_Match_PlayerMappingTable = await db.T_Match_PlayerMappingTable.FindAsync(id);
            if (t_Match_PlayerMappingTable == null)
            {
                return HttpNotFound();
            }
            return View(t_Match_PlayerMappingTable);
        }

        // GET: Match_PlayerMappingTable/Create
        public ActionResult Create()
        {
            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation");
            ViewBag.PlayerID = new SelectList(db.M_PlayerInfoMaster, "PlayerID", "PlayerName");
            return View();
        }

        // POST: Match_PlayerMappingTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PlayerMatchID,MatchID,PlayerID,PlayerPosition")] T_Match_PlayerMappingTable t_Match_PlayerMappingTable)
        {
            if (ModelState.IsValid)
            {
                t_Match_PlayerMappingTable.CreatedBy = "System";
                t_Match_PlayerMappingTable.ModifiedBy = "System";
                t_Match_PlayerMappingTable.CreatedDate = DateTime.Now;
                t_Match_PlayerMappingTable.ModifiedDate = DateTime.Now;
                t_Match_PlayerMappingTable.Active = true;
                db.T_Match_PlayerMappingTable.Add(t_Match_PlayerMappingTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_Match_PlayerMappingTable.MatchID);
            ViewBag.PlayerID = new SelectList(db.M_PlayerInfoMaster, "PlayerID", "PlayerName", t_Match_PlayerMappingTable.PlayerID);
            return View(t_Match_PlayerMappingTable);
        }

        // GET: Match_PlayerMappingTable/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Match_PlayerMappingTable t_Match_PlayerMappingTable = await db.T_Match_PlayerMappingTable.FindAsync(id);
            if (t_Match_PlayerMappingTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_Match_PlayerMappingTable.MatchID);
            ViewBag.PlayerID = new SelectList(db.M_PlayerInfoMaster, "PlayerID", "PlayerName", t_Match_PlayerMappingTable.PlayerID);
            return View(t_Match_PlayerMappingTable);
        }

        // POST: Match_PlayerMappingTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PlayerMatchID,MatchID,PlayerID,PlayerPosition,CreatedBy,CreatedDate,Active")] T_Match_PlayerMappingTable t_Match_PlayerMappingTable)
        {
            if (ModelState.IsValid)
            {
                t_Match_PlayerMappingTable.ModifiedBy = "System";
                t_Match_PlayerMappingTable.ModifiedDate = DateTime.Now;
                db.Entry(t_Match_PlayerMappingTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_Match_PlayerMappingTable.MatchID);
            ViewBag.PlayerID = new SelectList(db.M_PlayerInfoMaster, "PlayerID", "PlayerName", t_Match_PlayerMappingTable.PlayerID);
            return View(t_Match_PlayerMappingTable);
        }

        // GET: Match_PlayerMappingTable/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Match_PlayerMappingTable t_Match_PlayerMappingTable = await db.T_Match_PlayerMappingTable.FindAsync(id);
            if (t_Match_PlayerMappingTable == null)
            {
                return HttpNotFound();
            }
            return View(t_Match_PlayerMappingTable);
        }

        // POST: Match_PlayerMappingTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_Match_PlayerMappingTable t_Match_PlayerMappingTable = await db.T_Match_PlayerMappingTable.FindAsync(id);
            db.T_Match_PlayerMappingTable.Remove(t_Match_PlayerMappingTable);
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
