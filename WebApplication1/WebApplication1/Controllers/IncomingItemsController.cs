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
    public class IncomingItemsController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        public ActionResult Index(string searchString)
        {
            var Items = from s in db.IncomingItems
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                //for multi search
                Items = Items.Where(s => s.ItemType.Contains(searchString) ||
                s.ItemName.Contains(searchString) || s.Status.Contains(searchString));

            }
            return View(Items.ToList());
        }


        // GET: IncomingItems
        //public ActionResult Index()
        //{
        //    return View(db.IncomingItems.ToList());
        //}

        // GET: IncomingItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingItems incomingItems = db.IncomingItems.Find(id);
            if (incomingItems == null)
            {
                return HttpNotFound();
            }
            return View(incomingItems);
        }

        // GET: IncomingItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncomingItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ItemType,ItemName,ItemDescription,ItemAmount,Status")] IncomingItems incomingItems)
        {
            incomingItems.Status = "Not Arrived";
            if (ModelState.IsValid)
            {
                db.IncomingItems.Add(incomingItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incomingItems);
        }

        // GET: IncomingItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingItems incomingItems = db.IncomingItems.Find(id);
            if (incomingItems == null)
            {
                return HttpNotFound();
            }
            return View(incomingItems);
        }

        // POST: IncomingItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemType,ItemName,ItemDescription,ItemAmount,Status")] IncomingItems incomingItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomingItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomingItems);
        }


        public ActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingItems incomingItems = db.IncomingItems.Find(id);
            if (incomingItems == null)
            {
                return HttpNotFound();
            }
            return View(incomingItems);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm([Bind(Include = "ItemId,ItemType,ItemName,ItemDescription,ItemAmount,Status")] IncomingItems incomingItems
            , [Bind(Include = "ItemId,ItemType,ItemName,ItemDescription,ItemAmount")]Items items)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(incomingItems).State = EntityState.Modified;
                db.Items.Add(items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomingItems);
        }


        public ActionResult Reject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingItems incomingItems = db.IncomingItems.Find(id);
            if (incomingItems == null)
            {
                return HttpNotFound();
            }
            return View(incomingItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject([Bind(Include = "ItemId,ItemType,ItemName,ItemDescription,ItemAmount,Status")] IncomingItems incomingItems)

        {
            if (ModelState.IsValid)
            {
                db.Entry(incomingItems).State = EntityState.Modified;
                incomingItems.Status = "Rejected";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomingItems);
        }






        // GET: IncomingItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingItems incomingItems = db.IncomingItems.Find(id);
            if (incomingItems == null)
            {
                return HttpNotFound();
            }
            return View(incomingItems);
        }

        // POST: IncomingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomingItems incomingItems = db.IncomingItems.Find(id);
            db.IncomingItems.Remove(incomingItems);
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
