using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autorennstall.Models;

namespace Autorennstall.Controllers
{
    public class RepairsController : BaseAuthController
    {
        public ActionResult Index()
        {
            var repairs = UnitOfWork.Repairs.All();
            return View(repairs.ToList());
        }
        public ActionResult AddSpareparts(int? id)
        {
            ViewBag.RepairId = id;
            return View(UnitOfWork.RepairSpareparts.FindByRepairID(id));
        }
        // GET: Repairs/Create
        public ActionResult Create()
        {
            ViewBag.DriverID = new SelectList(UnitOfWork.Drivers.All(), "DriverID", "FullName");
            ViewBag.RepairTypeID = new SelectList(UnitOfWork.RepairTypes.All(), "RepairTypeID", "Name");
            ViewBag.Date = DateTime.Now;
            return View();
        }

        // POST: Repairs/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepairID,Date,Notes,DriverID,RepairTypeID")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Repairs.Create(repair);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverID = new SelectList(UnitOfWork.Drivers.All(), "DriverID", "FullName", repair.DriverID);
            ViewBag.RepairTypeID = new SelectList(UnitOfWork.RepairTypes.All(), "RepairTypeID", "Name", repair.RepairTypeID);
            return View(repair);
        }

        // GET: Repairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = UnitOfWork.Repairs.FindByID(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverID = new SelectList(UnitOfWork.Drivers.All(), "DriverID", "FullName", repair.DriverID);
            ViewBag.RepairTypeID = new SelectList(UnitOfWork.RepairTypes.All(), "RepairTypeID", "Name", repair.RepairTypeID);
            return View(repair);
        }

        // POST: Repairs/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepairID,Date,Notes,DriverID,RepairTypeID")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Repairs.Update(repair);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverID = new SelectList(UnitOfWork.Drivers.All(), "DriverID", "FullName", repair.DriverID);
            ViewBag.RepairTypeID = new SelectList(UnitOfWork.RepairTypes.All(), "RepairTypeID", "Name", repair.RepairTypeID);
            return View(repair);
        }

        // GET: Repairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = UnitOfWork.Repairs.FindByID(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repair repair = UnitOfWork.Repairs.FindByID(id);
            UnitOfWork.Repairs.Remove(repair);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
