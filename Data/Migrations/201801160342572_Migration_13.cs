namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Ruc = c.String(maxLength: 15),
                        Telefono = c.String(maxLength: 10),
                        Direccion = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Division = c.String(maxLength: 50),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        VendedorId = c.Int(),
                        Vendedor_PerfilId = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Vendedor", t => t.Vendedor_PerfilId)
                .Index(t => t.Vendedor_PerfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "Vendedor_PerfilId", "dbo.Vendedor");
            DropIndex("dbo.Cliente", new[] { "Vendedor_PerfilId" });
            DropTable("dbo.Cliente");
        }
    }
}
