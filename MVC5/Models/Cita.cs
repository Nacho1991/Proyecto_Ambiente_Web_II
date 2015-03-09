using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appProyectoFinal.Models
{
    public class Cita
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de la cita")]
        public string fecha { get; set; }

        [Required]
        [Display(Name = "Cédula")]
        public virtual Paciente Cedula { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}