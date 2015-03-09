using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appProyectoFinal.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string Nombre_Usuario { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Contrasenna { get; set; }
    }
}