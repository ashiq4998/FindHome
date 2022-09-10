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
    public class UsersController : Controller
    {
        private DBmodel2Entities1 db = new DBmodel2Entities1();

        // GET: Users
        public ActionResult Index()
        {
            var aPARTMENTS = db.APARTMENTS.Include(a => a.DEVELOPER);
            return View(aPARTMENTS.ToList());
        }

        public ActionResult RentalIndex()
        {
            var rentalFlat = db.RentalFlats.Include(a => a.DEVELOPER);
            return View(rentalFlat.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APARTMENT aPARTMENT = db.APARTMENTS.Find(id);
            if (aPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(aPARTMENT);
        }

        // GET: Users/Details/1
        public ActionResult RentalDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalFlat rentalFlat = db.RentalFlats.Find(id);
            if (rentalFlat == null)
            {
                return HttpNotFound();
            }
            return View(rentalFlat);
        }

        // GET: Users/Create


        /*public ActionResult Create()
        {
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApartmentId,DeveloperId,Address,Size,Beds,Baths,Price,Picture")] APARTMENT aPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.APARTMENTS.Add(aPARTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", aPARTMENT.DeveloperId);
            return View(aPARTMENT);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APARTMENT aPARTMENT = db.APARTMENTS.Find(id);
            if (aPARTMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", aPARTMENT.DeveloperId);
            return View(aPARTMENT);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApartmentId,DeveloperId,Address,Size,Beds,Baths,Price,Picture")] APARTMENT aPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPARTMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", aPARTMENT.DeveloperId);
            return View(aPARTMENT);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APARTMENT aPARTMENT = db.APARTMENTS.Find(id);
            if (aPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(aPARTMENT);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APARTMENT aPARTMENT = db.APARTMENTS.Find(id);
            db.APARTMENTS.Remove(aPARTMENT);
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
        }*/
    }
}
