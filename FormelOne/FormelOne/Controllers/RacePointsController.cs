using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormelOne.Models;

namespace FormelOne.Controllers
{
    public class RacePointsController : BaseAuthController
    {
        public ActionResult Index(int? DriverId, int? SeasonId)
        {
            ViewBag.DriverId = new SelectList(UnitOfWork.Drivers.All(), "DriverId", "Name", DriverId);
            ViewBag.SeasonId = new SelectList(UnitOfWork.Seasons.All(), "SeasonId", "Year", SeasonId);

            if(DriverId == null && SeasonId == null) {
                return View(UnitOfWork.RacePoints.All());
            }

            return View(UnitOfWork.RacePoints.Filtered(DriverId, SeasonId));
        }

        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(UnitOfWork.Drivers.All(), "DriverId", "Name");
            ViewBag.RaceId = new SelectList(UnitOfWork.Races.All(), "RaceId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RacePointId,value,DriverId,RaceId")] RacePoint racePoint)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.RacePoints.Create(racePoint);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverId = new SelectList(UnitOfWork.Drivers.All(), "DriverId", "Name", racePoint.DriverId);
            ViewBag.RaceId = new SelectList(UnitOfWork.Races.All(), "RaceId", "Name", racePoint.RaceId);
            return View(racePoint);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RacePoint racePoint = UnitOfWork.RacePoints.Find(id);
            if (racePoint == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(UnitOfWork.Drivers.All(), "DriverId", "Name", racePoint.DriverId);
            ViewBag.RaceId = new SelectList(UnitOfWork.Races.All(), "RaceId", "Name", racePoint.RaceId);
            return View(racePoint);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RacePointId,value,DriverId,RaceId")] RacePoint racePoint)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.RacePoints.Update(racePoint);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverId = new SelectList(UnitOfWork.Drivers.All(), "DriverId", "Name", racePoint.DriverId);
            ViewBag.RaceId = new SelectList(UnitOfWork.Races.All(), "RaceId", "Name", racePoint.RaceId);
            return View(racePoint);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RacePoint racePoint = UnitOfWork.RacePoints.Find(id);
            if (racePoint == null)
            {
                return HttpNotFound();
            }
            return View(racePoint);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RacePoint racePoint = UnitOfWork.RacePoints.Find(id);
            UnitOfWork.RacePoints.Remove(racePoint);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
