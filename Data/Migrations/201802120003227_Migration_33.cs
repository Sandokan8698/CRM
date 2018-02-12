namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_33 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "SecurityStamp", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "SecurityStamp", c => c.String(nullable: false));
        }
    }
}
