namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacto", "TomaDecision", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacto", "TomaDecision");
        }
    }
}
