using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Copa.Models;

namespace Copa.Controllers
{
    public class ComentarioController : Controller
    {
        private GerenciarNoticiaEntities db = new GerenciarNoticiaEntities();

        //
        // GET: /Comentario/

        public ActionResult Index()
        {
            return View(db.comentario.ToList());
        }

        //
        // GET: /Comentario/Details/5

        public ActionResult Details(int id = 0)
        {
            comentario comentario = db.comentario.Single(c => c.idcomentario == id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        //
        // GET: /Comentario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comentario/Create

        [HttpPost]
        public ActionResult Create(comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.comentario.AddObject(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comentario);
        }

        //
        // GET: /Comentario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            comentario comentario = db.comentario.Single(c => c.idcomentario == id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        //
        // POST: /Comentario/Edit/5

        [HttpPost]
        public ActionResult Edit(comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.comentario.Attach(comentario);
                db.ObjectStateManager.ChangeObjectState(comentario, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        //
        // GET: /Comentario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            comentario comentario = db.comentario.Single(c => c.idcomentario == id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        //
        // POST: /Comentario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            comentario comentario = db.comentario.Single(c => c.idcomentario == id);
            db.comentario.DeleteObject(comentario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}