namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "ClienteEstado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "ClienteEstado");
        }
    }
}
