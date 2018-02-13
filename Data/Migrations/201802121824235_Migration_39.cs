namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_39 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "UltimaGestion", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "UltimaGestion");
        }
    }
}
