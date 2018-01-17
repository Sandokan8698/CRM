namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Provincia", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Cliente", "Ciudad", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Cliente", "Sector", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Cliente", "DescripcionSector", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Cliente", "Ruc", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "Ruc", c => c.String(maxLength: 15));
            DropColumn("dbo.Cliente", "DescripcionSector");
            DropColumn("dbo.Cliente", "Sector");
            DropColumn("dbo.Cliente", "Ciudad");
            DropColumn("dbo.Cliente", "Provincia");
        }
    }
}
