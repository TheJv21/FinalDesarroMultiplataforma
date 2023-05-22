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
    public class CursoController : ApiController
    {
        // GET api/<controller>
        public List<Curso> Get()
        {
            return CursoData.Listar();
        }


        // POST api/<controller>
        public bool Post([FromBody]Curso oCurso)
        {
            return CursoData.Registrar(oCurso);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Curso oCurso)
        {
            return CursoData.Modificar(oCurso);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return CursoData.Eliminar(id);
        }
    }
}