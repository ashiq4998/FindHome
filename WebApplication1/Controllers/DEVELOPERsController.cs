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
    public class DEVELOPERsController : Controller
    {
        private DBmodel2Entities1 db = new DBmodel2Entities1();

        // GET: DEVELOPERs
        public ActionResult Index()
        {
            return View(db.DEVELOPERS.ToList());
        }

        // GET: DEVELOPERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEVELOPER dEVELOPER = db.DEVELOPERS.Find(id);
            if (dEVELOPER == null)
            {
                return HttpNotFound();
            }
            return View(dEVELOPER);
        }

        // GET: DEVELOPERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEVELOPERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeveloperId,DeveloperName,DeveloperEmail,DeveloperPhone,DeveloperPass,License")] DEVELOPER dEVELOPER)
        {
            if (ModelState.IsValid)
            {
                db.DEVELOPERS.Add(dEVELOPER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEVELOPER);
        }

        // GET: DEVELOPERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEVELOPER dEVELOPER = db.DEVELOPERS.Find(id);
            if (dEVELOPER == null)
            {
                return HttpNotFound();
            }
            return View(dEVELOPER);
        }

        // POST: DEVELOPERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeveloperId,DeveloperName,DeveloperEmail,DeveloperPhone,DeveloperPass,License")] DEVELOPER dEVELOPER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEVELOPER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEVELOPER);
        }

        // GET: DEVELOPERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEVELOPER dEVELOPER = db.DEVELOPERS.Find(id);
            if (dEVELOPER == null)
            {
                return HttpNotFound();
            }
            return View(dEVELOPER);
        }

        // POST: DEVELOPERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEVELOPER dEVELOPER = db.DEVELOPERS.Find(id);
            db.DEVELOPERS.Remove(dEVELOPER);
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
