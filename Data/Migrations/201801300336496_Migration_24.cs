namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "TiPoCliente", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "TiPoCliente");
        }
    }
}
