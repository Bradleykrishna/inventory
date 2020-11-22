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
    public class IncomingClothesController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: IncomingClothes
        public ActionResult Index(string searchString)
        {
            var clothes = from s in db.IncomingClothes
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                //for multi search
                clothes = clothes.Where(s => s.ClothingType.Contains(searchString) ||
                s.Size.Contains(searchString) || s.Status.Contains(searchString));

            }
            return View(clothes.ToList());
        }
       
        // GET: IncomingClothes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingClothes incomingClothes = db.IncomingClothes.Find(id);
            if (incomingClothes == null)
            {
                return HttpNotFound();
            }
            return View(incomingClothes);
        }

        // GET: IncomingClothes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncomingClothes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size,Status")] IncomingClothes incomingClothes)
        {
            if (ModelState.IsValid)
            {
                incomingClothes.Status = "Not Arrived";
                db.IncomingClothes.Add(incomingClothes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incomingClothes);
        }

        // GET: IncomingClothes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingClothes incomingClothes = db.IncomingClothes.Find(id);
            if (incomingClothes == null)
            {
                return HttpNotFound();
            }
            return View(incomingClothes);
        }

        // POST: IncomingClothes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size,Status")] IncomingClothes incomingClothes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomingClothes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomingClothes);
        }


        public ActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingClothes incomingClothes = db.IncomingClothes.Find(id);
            if (incomingClothes == null)
            {
                return HttpNotFound();
            }
            return View(incomingClothes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size,Status")] IncomingClothes incomingClothes,
            [Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size")]Clothes clothes)
        {
            if (ModelState.IsValid)
            {

                var cloth = (from c in db.Clothes
                             where c.ClothingType == incomingClothes.ClothingType && c.Size == incomingClothes.Size
                             select new { c.ClothingAmount, c.ClothingType, c.Size, c.ClothesID }).SingleOrDefault();
                
                if (cloth != null)
                {
                  
                       clothes = db.Clothes.Find(cloth.ClothesID);
                        clothes.ClothingAmount = cloth.ClothingAmount + incomingClothes.ClothingAmount;
                        db.Entry(clothes).State = EntityState.Modified;
                        db.Entry(incomingClothes).State = EntityState.Modified;
                        incomingClothes.Status = "Accepted";
                    
                }
                else
                {
                    db.Entry(incomingClothes).State = EntityState.Modified;
                    incomingClothes.Status = "Accepted";
                    db.Clothes.Add(clothes);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomingClothes);
        }

        public ActionResult Reject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingClothes incomingClothes = db.IncomingClothes.Find(id);
            if (incomingClothes == null)
            {
                return HttpNotFound();
            }
            return View(incomingClothes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject([Bind(Include = "ClothesID,ClothingType,ClothingAmount,Size,Status")] IncomingClothes incomingClothes)
            
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomingClothes).State = EntityState.Modified;
                incomingClothes.Status = "Rejected";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomingClothes);
        }


        // GET: IncomingClothes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingClothes incomingClothes = db.IncomingClothes.Find(id);
            if (incomingClothes == null)
            {
                return HttpNotFound();
            }
            return View(incomingClothes);
        }

        // POST: IncomingClothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomingClothes incomingClothes = db.IncomingClothes.Find(id);
            db.IncomingClothes.Remove(incomingClothes);
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
