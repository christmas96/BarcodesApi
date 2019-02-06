using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BarcodesController : Controller
    {
        private BarcodesEntities db = new BarcodesEntities();

        // GET: Barcodes
        public ActionResult Index()
        {
            return View(db.Barcodes.ToList());
        }

        // GET: Barcodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcode barcode = db.Barcodes.Find(id);
            if (barcode == null)
            {
                return HttpNotFound();
            }
            return View(barcode);
        }

        // GET: Barcodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barcodes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,Code")] Barcode barcode)
        {
            if (ModelState.IsValid)
            {
                db.Barcodes.Add(barcode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barcode);
        }

        // GET: Barcodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcode barcode = db.Barcodes.Find(id);
            if (barcode == null)
            {
                return HttpNotFound();
            }
            return View(barcode);
        }

        // POST: Barcodes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Code")] Barcode barcode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barcode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barcode);
        }

        // GET: Barcodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcode barcode = db.Barcodes.Find(id);
            if (barcode == null)
            {
                return HttpNotFound();
            }
            return View(barcode);
        }

        // POST: Barcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barcode barcode = db.Barcodes.Find(id);
            db.Barcodes.Remove(barcode);
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
