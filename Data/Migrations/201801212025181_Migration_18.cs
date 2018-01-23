namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        CiudadId = c.Int(nullable: false, identity: true),
                        ProvinciaId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.CiudadId)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ProvinciaId);
            
            DropColumn("dbo.Cliente", "Provincia");
            DropColumn("dbo.Cliente", "Ciudad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "Ciudad", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Cliente", "Provincia", c => c.String(nullable: false, maxLength: 25));
            DropForeignKey("dbo.Ciudad", "ProvinciaId", "dbo.Provincia");
            DropIndex("dbo.Ciudad", new[] { "ProvinciaId" });
            DropTable("dbo.Provincia");
            DropTable("dbo.Ciudad");
        }
    }
}
