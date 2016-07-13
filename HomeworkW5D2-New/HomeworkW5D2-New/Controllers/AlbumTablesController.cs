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
    public class AlbumTablesController : Controller
    {
        private AlbumHomeworkDBEntities db = new AlbumHomeworkDBEntities();

        // GET: AlbumTables
        public ActionResult Index()
        {
            var albumTables = db.AlbumTables.Include(a => a.ArtistTable).Include(a => a.GenreTable);
            return View(albumTables.ToList());
        }

        // GET: AlbumTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTable albumTable = db.AlbumTables.Find(id);
            if (albumTable == null)
            {
                return HttpNotFound();
            }
            return View(albumTable);
        }

        // GET: AlbumTables/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.ArtistTables, "ArtistID", "ArtistName");
            ViewBag.GenreID = new SelectList(db.GenreTables, "GenreID", "GenreName");
            return View();
        }

        // POST: AlbumTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumID,AlbumName,ArtistID,GenreID,Image")] AlbumTable albumTable)
        {
            if (ModelState.IsValid)
            {
                db.AlbumTables.Add(albumTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.ArtistTables, "ArtistID", "ArtistName", albumTable.ArtistID);
            ViewBag.GenreID = new SelectList(db.GenreTables, "GenreID", "GenreName", albumTable.GenreID);
            return View(albumTable);
        }

        // GET: AlbumTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTable albumTable = db.AlbumTables.Find(id);
            if (albumTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.ArtistTables, "ArtistID", "ArtistName", albumTable.ArtistID);
            ViewBag.GenreID = new SelectList(db.GenreTables, "GenreID", "GenreName", albumTable.GenreID);
            return View(albumTable);
        }

        // POST: AlbumTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumID,AlbumName,ArtistID,GenreID,Image")] AlbumTable albumTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.ArtistTables, "ArtistID", "ArtistName", albumTable.ArtistID);
            ViewBag.GenreID = new SelectList(db.GenreTables, "GenreID", "GenreName", albumTable.GenreID);
            return View(albumTable);
        }

        // GET: AlbumTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumTable albumTable = db.AlbumTables.Find(id);
            if (albumTable == null)
            {
                return HttpNotFound();
            }
            return View(albumTable);
        }

        // POST: AlbumTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumTable albumTable = db.AlbumTables.Find(id);
            db.AlbumTables.Remove(albumTable);
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
