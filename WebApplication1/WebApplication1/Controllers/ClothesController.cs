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
    public class ClothesController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: Clothes
        public ActionResult Index(string searchString)
        {
            var clothes = from s in db.Clothes
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                //for multi search
                clothes = clothes.Where(s => s.ClothingType.Contains(searchString) ||
                s.Size.Contains(searchString));

            }
            return View(clothes.ToList());
        }

        // GET: Clothes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        // GET: Clothes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                db.Clothes.Add(clothes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clothes);
        }

        // GET: Clothes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clothes);
        }


        public ActionResult OutGoing(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OutGoing([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size")] Clothes clothes,OutgoingClothes outclothes)
        {
            var query = (from c in db.Clothes
                         where c.ClothesID == clothes.ClothesID
                         select new { c.ClothingAmount }).Single();
            double check = query.ClothingAmount;
            if (ModelState.IsValid)
            {
                
                db.OutgoingClothes.Add(outclothes);
                clothes.ClothingAmount = check - clothes.ClothingAmount;
                db.Entry(clothes).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        
            return View(clothes);
        }

        
        // GET: Clothes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clothes clothes = db.Clothes.Find(id);
            db.Clothes.Remove(clothes);
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
