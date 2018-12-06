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
    public class HistoricsController : Controller
    {
        private IHistoricRepository historicrepository = new HistoricRepository();

        // GET: Historics
        public ActionResult Index()
        {
            //return View(db.Events.ToList());
            return View();
        }

        // GET: Historics/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Historic historic = db.Events.Find(historic.Id);
            //if (historic == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(historic);
            return View();
        }

        // GET: Historics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Historics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime,Price,Discount,Capacity,Description,Location_Id,Languages")] Historic historic)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Events.Add(historic);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(historic);
            return View();
        }

        // GET: Historics/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Historic historic = db.Events.Find(id);
            //if (historic == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(historic);
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime,Price,Discount,Capacity,Description,Location_Id,Languages")] Historic historic)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(historic).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(historic);
            return View();
        }

        // GET: Historics/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Historic historic = db.Events.Find(id);
            //if (historic == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(historic);
            return View();
        }

        // POST: Historics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Historic historic = db.Events.Find(id);
            //db.Events.Remove(historic);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
