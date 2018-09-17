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
    public class DanhSachPhimsController : Controller
    {
        private ProjectDatabaseEntitiesFinal db = new ProjectDatabaseEntitiesFinal();

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
        public ActionResult Create([Bind(Include = "PhimId,TenPhim,DaoDien,ThoiLuong,XuatXu,NoiDung,Image")] DanhSachPhim danhSachPhim)
        {
            if (ModelState.IsValid)
            {
                db.DanhSachPhims.Add(danhSachPhim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhSachPhim);
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
