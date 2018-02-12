namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cliente", "UserId");
            AddForeignKey("dbo.Cliente", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            DropColumn("dbo.Cliente", "VendedorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "VendedorId", c => c.Int());
            DropForeignKey("dbo.Cliente", "UserId", "dbo.User");
            DropIndex("dbo.Cliente", new[] { "UserId" });
            DropColumn("dbo.Cliente", "UserId");
        }
    }
}
