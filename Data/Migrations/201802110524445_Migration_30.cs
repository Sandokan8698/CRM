namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarea", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tarea", "ClienteId");
            AddForeignKey("dbo.Tarea", "ClienteId", "dbo.Cliente", "ClienteId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarea", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Tarea", new[] { "ClienteId" });
            DropColumn("dbo.Tarea", "ClienteId");
        }
    }
}
