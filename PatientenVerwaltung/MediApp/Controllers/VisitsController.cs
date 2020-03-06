using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediApp.Models;
using MediApp.ViewModels;

namespace MediApp.Controllers
{
    /// <summary>
    /// Extends the BaseAuthController for UnitOfWork and Authorize
    /// </summary>
    public class VisitsController : BaseAuthController
    {
        /// <summary>
        /// Returns all Visits
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string from, string to, int? DoctorId)
        {
            var FilterFrom = (from == null) ? DateTime.Now.ToString("yyyy-MM-dd") : from;
            var FilterTo = (to == null) ? DateTime.Now.AddDays(3).ToString("yyyy-MM-dd") : to;
            var FilterDoctor = (to == null) ? 2 :DoctorId;

            ViewBag.FilterFrom = FilterFrom;
            ViewBag.FilterTo = FilterTo;
            ViewBag.DoctorId = new SelectList(UnitOfWork.Doctors.All(), "DoctorId", "Name", FilterDoctor);

            return View(UnitOfWork.Visits.Filter(FilterFrom, FilterTo, DoctorId));
        }

        /// <summary>
        /// Create new Visit
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(UnitOfWork.Doctors.All(), "DoctorId", "Name");

            return View();
        }

        /// <summary>
        /// Post Request for creating new visit
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitId,Date,Comment,DoctorId")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Visits.Create(visit);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(UnitOfWork.Doctors.All(), "DoctorId", "Name", visit.DoctorId);

            return View(visit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPerscribedMedicine(FormCollection form)
        {
            var medicine = new PrescribedMedicine()
            {
                MedicineId = Int32.Parse(form["MedicineId"]),
                VisitId = Int32.Parse(form["VisitId"]),
                Amount = Int32.Parse(form["PrescribedMedicine.Amount"]),
            };

            if (ModelState.IsValid)
            {
                 UnitOfWork.PrescribedMedicines.Create(medicine);
                 UnitOfWork.SaveChanges();

                return RedirectToAction("Edit", new { id = medicine.VisitId });
            }

            return RedirectToAction("Edit", new { id = medicine.VisitId });
        }

        /// <summary>
        /// Edit Visit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = UnitOfWork.Visits.FindById(id);

            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(UnitOfWork.Doctors.All(), "DoctorId", "Name", visit.DoctorId);
            ViewBag.MedicineId = new SelectList(UnitOfWork.Medicines.All(), "MedicineId", "Name");

            var visitViewModel = new VisitWithPrescribedMedicines() {
                Visit = visit,
                PrescribedMedicine = new PrescribedMedicine(),
                PrescribedMedicines = UnitOfWork.Visits.PrescribedMedicines(id)
            };

            return View(visitViewModel);
        }

        /// <summary>
        /// Post request for editing the visit 
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitId,Date,Comment,DoctorId")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Visits.Update(visit);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(UnitOfWork.Doctors.All(), "DoctorId", "Name", visit.DoctorId);
            return View(visit);
        }

        /// <summary>
        /// Delete Visit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = UnitOfWork.Visits.FindById(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        /// <summary>
        /// Post Request for deleting a Visit by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = UnitOfWork.Visits.FindById(id);
            UnitOfWork.Visits.Remove(visit);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
