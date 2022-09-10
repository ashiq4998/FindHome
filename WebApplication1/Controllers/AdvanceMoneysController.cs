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
    public class AdvanceMoneysController : Controller
    {
        private DBmodel2Entities1 db = new DBmodel2Entities1();

        // GET: AdvanceMoneys
        public ActionResult Index()
        {
            var advanceMoneys = db.AdvanceMoneys.Include(a => a.DEVELOPER).Include(a => a.User);
            return View(advanceMoneys.ToList());
        }

        // GET: AdvanceMoneys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceMoney advanceMoney = db.AdvanceMoneys.Find(id);
            if (advanceMoney == null)
            {
                return HttpNotFound();
            }
            return View(advanceMoney);
        }

        // GET: AdvanceMoneys/Create
        public ActionResult Create()
        {
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: AdvanceMoneys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayId,DeveloperId,UserID,PaymentDate")] AdvanceMoney advanceMoney)
        {
            if (ModelState.IsValid)
            {
                db.AdvanceMoneys.Add(advanceMoney);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", advanceMoney.DeveloperId);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", advanceMoney.UserID);
            return View(advanceMoney);
        }

        // GET: AdvanceMoneys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceMoney advanceMoney = db.AdvanceMoneys.Find(id);
            if (advanceMoney == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", advanceMoney.DeveloperId);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", advanceMoney.UserID);
            return View(advanceMoney);
        }

        // POST: AdvanceMoneys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayId,DeveloperId,UserID,PaymentDate")] AdvanceMoney advanceMoney)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advanceMoney).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", advanceMoney.DeveloperId);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", advanceMoney.UserID);
            return View(advanceMoney);
        }

        // GET: AdvanceMoneys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceMoney advanceMoney = db.AdvanceMoneys.Find(id);
            if (advanceMoney == null)
            {
                return HttpNotFound();
            }
            return View(advanceMoney);
        }

        // POST: AdvanceMoneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvanceMoney advanceMoney = db.AdvanceMoneys.Find(id);
            db.AdvanceMoneys.Remove(advanceMoney);
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
