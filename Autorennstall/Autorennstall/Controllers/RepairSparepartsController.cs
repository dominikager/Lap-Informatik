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
    public class RepairSparepartsController : BaseAuthController
    {

        public ActionResult Create(int? id)
        {
            ViewBag.RepairID = id;
            ViewBag.SparepartID = new SelectList(UnitOfWork.Spareparts.All(), "SparepartID", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepairSparepartID,RepairID,SparepartID")] RepairSparepart repairSparepart, int? id)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.RepairSpareparts.Create(repairSparepart);
                UnitOfWork.SaveChanges();
                return RedirectToAction("AddSpareparts", "Repairs", new {id = repairSparepart.RepairID });
            }

            ViewBag.RepairID = new SelectList(UnitOfWork.Repairs.All(), "RepairID", "Notes", repairSparepart.RepairID);
            ViewBag.SparepartID = new SelectList(UnitOfWork.Spareparts.All(), "SparepartID", "Name", repairSparepart.SparepartID);
            return View(repairSparepart);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairSparepart repairSparepart = UnitOfWork.RepairSpareparts.FindByID(id);
            if (repairSparepart == null)
            {
                return HttpNotFound();
            }
            ViewBag.RepairID = new SelectList(UnitOfWork.Repairs.All(), "RepairID", "Notes", repairSparepart.RepairID);
            ViewBag.SparepartID = new SelectList(UnitOfWork.Spareparts.All(), "SparepartID", "Name", repairSparepart.SparepartID);
            return View(repairSparepart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepairSparepartID,RepairID,SparepartID")] RepairSparepart repairSparepart)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.RepairSpareparts.Update(repairSparepart);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RepairID = new SelectList(UnitOfWork.Repairs.All(), "RepairID", "Notes", repairSparepart.RepairID);
            ViewBag.SparepartID = new SelectList(UnitOfWork.Spareparts.All(), "SparepartID", "Name", repairSparepart.SparepartID);
            return View(repairSparepart);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairSparepart repairSparepart = UnitOfWork.RepairSpareparts.FindByID(id);
            if (repairSparepart == null)
            {
                return HttpNotFound();
            }
            ViewBag.RepairID = repairSparepart.RepairID;
            return View(repairSparepart);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairSparepart repairSparepart = UnitOfWork.RepairSpareparts.FindByID(id);
            UnitOfWork.RepairSpareparts.Remove(repairSparepart);
            UnitOfWork.SaveChanges();
            return RedirectToAction("AddSpareparts", "Repairs", new { id = repairSparepart.RepairID });
        }
    }
}
