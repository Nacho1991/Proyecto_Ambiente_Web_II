using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appProyectoFinal.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Contrasenna { get; set; }
        [Required]
        [Display(Name = "Tipo de usuario")]
        public string tipoUsuario { get; set; }
    }
}