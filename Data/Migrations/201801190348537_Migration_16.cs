namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "TelefonoConvencional", c => c.String(maxLength: 10));
            AlterColumn("dbo.Cliente", "Telefono", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "Telefono", c => c.String(maxLength: 10));
            DropColumn("dbo.Cliente", "TelefonoConvencional");
        }
    }
}
