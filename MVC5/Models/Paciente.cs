using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appProyectoFinal.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Contrasenna { get; set; }
        public string tipoUsuario { get; set; }
    }
}