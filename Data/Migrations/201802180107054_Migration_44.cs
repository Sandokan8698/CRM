namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReasignacionHistorial", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReasignacionHistorial", "ClienteId");
            AddForeignKey("dbo.ReasignacionHistorial", "ClienteId", "dbo.Cliente", "ClienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReasignacionHistorial", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.ReasignacionHistorial", new[] { "ClienteId" });
            DropColumn("dbo.ReasignacionHistorial", "ClienteId");
        }
    }
}
