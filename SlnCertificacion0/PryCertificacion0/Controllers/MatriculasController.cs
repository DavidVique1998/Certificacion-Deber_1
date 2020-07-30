using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;
using BEUEjercicio.Queris;

namespace PryCertificacion0.Controllers
{
    public class MatriculasController : Controller
    {


        // GET: matriculas
        public ActionResult Index()
        {

            return View(MatriculaBLL.List());
        }

        // GET: matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: matriculas/Create
        public ActionResult Create()
        {
            ViewBag.idarea = new SelectList(AreaBLL.List(), "idarea", "nombre");
            return View();
        }

        // POST: matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmatricula,nombre,nrc,creditos,idarea")] matricula matricula)
        {
            if (ModelState.IsValid)
            {
                MatriculaBLL.Create(matricula);
                return RedirectToAction("Index");
            }

            ViewBag.idarea = new SelectList(AreaBLL.List(), "idarea", "nombre", matricula.idalumno);
            return View(matricula);
        }

        // GET: matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.idarea = new SelectList(AreaBLL.List(), "idarea", "nombre", matricula.idalumno);
            return View(matricula);
        }

        // POST: matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmatricula,nombre,nrc,creditos,idarea")] matricula matricula)
        {
            if (ModelState.IsValid)
            {
                MatriculaBLL.Update(matricula);
                return RedirectToAction("Index");
            }
            ViewBag.idarea = new SelectList(AreaBLL.List(), "idarea", "nombre", matricula.idalumno);
            return View(matricula);
        }

        // GET: matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matricula matricula = MatriculaBLL.Get(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatriculaBLL.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
