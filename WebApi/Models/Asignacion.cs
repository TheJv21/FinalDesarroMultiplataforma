using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Asignacion
    {
        public int id_asignacion { get; set; }
        public string carnet { get; set; }
        public int id_curso { get; set; }
        public string seccion { get; set; }
        public DateTime fecha_realizacion { get; set; }
        public string semestre { get; set; }
        public string anho { get; set; }
    }
}
