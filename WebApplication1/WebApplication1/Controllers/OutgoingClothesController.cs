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
    public class OutgoingClothesController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: OutgoingClothes
        public ActionResult Index()
        {
            return View(db.OutgoingClothes.ToList());
        }

        // GET: OutgoingClothes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingClothes outgoingClothes = db.OutgoingClothes.Find(id);
            if (outgoingClothes == null)
            {
                return HttpNotFound();
            }
            return View(outgoingClothes);
        }

        // GET: OutgoingClothes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OutgoingClothes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size")] OutgoingClothes outgoingClothes)
        {
            if (ModelState.IsValid)
            {
                db.OutgoingClothes.Add(outgoingClothes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(outgoingClothes);
        }

        // GET: OutgoingClothes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingClothes outgoingClothes = db.OutgoingClothes.Find(id);
            if (outgoingClothes == null)
            {
                return HttpNotFound();
            }
            return View(outgoingClothes);
        }

        // POST: OutgoingClothes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size")] OutgoingClothes outgoingClothes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outgoingClothes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(outgoingClothes);
        }

        // GET: OutgoingClothes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingClothes outgoingClothes = db.OutgoingClothes.Find(id);
            if (outgoingClothes == null)
            {
                return HttpNotFound();
            }
            return View(outgoingClothes);
        }

        // POST: OutgoingClothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutgoingClothes outgoingClothes = db.OutgoingClothes.Find(id);
            db.OutgoingClothes.Remove(outgoingClothes);
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
