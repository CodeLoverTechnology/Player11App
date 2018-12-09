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
    public class M_MatchTopicMasterController : Controller
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: M_MatchTopicMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_MatchTopicMaster.ToListAsync());
        }

        // GET: M_MatchTopicMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MatchTopicMaster m_MatchTopicMaster = await db.M_MatchTopicMaster.FindAsync(id);
            if (m_MatchTopicMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_MatchTopicMaster);
        }

        // GET: M_MatchTopicMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_MatchTopicMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MatchTopicID,Topic,Description")] M_MatchTopicMaster m_MatchTopicMaster)
        {
            if (ModelState.IsValid)
            {
                m_MatchTopicMaster.CreatedBy = "System";
                m_MatchTopicMaster.CreatedDate = DateTime.Now;
                m_MatchTopicMaster.ModifiedBy = "System";
                m_MatchTopicMaster.ModifiedDate = DateTime.Now;
                m_MatchTopicMaster.Active = true;
                db.M_MatchTopicMaster.Add(m_MatchTopicMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_MatchTopicMaster);
        }

        // GET: M_MatchTopicMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MatchTopicMaster m_MatchTopicMaster = await db.M_MatchTopicMaster.FindAsync(id);
            if (m_MatchTopicMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_MatchTopicMaster);
        }

        // POST: M_MatchTopicMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MatchTopicID,Topic,Description,CreatedBy,CreatedDate,Active")] M_MatchTopicMaster m_MatchTopicMaster)
        {
            if (ModelState.IsValid)
            {
                m_MatchTopicMaster.ModifiedBy = "System";
                m_MatchTopicMaster.ModifiedDate = DateTime.Now;
                db.Entry(m_MatchTopicMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_MatchTopicMaster);
        }

        // GET: M_MatchTopicMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MatchTopicMaster m_MatchTopicMaster = await db.M_MatchTopicMaster.FindAsync(id);
            if (m_MatchTopicMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_MatchTopicMaster);
        }

        // POST: M_MatchTopicMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_MatchTopicMaster m_MatchTopicMaster = await db.M_MatchTopicMaster.FindAsync(id);
            db.M_MatchTopicMaster.Remove(m_MatchTopicMaster);
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
