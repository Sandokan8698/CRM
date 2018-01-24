namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oportunidad", "ContactoVentaId", c => c.Int(nullable: false));
            AddColumn("dbo.Oportunidad", "TomadorDescicionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Oportunidad", "ContactoVentaId");
            CreateIndex("dbo.Oportunidad", "TomadorDescicionId");
            AddForeignKey("dbo.Oportunidad", "ContactoVentaId", "dbo.Contacto", "ContactoId");
            AddForeignKey("dbo.Oportunidad", "TomadorDescicionId", "dbo.Contacto", "ContactoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oportunidad", "TomadorDescicionId", "dbo.Contacto");
            DropForeignKey("dbo.Oportunidad", "ContactoVentaId", "dbo.Contacto");
            DropIndex("dbo.Oportunidad", new[] { "TomadorDescicionId" });
            DropIndex("dbo.Oportunidad", new[] { "ContactoVentaId" });
            DropColumn("dbo.Oportunidad", "TomadorDescicionId");
            DropColumn("dbo.Oportunidad", "ContactoVentaId");
        }
    }
}
