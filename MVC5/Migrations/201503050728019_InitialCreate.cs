namespace appProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fecha = c.String(),
                        Estado = c.String(),
                        Cedula_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pacientes", t => t.Cedula_Id)
                .Index(t => t.Cedula_Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Direccion = c.String(),
                        Contrasenna = c.String(),
                        tipoUsuario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expedientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.String(),
                        Hemoglobina = c.String(),
                        AcidoUnico = c.String(),
                        Creatina = c.String(),
                        ColesterolTotal = c.String(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pacientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Nombre_Usuario = c.String(),
                        Contrasenna = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expedientes", "Cliente_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Citas", "Cedula_Id", "dbo.Pacientes");
            DropIndex("dbo.Expedientes", new[] { "Cliente_Id" });
            DropIndex("dbo.Citas", new[] { "Cedula_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Expedientes");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Citas");
        }
    }
}
