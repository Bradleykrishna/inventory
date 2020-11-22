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
    public class OutgoingItemsController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: OutgoingItems
        public ActionResult Index(string searchString)
        {
            var Items = from s in db.OutgoingItems
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                //for multi search
                Items = Items.Where(s => s.ItemName.Contains(searchString) ||
                s.ItemType.Contains(searchString));

            }
            return View(Items.ToList());
        }
        // GET: OutgoingItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingItems outgoingItems = db.OutgoingItems.Find(id);
            if (outgoingItems == null)
            {
                return HttpNotFound();
            }
            return View(outgoingItems);
        }

        // GET: OutgoingItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OutgoingItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ItemType,ItemName,ItemDescription,ItemAmount")] OutgoingItems outgoingItems)
        {
            if (ModelState.IsValid)
            {
                db.OutgoingItems.Add(outgoingItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(outgoingItems);
        }

        // GET: OutgoingItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingItems outgoingItems = db.OutgoingItems.Find(id);
            if (outgoingItems == null)
            {
                return HttpNotFound();
            }
            return View(outgoingItems);
        }

        // POST: OutgoingItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemType,ItemName,ItemDescription,ItemAmount")] OutgoingItems outgoingItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outgoingItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(outgoingItems);
        }

        public ActionResult InComing(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingItems outgoingItems = db.OutgoingItems.Find(id);
            if (outgoingItems == null)
            {
                return HttpNotFound();
            }
            return View(outgoingItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InComing([Bind(Include = "ItemId,ItemType,ItemName,ItemDescription,ItemAmount")] OutgoingItems outgoingItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outgoingItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(outgoingItems);
        }



        // GET: OutgoingItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutgoingItems outgoingItems = db.OutgoingItems.Find(id);
            if (outgoingItems == null)
            {
                return HttpNotFound();
            }
            return View(outgoingItems);
        }

        // POST: OutgoingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutgoingItems outgoingItems = db.OutgoingItems.Find(id);
            db.OutgoingItems.Remove(outgoingItems);
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
