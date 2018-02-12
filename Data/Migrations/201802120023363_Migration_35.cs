namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_35 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Nombre", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.User", "Apellidos", c => c.String(nullable: false, maxLength: 15));
           
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Apellidos", c => c.String(maxLength: 15));
            AlterColumn("dbo.User", "Nombre", c => c.String(maxLength: 15));
        }
    }
}
