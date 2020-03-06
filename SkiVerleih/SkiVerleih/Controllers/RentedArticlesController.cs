using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkiVerleih.Exception;
using SkiVerleih.Models;

namespace SkiVerleih.Controllers
{
    public class RentedArticlesController : BaseAuthController
    {
        public ActionResult Index(bool isRented = true, string FilterFrom = null, string FilterTo = null)
        {
            DateTime dateFrom = (FilterFrom == null)? DateTime.Now : DateTime.Parse(FilterFrom);
            DateTime dateTo = (FilterFrom == null) ? DateTime.Now.AddDays(4) : DateTime.Parse(FilterTo);

            ViewBag.isRented = isRented;
            ViewBag.FilterFrom = dateFrom.ToString("yyyy-MM-dd");
            ViewBag.FilterTo = dateTo.ToString("yyyy-MM-dd");

            return View(UnitOfWork.RentedArticles.Filter(isRented, dateFrom, dateTo));
        }

        public ActionResult Create()
        {
            ViewBag.Alert = null;
            //Setting data for Selectlists
            ViewBag.ArticleId = new SelectList(UnitOfWork.Articles.All(), "ArticleId", "Name");
            ViewBag.CustomerId = new SelectList(UnitOfWork.Customers.All(), "CustomerId", "FirstName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentedArticleId,Amount,RentedFrom,RentedTo,ArticleId,CustomerId")] RentedArticle rentedArticle)
        {
            ViewBag.ArticleId = new SelectList(UnitOfWork.Articles.All(), "ArticleId", "Name", rentedArticle.ArticleId);
            ViewBag.CustomerId = new SelectList(UnitOfWork.Customers.All(), "CustomerId", "FirstName", rentedArticle.CustomerId);

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.RentedArticles.Create(rentedArticle);
                }
                catch(NotAvailableException)
                {
                    ViewBag.Alert = "Artikel ist zu diesem Zeitraum nicht verfügbar";

                    return View(rentedArticle);
                }
                catch (System.Exception)
                {
                    ViewBag.Alert = "Ein Fehler ist aufgetreten, bitte versuchen Sie es später";

                    return View(rentedArticle);
                }

                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentedArticle);
        }

        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedArticle rentedArticle = UnitOfWork.RentedArticles.FindById(id);
            if (rentedArticle == null)
            {
                return HttpNotFound();
            }
            return View(rentedArticle);
        }

        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public ActionResult Return(int id)
        {
            RentedArticle rentedArticle = UnitOfWork.RentedArticles.FindById(id);

            rentedArticle.IsRented = false;
            UnitOfWork.RentedArticles.Update(rentedArticle);
            UnitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
