using BEUEjercicio;
using BEUEjercicio.Queris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebApiEscolastico.Models;

namespace WebApiEscolastico.Controllers
{
    [EnableCors(origins: "http://localhost:4200",headers:"*",methods:"*")]
    public class AlumnosController : ApiController
    {
        public IHttpActionResult Post(alumno alumno)
        {
            try
            {
                AlumnoBLL.Create(alumno);
                return Content(HttpStatusCode.Created, "Alumno creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                List<alumno> todos = AlumnoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                alumno result = AlumnoBLL.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(alumno alumno)
        {
            try
            {
                AlumnoBLL.Update(alumno);
                return Content(HttpStatusCode.OK, "Alumno actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                AlumnoBLL.Delete(id);
                return Ok("Alumno eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}