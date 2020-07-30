using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;

namespace PryCertificacion0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            alumno alumno = new alumno();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Certificación I NRC-7614. Prueba de Sincronización";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}