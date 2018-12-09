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
    public class T_LiveMatchUpdateInfoController : Controller
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: T_LiveMatchUpdateInfo
        public async Task<ActionResult> Index()
        {
            var t_LiveMatchUpdateInfo = db.T_LiveMatchUpdateInfo.Include(t => t.M_MatchInfoMaters).Include(t => t.M_MatchTopicMaster);
            return View(await t_LiveMatchUpdateInfo.ToListAsync());
        }

        // GET: T_LiveMatchUpdateInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_LiveMatchUpdateInfo t_LiveMatchUpdateInfo = await db.T_LiveMatchUpdateInfo.FindAsync(id);
            if (t_LiveMatchUpdateInfo == null)
            {
                return HttpNotFound();
            }
            return View(t_LiveMatchUpdateInfo);
        }

        // GET: T_LiveMatchUpdateInfo/Create
        public ActionResult Create()
        {
            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "Team1");
            ViewBag.MatchTopicID = new SelectList(db.M_MatchTopicMaster, "MatchTopicID", "Topic");
            return View();
        }

        // POST: T_LiveMatchUpdateInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MatchUpdateID,MatchID,MatchTopicID,Description,Images")] T_LiveMatchUpdateInfo t_LiveMatchUpdateInfo)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["Images"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.P11Resources.UploadedImages);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        string FullPathWithFileName = FolderPath + "\\" + Request.Files["Images"].FileName;
                        string FolderPathForImage = Request.Files["Images"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;

                        Request.Files["Images"].SaveAs(FullPathWithFileName);
                        using (Image image = Image.FromFile(FullPathWithFileName))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                string base64String = Convert.ToBase64String(imageBytes);
                                t_LiveMatchUpdateInfo.Images = base64String;
                                CommonFunction.IsFolderExist(FullPathWithFileName);
                            }
                        }
                    }
                }

                t_LiveMatchUpdateInfo.CreatedBy = "System";
                t_LiveMatchUpdateInfo.CreatedDate = DateTime.Now;
                t_LiveMatchUpdateInfo.ModifiedBy = "System";
                t_LiveMatchUpdateInfo.ModifiedDate = DateTime.Now;
                t_LiveMatchUpdateInfo.Active = true;
                db.T_LiveMatchUpdateInfo.Add(t_LiveMatchUpdateInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_LiveMatchUpdateInfo.MatchID);
            ViewBag.MatchTopicID = new SelectList(db.M_MatchTopicMaster, "MatchTopicID", "Topic", t_LiveMatchUpdateInfo.MatchTopicID);
            return View(t_LiveMatchUpdateInfo);
        }

        // GET: T_LiveMatchUpdateInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_LiveMatchUpdateInfo t_LiveMatchUpdateInfo = await db.T_LiveMatchUpdateInfo.FindAsync(id);
            if (t_LiveMatchUpdateInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_LiveMatchUpdateInfo.MatchID);
            ViewBag.MatchTopicID = new SelectList(db.M_MatchTopicMaster, "MatchTopicID", "Topic", t_LiveMatchUpdateInfo.MatchTopicID);
            return View(t_LiveMatchUpdateInfo);
        }

        // POST: T_LiveMatchUpdateInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MatchUpdateID,MatchID,MatchTopicID,Description,Images,CreatedBy,CreatedDate,Active")] T_LiveMatchUpdateInfo t_LiveMatchUpdateInfo)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["Images"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.P11Resources.UploadedImages);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        string FullPathWithFileName = FolderPath + "\\" + Request.Files["Images"].FileName;
                        string FolderPathForImage = Request.Files["Images"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;

                        Request.Files["Images"].SaveAs(FullPathWithFileName);
                        using (Image image = Image.FromFile(FullPathWithFileName))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                string base64String = Convert.ToBase64String(imageBytes);
                                t_LiveMatchUpdateInfo.Images = base64String;
                                CommonFunction.IsFolderExist(FullPathWithFileName);
                            }
                        }
                    }
                }

                t_LiveMatchUpdateInfo.ModifiedBy = "System";
                t_LiveMatchUpdateInfo.ModifiedDate = DateTime.Now;
                db.Entry(t_LiveMatchUpdateInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MatchID = new SelectList(db.M_MatchInfoMaters, "MatchID", "MatchLocation", t_LiveMatchUpdateInfo.MatchID);
            ViewBag.MatchTopicID = new SelectList(db.M_MatchTopicMaster, "MatchTopicID", "Topic", t_LiveMatchUpdateInfo.MatchTopicID);
            return View(t_LiveMatchUpdateInfo);
        }

        // GET: T_LiveMatchUpdateInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_LiveMatchUpdateInfo t_LiveMatchUpdateInfo = await db.T_LiveMatchUpdateInfo.FindAsync(id);
            if (t_LiveMatchUpdateInfo == null)
            {
                return HttpNotFound();
            }
            return View(t_LiveMatchUpdateInfo);
        }

        // POST: T_LiveMatchUpdateInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_LiveMatchUpdateInfo t_LiveMatchUpdateInfo = await db.T_LiveMatchUpdateInfo.FindAsync(id);
            db.T_LiveMatchUpdateInfo.Remove(t_LiveMatchUpdateInfo);
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
