using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC.Models;

namespace ASP.NET_MVC.Controllers
{
    public class DanhSachPhongChieuxController : Controller
    {
        private ProjectDatabaseEntitiesFinal db = new ProjectDatabaseEntitiesFinal();

        // GET: DanhSachPhongChieux
        public ActionResult Index()
        {
            return View(db.DanhSachPhongChieux.ToList());
        }

        // GET: DanhSachPhongChieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachPhongChieu danhSachPhongChieu = db.DanhSachPhongChieux.Find(id);
            if (danhSachPhongChieu == null)
            {
                return HttpNotFound();
            }
            return View(danhSachPhongChieu);
        }

        // GET: DanhSachPhongChieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhSachPhongChieux/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhongChieuId,TenPhongChieu,SoLuongGhe")] DanhSachPhongChieu danhSachPhongChieu)
        {
            if (ModelState.IsValid)
            {
                db.DanhSachPhongChieux.Add(danhSachPhongChieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhSachPhongChieu);
        }

        // GET: DanhSachPhongChieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachPhongChieu danhSachPhongChieu = db.DanhSachPhongChieux.Find(id);
            if (danhSachPhongChieu == null)
            {
                return HttpNotFound();
            }
            return View(danhSachPhongChieu);
        }

        // POST: DanhSachPhongChieux/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhongChieuId,TenPhongChieu,SoLuongGhe")] DanhSachPhongChieu danhSachPhongChieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhSachPhongChieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhSachPhongChieu);
        }

        // GET: DanhSachPhongChieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachPhongChieu danhSachPhongChieu = db.DanhSachPhongChieux.Find(id);
            if (danhSachPhongChieu == null)
            {
                return HttpNotFound();
            }
            return View(danhSachPhongChieu);
        }

        // POST: DanhSachPhongChieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhSachPhongChieu danhSachPhongChieu = db.DanhSachPhongChieux.Find(id);
            db.DanhSachPhongChieux.Remove(danhSachPhongChieu);
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
