using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamFinal;

namespace ExamFinal.Controllers
{
    public class EXAMsController : Controller
    {
        private ExamFinalContext db = new ExamFinalContext();

        // GET: EXAMs
        public ActionResult Index()
        {
            var eXAMs = db.EXAMs.Include(e => e.Class).Include(e => e.Subject).Include(e => e.Faculty1);
            return View(eXAMs.ToList());
        }

        // GET: EXAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAM eXAM = db.EXAMs.Find(id);
            if (eXAM == null)
            {
                return HttpNotFound();
            }
            return View(eXAM);
        }

        // GET: EXAMs/Create
        public ActionResult Create()
        {
            ViewBag.classRoom = new SelectList(db.Classes, "id", "name");
            ViewBag.examSubject = new SelectList(db.Subjects, "id", "name");
            ViewBag.faculty = new SelectList(db.Faculties, "id", "name");
            return View();
        }

        // POST: EXAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,examSubject,startTime,examDate,examDuration,classRoom,faculty")] EXAM eXAM)
        {
            if (ModelState.IsValid)
            {

                db.EXAMs.Add(eXAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.classRoom = new SelectList(db.Classes, "id", "name", eXAM.classRoom);
            ViewBag.examSubject = new SelectList(db.Subjects, "id", "name", eXAM.examSubject);
            ViewBag.faculty = new SelectList(db.Faculties, "id", "name", eXAM.faculty);
            return View(eXAM);
        }

        // GET: EXAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAM eXAM = db.EXAMs.Find(id);
            if (eXAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.classRoom = new SelectList(db.Classes, "id", "name", eXAM.classRoom);
            ViewBag.examSubject = new SelectList(db.Subjects, "id", "name", eXAM.examSubject);
            ViewBag.faculty = new SelectList(db.Faculties, "id", "name", eXAM.faculty);
            return View(eXAM);
        }

        // POST: EXAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,examSubject,startTime,examDate,examDuration,classRoom,faculty")] EXAM eXAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eXAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.classRoom = new SelectList(db.Classes, "id", "name", eXAM.classRoom);
            ViewBag.examSubject = new SelectList(db.Subjects, "id", "name", eXAM.examSubject);
            ViewBag.faculty = new SelectList(db.Faculties, "id", "name", eXAM.faculty);
            return View(eXAM);
        }

        // GET: EXAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXAM eXAM = db.EXAMs.Find(id);
            if (eXAM == null)
            {
                return HttpNotFound();
            }
            return View(eXAM);
        }

        // POST: EXAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EXAM eXAM = db.EXAMs.Find(id);
            db.EXAMs.Remove(eXAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
