using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appProyectoFinal.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public string fecha { get; set; }
        public virtual Paciente Cedula { get; set; }
        public string Estado { get; set; }
    }
}