using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eventRegistration.Models;

namespace eventRegistration.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Admin/
        public ActionResult Index()
        {
            return View(db.EventRegistrationDBs.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegistrationDB eventregistrationdb = db.EventRegistrationDBs.Find(id);
            if (eventregistrationdb == null)
            {
                return HttpNotFound();
            }
            return View(eventregistrationdb);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,UserName,FName,LName,Email,Password,DateAdded")] EventRegistrationDB eventregistrationdb)
        {
            if (ModelState.IsValid)
            {
                db.EventRegistrationDBs.Add(eventregistrationdb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventregistrationdb);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegistrationDB eventregistrationdb = db.EventRegistrationDBs.Find(id);
            if (eventregistrationdb == null)
            {
                return HttpNotFound();
            }
            return View(eventregistrationdb);
        }

        // POST: /Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,UserName,FName,LName,Email,Password,DateAdded")] EventRegistrationDB eventregistrationdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventregistrationdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventregistrationdb);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventRegistrationDB eventregistrationdb = db.EventRegistrationDBs.Find(id);
            if (eventregistrationdb == null)
            {
                return HttpNotFound();
            }
            return View(eventregistrationdb);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventRegistrationDB eventregistrationdb = db.EventRegistrationDBs.Find(id);
            db.EventRegistrationDBs.Remove(eventregistrationdb);
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
