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
    public class LichChieuPhimsController : Controller
    {
        private PrjDatabaseEntities db = new PrjDatabaseEntities();

        // GET: LichChieuPhims
        public ActionResult Index()
        {
            var lichChieuPhims = db.LichChieuPhims.Include(l => l.DanhSachPhim).Include(l => l.DanhSachPhongChieu);
            return View(lichChieuPhims.ToList());
        }

        // GET: LichChieuPhims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieuPhim lichChieuPhim = db.LichChieuPhims.Find(id);
            if (lichChieuPhim == null)
            {
                return HttpNotFound();
            }
            return View(lichChieuPhim);
        }

        // GET: LichChieuPhims/Create
        public ActionResult Create()
        {
            ViewBag.PhimId = new SelectList(db.DanhSachPhims, "PhimId", "TenPhim");
            ViewBag.PhongChieuId = new SelectList(db.DanhSachPhongChieux, "PhongChieuId", "TenPhongChieu");
            return View();
        }

        // POST: LichChieuPhims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LichChieuId,PhimId,PhongChieuId")] LichChieuPhim lichChieuPhim)
        {
            if (ModelState.IsValid)
            {
                db.LichChieuPhims.Add(lichChieuPhim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhimId = new SelectList(db.DanhSachPhims, "PhimId", "TenPhim", lichChieuPhim.PhimId);
            ViewBag.PhongChieuId = new SelectList(db.DanhSachPhongChieux, "PhongChieuId", "TenPhongChieu", lichChieuPhim.PhongChieuId);
            return View(lichChieuPhim);
        }

        // GET: LichChieuPhims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieuPhim lichChieuPhim = db.LichChieuPhims.Find(id);
            if (lichChieuPhim == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhimId = new SelectList(db.DanhSachPhims, "PhimId", "TenPhim", lichChieuPhim.PhimId);
            ViewBag.PhongChieuId = new SelectList(db.DanhSachPhongChieux, "PhongChieuId", "TenPhongChieu", lichChieuPhim.PhongChieuId);
            return View(lichChieuPhim);
        }

        // POST: LichChieuPhims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LichChieuId,PhimId,PhongChieuId")] LichChieuPhim lichChieuPhim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichChieuPhim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhimId = new SelectList(db.DanhSachPhims, "PhimId", "TenPhim", lichChieuPhim.PhimId);
            ViewBag.PhongChieuId = new SelectList(db.DanhSachPhongChieux, "PhongChieuId", "TenPhongChieu", lichChieuPhim.PhongChieuId);
            return View(lichChieuPhim);
        }

        // GET: LichChieuPhims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieuPhim lichChieuPhim = db.LichChieuPhims.Find(id);
            if (lichChieuPhim == null)
            {
                return HttpNotFound();
            }
            return View(lichChieuPhim);
        }

        // POST: LichChieuPhims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichChieuPhim lichChieuPhim = db.LichChieuPhims.Find(id);
            db.LichChieuPhims.Remove(lichChieuPhim);
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
