namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "ProvinciaId", c => c.Int(nullable: false));
            AddColumn("dbo.Cliente", "CiudadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cliente", "ProvinciaId");
            CreateIndex("dbo.Cliente", "CiudadId");
            AddForeignKey("dbo.Cliente", "CiudadId", "dbo.Ciudad", "CiudadId", cascadeDelete: false);
            AddForeignKey("dbo.Cliente", "ProvinciaId", "dbo.Provincia", "ProvinciaId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Cliente", "CiudadId", "dbo.Ciudad");
            DropIndex("dbo.Cliente", new[] { "CiudadId" });
            DropIndex("dbo.Cliente", new[] { "ProvinciaId" });
            DropColumn("dbo.Cliente", "CiudadId");
            DropColumn("dbo.Cliente", "ProvinciaId");
        }
    }
}
