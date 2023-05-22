using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AsignacionController : ApiController
    {
        // GET api/<controller>
        public List<Asignacion> Get()
        {
            return AsignacionData.Listar();
        }


        // POST api/<controller>
        public bool Post([FromBody]Asignacion oAsignacion)
        {
            return AsignacionData.Registrar(oAsignacion);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Asignacion oAsignacion)
        {
            return AsignacionData.Modificar(oAsignacion);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return AsignacionData.Eliminar(id);
        }
    }
}