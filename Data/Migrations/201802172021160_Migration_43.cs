namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_43 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReasignacionHistorial",
                c => new
                    {
                        ReasignacionHistorialId = c.Int(nullable: false, identity: true),
                        ReasignadoPorId = c.Int(nullable: false),
                        ReasignadoAId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReasignacionHistorialId)
                .ForeignKey("dbo.User", t => t.ReasignadoAId)
                .ForeignKey("dbo.User", t => t.ReasignadoPorId)
                .Index(t => t.ReasignadoPorId)
                .Index(t => t.ReasignadoAId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReasignacionHistorial", "ReasignadoPorId", "dbo.User");
            DropForeignKey("dbo.ReasignacionHistorial", "ReasignadoAId", "dbo.User");
            DropIndex("dbo.ReasignacionHistorial", new[] { "ReasignadoAId" });
            DropIndex("dbo.ReasignacionHistorial", new[] { "ReasignadoPorId" });
            DropTable("dbo.ReasignacionHistorial");
        }
    }
}
