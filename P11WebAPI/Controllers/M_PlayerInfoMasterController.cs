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
using System.IO;
using P11WebAPI.App_Code;
using System.Drawing;

namespace P11WebAPI.Controllers
{
    public class M_PlayerInfoMasterController : Controller
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: M_PlayerInfoMaster
        public async Task<ActionResult> Index()
        {
            var m_PlayerInfoMaster = db.M_PlayerInfoMaster.Include(m => m.M_TeamInfoMaster).Include(m => m.M_PlayerTypeMaster);
            return View(await m_PlayerInfoMaster.ToListAsync());
        }

        // GET: M_PlayerInfoMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PlayerInfoMaster m_PlayerInfoMaster = await db.M_PlayerInfoMaster.FindAsync(id);
            if (m_PlayerInfoMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_PlayerInfoMaster);
        }

        // GET: M_PlayerInfoMaster/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName");
            ViewBag.PlayerTypeID = new SelectList(db.M_PlayerTypeMaster, "PlayerTypeID", "PlayerType");
            return View();
        }

        // POST: M_PlayerInfoMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PlayerID,TeamID,PlayerName,PlayerTypeID,PlayerSpecialization,Description,PlayerImage")] M_PlayerInfoMaster m_PlayerInfoMaster)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["PlayerImage"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.P11Resources.UploadedImages);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        string FullPathWithFileName = FolderPath + "\\" + Request.Files["PlayerImage"].FileName;
                        string FolderPathForImage = Request.Files["PlayerImage"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;

                        Request.Files["PlayerImage"].SaveAs(FullPathWithFileName);
                        using (Image image = Image.FromFile(FullPathWithFileName))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                string base64String = Convert.ToBase64String(imageBytes);
                                m_PlayerInfoMaster.PlayerImage= base64String;
                                CommonFunction.IsFolderExist(FullPathWithFileName);
                            }
                        }
                    }
                }
                m_PlayerInfoMaster.CreatedBy = "System";
                m_PlayerInfoMaster.CreatedDate = DateTime.Now;
                m_PlayerInfoMaster.ModifiedBy = "System";
                m_PlayerInfoMaster.ModifiedDate = DateTime.Now;
                m_PlayerInfoMaster.Active = true;

                db.M_PlayerInfoMaster.Add(m_PlayerInfoMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_PlayerInfoMaster.TeamID);
            ViewBag.PlayerTypeID = new SelectList(db.M_PlayerTypeMaster, "PlayerTypeID", "PlayerType", m_PlayerInfoMaster.PlayerTypeID);
            return View(m_PlayerInfoMaster);
        }

        // GET: M_PlayerInfoMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PlayerInfoMaster m_PlayerInfoMaster = await db.M_PlayerInfoMaster.FindAsync(id);
            if (m_PlayerInfoMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_PlayerInfoMaster.TeamID);
            ViewBag.PlayerTypeID = new SelectList(db.M_PlayerTypeMaster, "PlayerTypeID", "PlayerType", m_PlayerInfoMaster.PlayerTypeID);
            return View(m_PlayerInfoMaster);
        }

        // POST: M_PlayerInfoMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PlayerID,TeamID,PlayerName,PlayerTypeID,PlayerSpecialization,Description,PlayerImage,CreatedBy,CreatedDate,Active")] M_PlayerInfoMaster m_PlayerInfoMaster)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["PlayerImage"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.P11Resources.UploadedImages);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        string FullPathWithFileName = FolderPath + "\\" + Request.Files["PlayerImage"].FileName;
                        string FolderPathForImage = Request.Files["PlayerImage"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;

                        Request.Files["PlayerImage"].SaveAs(FullPathWithFileName);
                        using (Image image = Image.FromFile(FullPathWithFileName))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                string base64String = Convert.ToBase64String(imageBytes);
                                m_PlayerInfoMaster.PlayerImage = base64String;
                                CommonFunction.IsFolderExist(FullPathWithFileName);
                            }
                        }
                    }
                }
                m_PlayerInfoMaster.ModifiedBy = "System";
                m_PlayerInfoMaster.ModifiedDate = DateTime.Now;
                m_PlayerInfoMaster.Active = true;

                db.Entry(m_PlayerInfoMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.M_TeamInfoMaster, "TeamID", "TeamName", m_PlayerInfoMaster.TeamID);
            ViewBag.PlayerTypeID = new SelectList(db.M_PlayerTypeMaster, "PlayerTypeID", "PlayerType", m_PlayerInfoMaster.PlayerTypeID);
            return View(m_PlayerInfoMaster);
        }

        // GET: M_PlayerInfoMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PlayerInfoMaster m_PlayerInfoMaster = await db.M_PlayerInfoMaster.FindAsync(id);
            if (m_PlayerInfoMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_PlayerInfoMaster);
        }

        // POST: M_PlayerInfoMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_PlayerInfoMaster m_PlayerInfoMaster = await db.M_PlayerInfoMaster.FindAsync(id);
            db.M_PlayerInfoMaster.Remove(m_PlayerInfoMaster);
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
