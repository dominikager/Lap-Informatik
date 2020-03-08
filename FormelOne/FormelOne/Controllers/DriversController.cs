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
    public class DriversController : BaseAuthController
    {
        /// <summary>
        /// Shows an overview of all Drivers
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(UnitOfWork.Drivers.All());
        }

        /// <summary>
        /// Show the Form for creating a new Drivers
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Alert = null;
            ViewBag.TeamId = new SelectList(UnitOfWork.Teams.All(), "TeamId", "Name");
            return View();
        }

        /// <summary>
        /// Handles the Post request when you create a new Driver
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,Name,TeamId")] Driver driver)
        {
            ViewBag.Alert = null;
            ViewBag.TeamId = new SelectList(UnitOfWork.Teams.All(), "TeamId", "Name", driver.TeamId);

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.Drivers.Create(driver);
                    UnitOfWork.SaveChanges();
                }
                catch (LimitReachedException)
                {
                    ViewBag.Alert = "Limit wurde erreicht!";
                    return View(driver);
                }
                catch (System.Exception)
                {
                    ViewBag.Alert = "Es ist ein Fehler aufgetreten!";
                    return View(driver);
                }


                return RedirectToAction("Index");
            }

            return View(driver);
        }

       /// <summary>
       /// Shows the Edit Form
       /// If the Id is not valid it will throw an 404
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = UnitOfWork.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(UnitOfWork.Teams.All(), "TeamId", "Name", driver.TeamId);
            return View(driver);
        }

        /// <summary>
        /// Handles the Post Request for Edit
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,Name,TeamId")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Drivers.Update(driver);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(UnitOfWork.Teams.All(), "TeamId", "Name", driver.TeamId);
            return View(driver);
        }

        /// <summary>
        /// Show an button where you have to confirm that you want to delete this
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = UnitOfWork.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        /// <summary>
        /// Will handel the delete form post request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = UnitOfWork.Drivers.Find(id);
            UnitOfWork.Drivers.Remove(driver);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
