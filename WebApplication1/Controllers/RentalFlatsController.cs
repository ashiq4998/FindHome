using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RentalFlatsController : Controller
    {
        private DBmodel2Entities1 db = new DBmodel2Entities1();

        // GET: RentalFlats
        public ActionResult Index()
        {
            var rentalFlats = db.RentalFlats.Include(r => r.DEVELOPER);
            return View(rentalFlats.ToList());
        }

        // GET: RentalFlats/Details/5
        public ActionResult Details(int? id)
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

        // GET: RentalFlats/Create
        public ActionResult Create()
        {
            var list = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
            ViewBag.list = list;
            var list1 = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
            ViewBag.list1 = list1;
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName");
            return View();
        }

        // POST: RentalFlats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalFlat rentalFlat)
        {
            string filename = Path.GetFileNameWithoutExtension(rentalFlat.ImageFile.FileName);
            string extension = Path.GetExtension(rentalFlat.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            rentalFlat.Picture = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            rentalFlat.ImageFile.SaveAs(filename);


            if (ModelState.IsValid)
            {
                db.RentalFlats.Add(rentalFlat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", rentalFlat.DeveloperId);
            return View(rentalFlat);
        }

        // GET: RentalFlats/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", rentalFlat.DeveloperId);
            return View(rentalFlat);
        }

        // POST: RentalFlats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalsId,DeveloperId,Address,Size,Beds,Baths,Price,Picture")] RentalFlat rentalFlat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalFlat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", rentalFlat.DeveloperId);
            return View(rentalFlat);
        }

        // GET: RentalFlats/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: RentalFlats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalFlat rentalFlat = db.RentalFlats.Find(id);
            db.RentalFlats.Remove(rentalFlat);
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
