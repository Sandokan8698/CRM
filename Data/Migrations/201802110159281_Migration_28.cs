namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_28 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SenderoProducto",
                c => new
                    {
                        SenderoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SenderoId, t.ProductoId })
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Sendero", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Sendero",
                c => new
                    {
                        SenderoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SenderoId)
                .ForeignKey("dbo.Cliente", t => t.SenderoId)
                .Index(t => t.SenderoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sendero", "SenderoId", "dbo.Cliente");
            DropForeignKey("dbo.SenderoProducto", "ProductoId", "dbo.Sendero");
            DropForeignKey("dbo.SenderoProducto", "ProductoId", "dbo.Producto");
            DropIndex("dbo.Sendero", new[] { "SenderoId" });
            DropIndex("dbo.SenderoProducto", new[] { "ProductoId" });
            DropTable("dbo.Sendero");
            DropTable("dbo.SenderoProducto");
        }
    }
}
