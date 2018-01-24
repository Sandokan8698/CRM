namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oportunidad", "Nombre", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oportunidad", "Nombre");
        }
    }
}
