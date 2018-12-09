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
using System.Drawing;
using System.IO;
using P11WebAPI.App_Code;

namespace P11WebAPI.Controllers
{
    public class M_TeamInfoMasterController : Controller
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: M_TeamInfoMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_TeamInfoMaster.ToListAsync());
        }

        // GET: M_TeamInfoMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_TeamInfoMaster m_TeamInfoMaster = await db.M_TeamInfoMaster.FindAsync(id);
            if (m_TeamInfoMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_TeamInfoMaster);
        }

        // GET: M_TeamInfoMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_TeamInfoMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TeamID,TeamType,TeamCode,TeamName,TeamLocation,Country,TeamLogo,Description")] M_TeamInfoMaster m_TeamInfoMaster)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["TeamLogo"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.P11Resources.UploadedImages);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                     string FullPathWithFileName = FolderPath + "\\" + Request.Files["TeamLogo"].FileName;
                     string FolderPathForImage = Request.Files["TeamLogo"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    
                        Request.Files["TeamLogo"].SaveAs(FullPathWithFileName);
                        using (Image image = Image.FromFile(FullPathWithFileName))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                string base64String = Convert.ToBase64String(imageBytes);
                                m_TeamInfoMaster.TeamLogo = base64String;
                                CommonFunction.IsFolderExist(FullPathWithFileName);
                            }
                        }
                    }

                    //string FolderPath = Server.MapPath(Resources.D2cResource.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    //string FullPathWithFileName = FolderPath + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    //string FolderPathForImage = Request.Files["StdProfilePicPath"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    //if (CommonFunction.IsFolderExist(FolderPath))
                    //{
                    //    Request.Files["StdProfilePicPath"].SaveAs(FullPathWithFileName);
                    //    StudentImagePath = FolderPathForImage;
                    //}
                }
                m_TeamInfoMaster.CreatedBy = "System";
                m_TeamInfoMaster.CreatedDate = DateTime.Now;
                m_TeamInfoMaster.ModifiedBy = "System";
                m_TeamInfoMaster.ModifiedDate = DateTime.Now;
                m_TeamInfoMaster.Active = true;
                db.M_TeamInfoMaster.Add(m_TeamInfoMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_TeamInfoMaster);
        }

        // GET: M_TeamInfoMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_TeamInfoMaster m_TeamInfoMaster = await db.M_TeamInfoMaster.FindAsync(id);
            if (m_TeamInfoMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_TeamInfoMaster);
        }

        // POST: M_TeamInfoMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TeamID,TeamType,TeamCode,TeamName,TeamLocation,Country,TeamLogo,Description,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_TeamInfoMaster m_TeamInfoMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_TeamInfoMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_TeamInfoMaster);
        }

        // GET: M_TeamInfoMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_TeamInfoMaster m_TeamInfoMaster = await db.M_TeamInfoMaster.FindAsync(id);
            if (m_TeamInfoMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_TeamInfoMaster);
        }

        // POST: M_TeamInfoMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_TeamInfoMaster m_TeamInfoMaster = await db.M_TeamInfoMaster.FindAsync(id);
            db.M_TeamInfoMaster.Remove(m_TeamInfoMaster);
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
