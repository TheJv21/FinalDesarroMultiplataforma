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
    public class EstudianteController : ApiController
    {
        // GET api/<controller>
        public List<Estudiante> Get()
        {
            return EstudianteData.Listar();
        }


        // POST api/<controller>
        public bool Post([FromBody]Estudiante oEstudiante)
        {
            return EstudianteData.Registrar(oEstudiante);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Estudiante oEstudiante)
        {
            return EstudianteData.Modificar(oEstudiante);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return EstudianteData.Eliminar(id);
        }
    }
}