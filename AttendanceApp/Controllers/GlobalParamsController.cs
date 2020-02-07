using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AttendanceApp.DAL;
using AttendanceApp.Models;

namespace AttendanceApp.Controllers
{
    public class GlobalParamsController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        [Authorize]
        [Authorize(Roles = "Admin")]
        // GET: GlobalParams
        public ActionResult Index()
        {
            GlobalParams globalParams;

            if (!db.GlobalParams.Any())
            {
                globalParams = new GlobalParams();
                Create(globalParams);
            }
            else
            {
                globalParams = db.GlobalParams.FirstOrDefault();
            }
            return View(globalParams);
        }

        // POST: GlobalParams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MainItemsCap,CategoryPagingSize")] GlobalParams globalParams)
        {
            if (ModelState.IsValid)
            {
                db.GlobalParams.Add(globalParams);
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalParams globalParams = db.GlobalParams.Find(id);
            if (globalParams == null)
            {
                return HttpNotFound();
            }
            return View(globalParams);
        }

        // POST: GlobalParams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MainItemsCap,CategoryPagingSize")] GlobalParams globalParams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(globalParams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(globalParams);
        }
    }
}
