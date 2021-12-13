using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Heartbeat.Data;
using Heartbeat.Models;

namespace Heartbeat.Controllers
{
    public class KeysController : Controller
    {
        private HeartbeatContext db = new HeartbeatContext();

        // GET: Keys
        public ActionResult Index()
        {
            return View(db.Keys.ToList());
        }

        // GET: Keys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Key key = db.Keys.Find(id);
            if (key == null)
            {
                return HttpNotFound();
            }
            return View(key);
        }

        // GET: Keys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Keys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KeyID,latitude,longitude,name")] Key key)
        {
            if (ModelState.IsValid)
            {
                db.Keys.Add(key);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(key);
        }

        // GET: Keys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Key key = db.Keys.Find(id);
            if (key == null)
            {
                return HttpNotFound();
            }
            return View(key);
        }

        // POST: Keys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KeyID,latitude,longitude,name")] Key key)
        {
            if (ModelState.IsValid)
            {
                db.Entry(key).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(key);
        }

        // GET: Keys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Key key = db.Keys.Find(id);
            if (key == null)
            {
                return HttpNotFound();
            }
            return View(key);
        }

        // POST: Keys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Key key = db.Keys.Find(id);
            db.Keys.Remove(key);
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
