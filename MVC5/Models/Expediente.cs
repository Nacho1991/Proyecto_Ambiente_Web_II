using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appProyectoFinal.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        public virtual Paciente Cliente { get; set; }
        public string FechaCreacion { get; set; }
        public string Hemoglobina { get; set; }
        public string AcidoUnico { get; set; }
        public string Creatina { get; set; }
        public string ColesterolTotal { get; set; }
    }
}