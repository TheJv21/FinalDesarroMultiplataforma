using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Curso
    {
        public int id_curso { get; set; }
        public string nombre { get; set; }
        public string semestre { get; set; }
        public string valor_creditos { get; set; }
    }
}
