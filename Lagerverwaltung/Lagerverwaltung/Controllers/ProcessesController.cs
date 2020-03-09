using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lagerverwaltung.Models;

namespace Lagerverwaltung.Controllers
{
    public class ProcessesController : BaseAuthController
    {
        /// <summary>
        /// Overview of all Proccess
        /// </summary>
        /// <returns>
        /// View with a List of Process
        /// </returns>
        public ActionResult Index()
        {
            return View(UnitOfWork.Processes.All());
        }

        /// <summary>
        /// Create Transaction
        /// </summary>
        /// <returns>
        /// Return View for Creating new Transaction
        /// </returns>
        public ActionResult Create()
        {
            ViewBag.TransactionId = new SelectList(UnitOfWork.Transactions.All(), "TransactionId", "Name");
            return View();
        }

        public ActionResult AddArticles(int? id)
        {
            ViewBag.ProcessId = id;

            return View(UnitOfWork.ProcessArticles.FindByProcessId(id));
        }

        /// <summary>
        /// Handles Create Post Request
        /// </summary>
        /// <param name="process">Process Model</param>
        /// <returns>
        /// 
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProcessId,Name,TransactionId")] Process process)
        {
            if (ModelState.IsValid)
            {
                var createdProcess = UnitOfWork.Processes.Create(process);
                UnitOfWork.SaveChanges();

                return RedirectToAction("AddArticles", new { id = createdProcess.ProcessId });
            }

            ViewBag.TransactionId = new SelectList(UnitOfWork.Transactions.All(), "TransactionId", "Name", process.TransactionId);
            return View(process);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = UnitOfWork.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransactionId = new SelectList(UnitOfWork.Transactions.All(), "TransactionId", "Name", process.TransactionId);
            return View(process);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProcessId,Name,TransactionId")] Process process)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Processes.Update(process);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransactionId = new SelectList(UnitOfWork.Transactions.All(), "TransactionId", "Name", process.TransactionId);
            return View(process);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Process process = UnitOfWork.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Process process = UnitOfWork.Processes.Find(id);
            UnitOfWork.Processes.Remove(process);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
