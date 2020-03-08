using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormelOne.Exception;
using FormelOne.Models;

namespace FormelOne.Controllers
{
    /// <summary>
    /// TODO implemeting Docu - see DriverController same function name and same logic
    /// </summary>
    public class RacesController : BaseAuthController
    {
        public ActionResult Index()
        {
            return View(UnitOfWork.Races.All());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = UnitOfWork.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        public ActionResult Create()
        {
            ViewBag.SeasonId = new SelectList(UnitOfWork.Seasons.All(), "SeasonId", "Year");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaceId,Name,SeasonId")] Race race)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.Races.Create(race);
                    UnitOfWork.SaveChanges();
                }
                catch (LimitReachedException)
                {
                    ViewBag.Alert = "Limit wurde erreicht!";
                    return View(race);
                }
                catch (System.Exception)
                {
                    ViewBag.Alert = "Es ist ein Fehler aufgetreten!";
                    return View(race);
                }

                return RedirectToAction("Index");
            }

            ViewBag.SeasonId = new SelectList(UnitOfWork.Seasons.All(), "SeasonId", "Year", race.SeasonId);
            return View(race);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = UnitOfWork.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonId = new SelectList(UnitOfWork.Seasons.All(), "SeasonId", "Year", race.SeasonId);
            return View(race);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaceId,Name,SeasonId")] Race race)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Races.Update(race);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeasonId = new SelectList(UnitOfWork.Seasons.All(), "SeasonId", "Year", race.SeasonId);
            return View(race);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = UnitOfWork.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = UnitOfWork.Races.Find(id);
            UnitOfWork.Races.Remove(race);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
