using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC.Models;

namespace ASP.NET_MVC.Controllers
{
    public class DanhSachPhimsController : Controller
    {
        private PrjDatabaseEntities db = new PrjDatabaseEntities();
        private string _filePath { get; set; }
        
        // GET: DanhSachPhims
        public ActionResult Index()
        {
            return View(db.DanhSachPhims.ToList());
        }

        // GET: DanhSachPhims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachPhim danhSachPhim = db.DanhSachPhims.Find(id);
            if (danhSachPhim == null)
            {
                return HttpNotFound();
            }
            return View(danhSachPhim);
        }

        // GET: DanhSachPhims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhSachPhims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhimId,TenPhim,DaoDien,ThoiLuong,XuatXu,NoiDung,FilePath")] DanhSachPhim danhSachPhim, HttpPostedFileBase FilePath)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (FilePath != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/IMG"), Path.GetFileName(FilePath.FileName));
                        FilePath.SaveAs(path);

                        danhSachPhim.FilePath = FilePath.FileName;
                        db.DanhSachPhims.Add(danhSachPhim);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(danhSachPhim);
                    //ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }

            }
            return View();
            //try
            //{
            //    if (file.ContentLength > 0)
            //    {
            //        string fileName = Path.GetFileName(file.FileName);
            //        List<string> validExtensions = new List<string> { "png", "jpg", "jpeg" };
            //        if (validExtensions.Contains(Path.GetExtension(fileName)))
            //        {
            //            string path = Path.Combine("~/IMG", fileName);
            //            file.SaveAs(path);
            //            _filePath = path;
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //}
            //return View();
            //if (ModelState.IsValid)
            //{
            //    if (!string.IsNullOrEmpty(_filePath))
            //        danhSachPhim.FilePath = _filePath;
            //    db.DanhSachPhims.Add(danhSachPhim);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(danhSachPhim);
        }

        
        // GET: DanhSachPhims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachPhim danhSachPhim = db.DanhSachPhims.Find(id);
            if (danhSachPhim == null)
            {
                return HttpNotFound();
            }
            return View(danhSachPhim);
        }

        // POST: DanhSachPhims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhimId,TenPhim,DaoDien,ThoiLuong,XuatXu,NoiDung,Image")] DanhSachPhim danhSachPhim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhSachPhim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhSachPhim);
        }

        // GET: DanhSachPhims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachPhim danhSachPhim = db.DanhSachPhims.Find(id);
            if (danhSachPhim == null)
            {
                return HttpNotFound();
            }
            return View(danhSachPhim);
        }

        // POST: DanhSachPhims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhSachPhim danhSachPhim = db.DanhSachPhims.Find(id);
            db.DanhSachPhims.Remove(danhSachPhim);
            db.SaveChanges();
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
