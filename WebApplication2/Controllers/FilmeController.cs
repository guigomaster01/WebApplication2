using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class FilmeController : Controller
    {
        private etecfp2023rodrigoEntities db = new etecfp2023rodrigoEntities();

        // GET: Filme
        public ActionResult Index()
        {
            return View(db.tb_filmes.ToList());
        }

        // GET: Filme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            if (tb_filmes == null)
            {
                return HttpNotFound();
            }
            return View(tb_filmes);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Lancamento,Nota")] tb_filmes tb_filmes)
        {
            if (ModelState.IsValid)
            {
                db.tb_filmes.Add(tb_filmes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_filmes);
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            if (tb_filmes == null)
            {
                return HttpNotFound();
            }
            return View(tb_filmes);
        }

        // POST: Filme/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Lancamento,Nota")] tb_filmes tb_filmes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_filmes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_filmes);
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            if (tb_filmes == null)
            {
                return HttpNotFound();
            }
            return View(tb_filmes);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_filmes tb_filmes = db.tb_filmes.Find(id);
            db.tb_filmes.Remove(tb_filmes);
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
