namespace appProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "Cedula_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Expedientes", "Cliente_Id", "dbo.Pacientes");
            DropIndex("dbo.Citas", new[] { "Cedula_Id" });
            DropIndex("dbo.Expedientes", new[] { "Cliente_Id" });
            AlterColumn("dbo.Citas", "fecha", c => c.String(nullable: false));
            AlterColumn("dbo.Citas", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.Citas", "Cedula_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Pacientes", "Cedula", c => c.String(nullable: false));
            AlterColumn("dbo.Pacientes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Pacientes", "Apellidos", c => c.String(nullable: false));
            AlterColumn("dbo.Pacientes", "Direccion", c => c.String(nullable: false));
            AlterColumn("dbo.Pacientes", "Contrasenna", c => c.String(nullable: false));
            AlterColumn("dbo.Pacientes", "tipoUsuario", c => c.String(nullable: false));
            AlterColumn("dbo.Expedientes", "FechaCreacion", c => c.String(nullable: false));
            AlterColumn("dbo.Expedientes", "Hemoglobina", c => c.String(nullable: false));
            AlterColumn("dbo.Expedientes", "AcidoUnico", c => c.String(nullable: false));
            AlterColumn("dbo.Expedientes", "Creatina", c => c.String(nullable: false));
            AlterColumn("dbo.Expedientes", "ColesterolTotal", c => c.String(nullable: false));
            AlterColumn("dbo.Expedientes", "Cliente_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Nombre_Usuario", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Contrasenna", c => c.String(nullable: false));
            CreateIndex("dbo.Citas", "Cedula_Id");
            CreateIndex("dbo.Expedientes", "Cliente_Id");
            AddForeignKey("dbo.Citas", "Cedula_Id", "dbo.Pacientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expedientes", "Cliente_Id", "dbo.Pacientes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expedientes", "Cliente_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Citas", "Cedula_Id", "dbo.Pacientes");
            DropIndex("dbo.Expedientes", new[] { "Cliente_Id" });
            DropIndex("dbo.Citas", new[] { "Cedula_Id" });
            AlterColumn("dbo.Usuarios", "Contrasenna", c => c.String());
            AlterColumn("dbo.Usuarios", "Nombre_Usuario", c => c.String());
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String());
            AlterColumn("dbo.Expedientes", "Cliente_Id", c => c.Int());
            AlterColumn("dbo.Expedientes", "ColesterolTotal", c => c.String());
            AlterColumn("dbo.Expedientes", "Creatina", c => c.String());
            AlterColumn("dbo.Expedientes", "AcidoUnico", c => c.String());
            AlterColumn("dbo.Expedientes", "Hemoglobina", c => c.String());
            AlterColumn("dbo.Expedientes", "FechaCreacion", c => c.String());
            AlterColumn("dbo.Pacientes", "tipoUsuario", c => c.String());
            AlterColumn("dbo.Pacientes", "Contrasenna", c => c.String());
            AlterColumn("dbo.Pacientes", "Direccion", c => c.String());
            AlterColumn("dbo.Pacientes", "Apellidos", c => c.String());
            AlterColumn("dbo.Pacientes", "Nombre", c => c.String());
            AlterColumn("dbo.Pacientes", "Cedula", c => c.String());
            AlterColumn("dbo.Citas", "Cedula_Id", c => c.Int());
            AlterColumn("dbo.Citas", "Estado", c => c.String());
            AlterColumn("dbo.Citas", "fecha", c => c.String());
            CreateIndex("dbo.Expedientes", "Cliente_Id");
            CreateIndex("dbo.Citas", "Cedula_Id");
            AddForeignKey("dbo.Expedientes", "Cliente_Id", "dbo.Pacientes", "Id");
            AddForeignKey("dbo.Citas", "Cedula_Id", "dbo.Pacientes", "Id");
        }
    }
}
