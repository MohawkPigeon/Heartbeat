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
    public class TransactionInfoDtoesController : Controller
    {
        private HeartbeatContext db = new HeartbeatContext();

        // GET: TransactionInfoDtoes
        public ActionResult Index()
        {
            return View(db.TransactionInfoDtoes.ToList());
        }

        // GET: TransactionInfoDtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionInfoDto transactionInfoDto = db.TransactionInfoDtoes.Find(id);
            if (transactionInfoDto == null)
            {
                return HttpNotFound();
            }
            return View(transactionInfoDto);
        }

        // GET: TransactionInfoDtoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionInfoDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionInfoDtoID,vat,feeType,feeAmount,cashBack,recievedAmount,amount")] TransactionInfoDto transactionInfoDto)
        {
            if (ModelState.IsValid)
            {
                db.TransactionInfoDtoes.Add(transactionInfoDto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transactionInfoDto);
        }

        // GET: TransactionInfoDtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionInfoDto transactionInfoDto = db.TransactionInfoDtoes.Find(id);
            if (transactionInfoDto == null)
            {
                return HttpNotFound();
            }
            return View(transactionInfoDto);
        }

        // POST: TransactionInfoDtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionInfoDtoID,vat,feeType,feeAmount,cashBack,recievedAmount,amount")] TransactionInfoDto transactionInfoDto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionInfoDto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactionInfoDto);
        }

        // GET: TransactionInfoDtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionInfoDto transactionInfoDto = db.TransactionInfoDtoes.Find(id);
            if (transactionInfoDto == null)
            {
                return HttpNotFound();
            }
            return View(transactionInfoDto);
        }

        // POST: TransactionInfoDtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionInfoDto transactionInfoDto = db.TransactionInfoDtoes.Find(id);
            db.TransactionInfoDtoes.Remove(transactionInfoDto);
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
