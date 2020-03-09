using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lagerverwaltung.Models;

namespace Lagerverwaltung.Controllers
{
    public class ProcessArticlesController : BaseAuthController
    {
        // GET: ProcessArticles/Create
        public ActionResult Create(int? id)
        {
            ViewBag.ProcessId = id;
            ViewBag.ArticleId = new SelectList(UnitOfWork.Articles.All(), "ArticleId", "Name");

            return View();
        }

        // POST: ProcessArticles/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProcessArticleId,ArticleId,ProcessId,Amount")] ProcessArticle processArticle, int? id)
        {
            int FutureStock = 0;

            if (ModelState.IsValid)
            {
                int stock = UnitOfWork.ProcessArticles.StockByArticleId(processArticle.ArticleId);

                var process = UnitOfWork.Processes.Find(id);

                if(process.TransactionId == 2)
                {
                    FutureStock = stock - processArticle.Amount;
                }

                if(FutureStock >= 0)
                {
                    UnitOfWork.ProcessArticles.Create(processArticle);
                    UnitOfWork.SaveChanges();
                    return RedirectToAction("AddArticles", "Processes", new { id = processArticle.ProcessId });
                }
            }

            if(FutureStock < 0)
            {
                ViewBag.Alert = "Lagerstand nicht ausreichend";
            }

            ViewBag.ProcessId = id;
            ViewBag.ArticleId = new SelectList(UnitOfWork.Articles.All(), "ArticleId", "Name", processArticle.ArticleId);

            return View(processArticle);
        }

        // GET: ProcessArticles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessArticle processArticle = UnitOfWork.ProcessArticles.Find(id);
            if (processArticle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(UnitOfWork.Articles.All(), "ArticleId", "Name", processArticle.ArticleId);
            ViewBag.ProcessId = new SelectList(UnitOfWork.Processes.All(), "ProcessId", "Name", processArticle.ProcessId);
            return View(processArticle);
        }

        // POST: ProcessArticles/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProcessArticleId,ArticleId,ProcessId,Amount")] ProcessArticle processArticle)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.ProcessArticles.Update(processArticle);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(UnitOfWork.Articles.All(), "ArticleId", "Name", processArticle.ArticleId);
            ViewBag.ProcessId = new SelectList(UnitOfWork.Processes.All(), "ProcessId", "Name", processArticle.ProcessId);
            return View(processArticle);
        }

        // GET: ProcessArticles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessArticle processArticle = UnitOfWork.ProcessArticles.Find(id);
            if (processArticle == null)
            {
                return HttpNotFound();
            }
            return View(processArticle);
        }

        // POST: ProcessArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcessArticle processArticle = UnitOfWork.ProcessArticles.Find(id);
            UnitOfWork.ProcessArticles.Remove(processArticle);
            UnitOfWork.SaveChanges();

            return RedirectToAction("AddArticles", "Processes", new { id = processArticle.ProcessId });
        }
    }
}
