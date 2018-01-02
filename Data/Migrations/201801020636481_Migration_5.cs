namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gerencia",
                c => new
                    {
                        PerfilId = c.Int(nullable: false),
                        Nuevo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PerfilId)
                .ForeignKey("dbo.Perfil", t => t.PerfilId)
                .Index(t => t.PerfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gerencia", "PerfilId", "dbo.Perfil");
            DropIndex("dbo.Gerencia", new[] { "PerfilId" });
            DropTable("dbo.Gerencia");
        }
    }
}
