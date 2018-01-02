namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        PerfilId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PerfilId);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        PerfilId = c.Int(nullable: false),
                        PresuspuestoAsignado = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PerfilId)
                .ForeignKey("dbo.Perfil", t => t.PerfilId)
                .Index(t => t.PerfilId);
            
            AddColumn("dbo.User", "Perfil_PerfilId", c => c.Int());
            CreateIndex("dbo.User", "Perfil_PerfilId");
            AddForeignKey("dbo.User", "Perfil_PerfilId", "dbo.Perfil", "PerfilId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendedor", "PerfilId", "dbo.Perfil");
            DropForeignKey("dbo.User", "Perfil_PerfilId", "dbo.Perfil");
            DropIndex("dbo.Vendedor", new[] { "PerfilId" });
            DropIndex("dbo.User", new[] { "Perfil_PerfilId" });
            DropColumn("dbo.User", "Perfil_PerfilId");
            DropTable("dbo.Vendedor");
            DropTable("dbo.Perfil");
        }
    }
}
