using BEUEjercicio;
using BEUEjercicio.Queris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiEscolastico.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TipoBecaController : ApiController
    {
        public IHttpActionResult Post(tipoBeca tipoBeca)
        {
            try
            {
                TipoBecaBLL.Create(tipoBeca);
                return Content(HttpStatusCode.Created, "Tipo de Beca creada correctamente");
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
                List<tipoBeca> todos = TipoBecaBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(tipoBeca tipoBeca)
        {
            try
            {
                TipoBecaBLL.Update(tipoBeca);
                return Content(HttpStatusCode.Accepted, "Tipo de Beca actualizada correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                tipoBeca result = TipoBecaBLL.Get(id);
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

        public IHttpActionResult Delete(int id)
        {
            try
            {
                TipoBecaBLL.Delete(id);
                return Content(HttpStatusCode.Accepted ,"Tipo de Beca eliminada correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
