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
    public class CarroController : Controller
    {
        private etecfp2023rodrigoEntities db = new etecfp2023rodrigoEntities();

        // GET: Carro
        public ActionResult Index()
        {
            return View(db.tb_carro.ToList());
        }

        // GET: Carro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_carro tb_carro = db.tb_carro.Find(id);
            if (tb_carro == null)
            {
                return HttpNotFound();
            }
            return View(tb_carro);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,placa,ano,cor")] tb_carro tb_carro)
        {
            if (ModelState.IsValid)
            {
                db.tb_carro.Add(tb_carro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_carro);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_carro tb_carro = db.tb_carro.Find(id);
            if (tb_carro == null)
            {
                return HttpNotFound();
            }
            return View(tb_carro);
        }

        // POST: Carro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,placa,ano,cor")] tb_carro tb_carro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_carro);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_carro tb_carro = db.tb_carro.Find(id);
            if (tb_carro == null)
            {
                return HttpNotFound();
            }
            return View(tb_carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_carro tb_carro = db.tb_carro.Find(id);
            db.tb_carro.Remove(tb_carro);
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
