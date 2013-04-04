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
    public class NoticiaController : Controller
    {
        private GerenciarNoticiaEntities db = new GerenciarNoticiaEntities();

        //
        // GET: /Noticia/

        public ActionResult Index()
        {
            var noticia = db.noticia.Include("comentario").Include("usuario");
            return View(noticia.ToList());
        }

        //
        // GET: /Noticia/Details/5

        public ActionResult Details(int id = 0)
        {
            noticia noticia = db.noticia.Single(n => n.idnoticia == id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        //
        // GET: /Noticia/Create

        public ActionResult Create()
        {
            ViewBag.idcomentario = new SelectList(db.comentario, "idcomentario", "conteudo");
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nome");
            return View();
        }

        //
        // POST: /Noticia/Create

        [HttpPost]
        public ActionResult Create(noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.noticia.AddObject(noticia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcomentario = new SelectList(db.comentario, "idcomentario", "conteudo", noticia.idcomentario);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nome", noticia.idusuario);
            return View(noticia);
        }

        //
        // GET: /Noticia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            noticia noticia = db.noticia.Single(n => n.idnoticia == id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcomentario = new SelectList(db.comentario, "idcomentario", "conteudo", noticia.idcomentario);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nome", noticia.idusuario);
            return View(noticia);
        }

        //
        // POST: /Noticia/Edit/5

        [HttpPost]
        public ActionResult Edit(noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.noticia.Attach(noticia);
                db.ObjectStateManager.ChangeObjectState(noticia, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcomentario = new SelectList(db.comentario, "idcomentario", "conteudo", noticia.idcomentario);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nome", noticia.idusuario);
            return View(noticia);
        }

        //
        // GET: /Noticia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            noticia noticia = db.noticia.Single(n => n.idnoticia == id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        //
        // POST: /Noticia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            noticia noticia = db.noticia.Single(n => n.idnoticia == id);
            db.noticia.DeleteObject(noticia);
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