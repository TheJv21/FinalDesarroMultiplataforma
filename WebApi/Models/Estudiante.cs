using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Estudiante
    {
        public string carnet { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string carrera { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string genero { get; set; }
        public DateTime fecha_ingreso { get; set; }
    }
}
