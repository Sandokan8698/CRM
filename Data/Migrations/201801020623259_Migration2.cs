namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Group", "UserId", "dbo.User");
            DropForeignKey("dbo.Gerente", "UserId", "dbo.User");
            DropForeignKey("dbo.Vendedor", "UserId", "dbo.User");
            DropIndex("dbo.Group", new[] { "UserId" });
            DropIndex("dbo.Gerente", new[] { "UserId" });
            DropIndex("dbo.Vendedor", new[] { "UserId" });
            DropTable("dbo.Group");
            DropTable("dbo.Gerente");
            DropTable("dbo.Vendedor");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Gerente",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateIndex("dbo.Vendedor", "UserId");
            CreateIndex("dbo.Gerente", "UserId");
            CreateIndex("dbo.Group", "UserId");
            AddForeignKey("dbo.Vendedor", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Gerente", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Group", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
