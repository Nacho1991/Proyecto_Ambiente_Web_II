using appProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace appProyectoFinal.Contexto
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("DefaultConnection")
        {
        }
        public System.Data.Entity.DbSet<Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<Expediente> Expedientes { get; set; }
        public System.Data.Entity.DbSet<Paciente> Pacientes { get; set; }

        public System.Data.Entity.DbSet<Cita> Citas { get; set; }
    }
}