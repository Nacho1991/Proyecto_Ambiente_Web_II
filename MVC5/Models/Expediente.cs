using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appProyectoFinal.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cédula del cliente")]
        public virtual Paciente Cliente { get; set; }
        [Required]
        [Display(Name = "Fecha de creación")]
        public string FechaCreacion { get; set; }
        [Required]
        [Display(Name = "Hemoglobina")]
        public string Hemoglobina { get; set; }
        [Required]
        [Display(Name = "AcidoUnico")]
        public string AcidoUnico { get; set; }
        [Required]
        [Display(Name = "Creatina")]
        public string Creatina { get; set; }
        [Required]
        [Display(Name = "Colesterol total")]
        public string ColesterolTotal { get; set; }
    }
}