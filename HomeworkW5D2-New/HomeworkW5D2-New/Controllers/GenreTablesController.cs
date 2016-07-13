using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeworkW5D2_New;

namespace HomeworkW5D2_New.Controllers
{
    public class GenreTablesController : Controller
    {
        private AlbumHomeworkDBEntities db = new AlbumHomeworkDBEntities();

        // GET: GenreTables
        public ActionResult Index()
        {
            return View(db.GenreTables.ToList());
        }

        // GET: GenreTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreTable genreTable = db.GenreTables.Find(id);
            if (genreTable == null)
            {
                return HttpNotFound();
            }
            return View(genreTable);
        }

        // GET: GenreTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreID,GenreName")] GenreTable genreTable)
        {
            if (ModelState.IsValid)
            {
                db.GenreTables.Add(genreTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genreTable);
        }

        // GET: GenreTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreTable genreTable = db.GenreTables.Find(id);
            if (genreTable == null)
            {
                return HttpNotFound();
            }
            return View(genreTable);
        }

        // POST: GenreTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreID,GenreName")] GenreTable genreTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genreTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genreTable);
        }

        // GET: GenreTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreTable genreTable = db.GenreTables.Find(id);
            if (genreTable == null)
            {
                return HttpNotFound();
            }
            return View(genreTable);
        }

        // POST: GenreTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenreTable genreTable = db.GenreTables.Find(id);
            db.GenreTables.Remove(genreTable);
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
