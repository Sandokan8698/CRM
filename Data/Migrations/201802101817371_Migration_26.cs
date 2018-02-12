namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_26 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oportunidad", "TomadorDescicionId", "dbo.Contacto");
            DropIndex("dbo.Oportunidad", new[] { "TomadorDescicionId" });
            CreateTable(
                "dbo.TomaDescicion",
                c => new
                    {
                        TomaDescicionId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Cargo = c.String(nullable: false, maxLength: 50),
                        Celular = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.TomaDescicionId)
                .ForeignKey("dbo.Cliente", t => t.TomaDescicionId)
                .Index(t => t.TomaDescicionId);
            
            DropColumn("dbo.Contacto", "TomaDecision");
            DropColumn("dbo.Oportunidad", "TomadorDescicionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oportunidad", "TomadorDescicionId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacto", "TomaDecision", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.TomaDescicion", "TomaDescicionId", "dbo.Cliente");
            DropIndex("dbo.TomaDescicion", new[] { "TomaDescicionId" });
            DropTable("dbo.TomaDescicion");
            CreateIndex("dbo.Oportunidad", "TomadorDescicionId");
            AddForeignKey("dbo.Oportunidad", "TomadorDescicionId", "dbo.Contacto", "ContactoId");
        }
    }
}
