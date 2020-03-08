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
    /// <summary>
    /// TODO implementing Doc - see DriversController same method name means same logic
    /// </summary>
    public class SeasonsController : BaseAuthController
    {
        public ActionResult Index()
        {
            return View(UnitOfWork.Seasons.All());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeasonId,Year")] Season season)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Seasons.Create(season);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(season);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = UnitOfWork.Seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeasonId,Year")] Season season)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Seasons.Update(season);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(season);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = UnitOfWork.Seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Season season = UnitOfWork.Seasons.Find(id);
            UnitOfWork.Seasons.Remove(season);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
