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
    public class APARTMENTsController : Controller
    {
        private DBmodel2Entities1 db = new DBmodel2Entities1();

        // GET: APARTMENTs
        public ActionResult Index()
        {
            var aPARTMENTS = db.APARTMENTS.Include(a => a.DEVELOPER);
            return View(aPARTMENTS.ToList());
        }

        // GET: APARTMENTs/Details/5
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

        // GET: APARTMENTs/Create
        public ActionResult Create()
        {
            var list = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
            ViewBag.list = list;
            var list1 = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };
            ViewBag.list1 = list1;
            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName");
            return View();
        }

        // POST: APARTMENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( APARTMENT aPARTMENT)
        {
            string filename = Path.GetFileNameWithoutExtension(aPARTMENT.ImageFile.FileName);
            string extension = Path.GetExtension(aPARTMENT.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            aPARTMENT.Picture= "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            aPARTMENT.ImageFile.SaveAs(filename);

            

                if (ModelState.IsValid)
                {

                    db.APARTMENTS.Add(aPARTMENT);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            ViewBag.DeveloperId = new SelectList(db.DEVELOPERS, "DeveloperId", "DeveloperName", aPARTMENT.DeveloperId);

            //ModelState.Clear();
            return View(aPARTMENT);
        }

        // GET: APARTMENTs/Edit/5
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

        // POST: APARTMENTs/Edit/5
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

        // GET: APARTMENTs/Delete/5
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

        // POST: APARTMENTs/Delete/5
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
        }
    }
}
