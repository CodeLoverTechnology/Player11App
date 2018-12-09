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
using P11WebAPI.App_Code;
using System.Drawing;
using System.IO;

namespace P11WebAPI.Controllers
{
    public class M_PlayerTypeMasterController : Controller
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: M_PlayerTypeMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_PlayerTypeMaster.ToListAsync());
        }

        // GET: M_PlayerTypeMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PlayerTypeMaster m_PlayerTypeMaster = await db.M_PlayerTypeMaster.FindAsync(id);
            if (m_PlayerTypeMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_PlayerTypeMaster);
        }

        // GET: M_PlayerTypeMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_PlayerTypeMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PlayerTypeID,PlayerType,Description,PlayerTypeIcons")] M_PlayerTypeMaster m_PlayerTypeMaster)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["PlayerTypeIcons"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.P11Resources.UploadedImages);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        string FullPathWithFileName = FolderPath + "\\" + Request.Files["PlayerTypeIcons"].FileName;
                        string FolderPathForImage = Request.Files["PlayerTypeIcons"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;

                        Request.Files["PlayerTypeIcons"].SaveAs(FullPathWithFileName);
                        using (Image image = Image.FromFile(FullPathWithFileName))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                string base64String = Convert.ToBase64String(imageBytes);
                                m_PlayerTypeMaster.PlayerTypeIcons = base64String;
                                CommonFunction.IsFolderExist(FullPathWithFileName);
                            }
                        }
                    }
                }
                m_PlayerTypeMaster.CreatedBy = "System";
                m_PlayerTypeMaster.CreatedDate = DateTime.Now;
                m_PlayerTypeMaster.ModifiedBy = "System";
                m_PlayerTypeMaster.ModifiedDate = DateTime.Now;
                m_PlayerTypeMaster.Active = true;

                db.M_PlayerTypeMaster.Add(m_PlayerTypeMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_PlayerTypeMaster);
        }

        // GET: M_PlayerTypeMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PlayerTypeMaster m_PlayerTypeMaster = await db.M_PlayerTypeMaster.FindAsync(id);
            if (m_PlayerTypeMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_PlayerTypeMaster);
        }

        // POST: M_PlayerTypeMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PlayerTypeID,PlayerType,Description,PlayerTypeIcons,CreatedBy,CreatedDate,Active")] M_PlayerTypeMaster m_PlayerTypeMaster)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["PlayerTypeIcons"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.P11Resources.UploadedImages);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        string FullPathWithFileName = FolderPath + "\\" + Request.Files["PlayerTypeIcons"].FileName;
                        string FolderPathForImage = Request.Files["PlayerTypeIcons"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;

                        Request.Files["PlayerTypeIcons"].SaveAs(FullPathWithFileName);
                        using (Image image = Image.FromFile(FullPathWithFileName))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                string base64String = Convert.ToBase64String(imageBytes);
                                m_PlayerTypeMaster.PlayerTypeIcons = base64String;
                                CommonFunction.IsFolderExist(FullPathWithFileName);
                            }
                        }
                    }
                    m_PlayerTypeMaster.ModifiedBy = "System";
                    m_PlayerTypeMaster.ModifiedDate = DateTime.Now;
                    m_PlayerTypeMaster.Active = true;
                }
                db.Entry(m_PlayerTypeMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_PlayerTypeMaster);
        }

        // GET: M_PlayerTypeMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PlayerTypeMaster m_PlayerTypeMaster = await db.M_PlayerTypeMaster.FindAsync(id);
            if (m_PlayerTypeMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_PlayerTypeMaster);
        }

        // POST: M_PlayerTypeMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_PlayerTypeMaster m_PlayerTypeMaster = await db.M_PlayerTypeMaster.FindAsync(id);
            db.M_PlayerTypeMaster.Remove(m_PlayerTypeMaster);
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
