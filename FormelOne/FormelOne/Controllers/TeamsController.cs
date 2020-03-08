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
    [Authorize]
    public class TeamsController : BaseAuthController
    {
        /// <summary>
        /// Will give a overview of all Team
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(UnitOfWork.Teams.All());
        }

        /// <summary>
        /// Will return the form for creating a new Team
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Handle the Post Request when you submit the form
        /// If the model is not valid, you jump back to the form that is prefilled
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,Name")] Team team)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.Teams.Create(team);
                    UnitOfWork.SaveChanges();
                }
                catch (LimitReachedException)
                {
                    ViewBag.Alert = "Limit wurde erreicht!";
                    return View(team);
                }
                catch (System.Exception)
                {
                    ViewBag.Alert = "Es ist ein Fehler aufgetreten!";
                    return View(team);
                }

                return RedirectToAction("Index");
            }

            return View(team);
        }

        /// <summary>
        /// Return the form for editing a Team
        /// Throws an 404 if the Team by the id is not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = UnitOfWork.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        /// <summary>
        /// Handles the Post request when you submit the edit form
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,Name")] Team team)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Teams.Update(team);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        /// <summary>
        /// Show an button where you have to confirm that you want to delete this Team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = UnitOfWork.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = UnitOfWork.Teams.Find(id);
            UnitOfWork.Teams.Remove(team);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
