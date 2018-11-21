using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;

namespace HaarlemFilmFestival.Controllers
{
    public class JazzsController : Controller
    {
        private IJazzRepository jazzRepository = new JazzRepository();

        // GET: Jazzs
        public ActionResult Index()
        {
            IEnumerable<Jazz> allJazzs = jazzRepository.GetAllJazz();
            return View(allJazzs);
        }

        // GET: Jazzs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jazz jazz = jazzRepository.GetJazz((int)id);
            if (jazz == null)
            {
                return HttpNotFound();
            }
            return View(jazz);
        }

        // GET: Jazzs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jazzs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JazzId,Rang,Rangprijs,Band")] Jazz jazz)
        {
            if (ModelState.IsValid)
            {
                jazzRepository.AddJazz(jazz);
                return RedirectToAction("Index");
            }

            return View(jazz);
        }

        // GET: Jazzs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jazz jazz = jazzRepository.GetJazz((int)id);
            if (jazz == null)
            {
                return HttpNotFound();
            }
            return View(jazz);
        }

        // POST: Jazzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JazzId,Rang,Rangprijs,Band")] Jazz jazz)
        {
            if (ModelState.IsValid)
            {
                jazzRepository.UpdateJazz(jazz);
                return RedirectToAction("Index");
            }
            return View(jazz);
        }

        // GET: Jazzs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jazz jazz = jazzRepository.GetJazz((int)id);
            if (jazz == null)
            {
                return HttpNotFound();
            }
            return View(jazz);
        }

        // POST: Jazzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            jazzRepository.DeleteJazz((int)id);
            return RedirectToAction("Index");
        }
    }
}
