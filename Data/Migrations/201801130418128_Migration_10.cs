namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TareaHistorial",
                c => new
                    {
                        TareaHistorialId = c.Int(nullable: false, identity: true),
                        TareaId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 255),
                        Fecha = c.DateTime(nullable: false),
                        TareaEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TareaHistorialId)
                .ForeignKey("dbo.Tarea", t => t.TareaId, cascadeDelete: true)
                .Index(t => t.TareaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TareaHistorial", "TareaId", "dbo.Tarea");
            DropIndex("dbo.TareaHistorial", new[] { "TareaId" });
            DropTable("dbo.TareaHistorial");
        }
    }
}
