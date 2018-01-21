namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        ContactoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Cargo = c.String(nullable: false, maxLength: 50),
                        Celular = c.String(nullable: false, maxLength: 30),
                        Date = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ContactoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacto", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Contacto", new[] { "ClienteId" });
            DropTable("dbo.Contacto");
        }
    }
}
