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
    public class ArtistTablesController : Controller
    {
        private AlbumHomeworkDBEntities db = new AlbumHomeworkDBEntities();

        // GET: ArtistTables
        public ActionResult Index()
        {
            return View(db.ArtistTables.ToList());
        }

        // GET: ArtistTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistTable artistTable = db.ArtistTables.Find(id);
            if (artistTable == null)
            {
                return HttpNotFound();
            }
            return View(artistTable);
        }

        // GET: ArtistTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistID,ArtistName")] ArtistTable artistTable)
        {
            if (ModelState.IsValid)
            {
                db.ArtistTables.Add(artistTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artistTable);
        }

        // GET: ArtistTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistTable artistTable = db.ArtistTables.Find(id);
            if (artistTable == null)
            {
                return HttpNotFound();
            }
            return View(artistTable);
        }

        // POST: ArtistTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID,ArtistName")] ArtistTable artistTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artistTable);
        }

        // GET: ArtistTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistTable artistTable = db.ArtistTables.Find(id);
            if (artistTable == null)
            {
                return HttpNotFound();
            }
            return View(artistTable);
        }

        // POST: ArtistTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistTable artistTable = db.ArtistTables.Find(id);
            db.ArtistTables.Remove(artistTable);
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
