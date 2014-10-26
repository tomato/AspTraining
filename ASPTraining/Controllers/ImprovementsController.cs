using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPTraining.Models;
using ASPTraining.Repositories;

namespace ASPTraining.Controllers
{
    public class ImprovementsController : Controller
    {
        private IImprovementsRepository repos;

        public ImprovementsController(IImprovementsRepository repos)
        {
            this.repos = repos;
        }

        // GET: Improvements
        public ActionResult Index(int? id)
        {
            var improvements = repos.SelectAll().OrderBy(i => i.Status).ToList();
            ViewBag.SelectedId = id ?? improvements.FirstOrDefault().ID;
            return View(improvements);
        }

        // GET: Improvements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Improvement improvement = repos.SelectByID(id.Value);
            if (improvement == null)
            {
                return HttpNotFound();
            }
            return View(improvement);
        }

        // GET: Improvements/Create
        public ActionResult Create()
        {
            ViewBag.StatusList = new SelectList(repos.AllStati(), "ID", "Description");
            return View();
        }

        // POST: Improvements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,StatusID")] Improvement improvement)
        {
            if (ModelState.IsValid)
            {
                repos.Insert(improvement);
                repos.Save();
                return RedirectToAction("Index");
            }
            ViewBag.StatusList = new SelectList(repos.AllStati(), "ID", "Description");
            return View(improvement);
        }

        // GET: Improvements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.StatusList = new SelectList(repos.AllStati(),"ID","Description");
            Improvement improvement = repos.SelectByID(id.Value);
            if (improvement == null)
            {
                return HttpNotFound();
            }
            return View(improvement);
        }

        // POST: Improvements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,StatusID")] Improvement improvement)
        {
            if (ModelState.IsValid)
            {
                repos.Update(improvement);
                repos.Save();
                return RedirectToAction("Index");
            }
            ViewBag.StatusList = new SelectList(repos.AllStati(), "ID", "Description");
            return View(improvement);
        }

        // GET: Improvements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Improvement improvement = repos.SelectByID(id.Value);
            if (improvement == null)
            {
                return HttpNotFound();
            }
            return View(improvement);
        }

        // POST: Improvements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repos.Delete(id);
            repos.Save();
            return RedirectToAction("Index");
        }

    }
}
