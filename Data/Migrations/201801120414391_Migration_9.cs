namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarea", "FechaCumplimiento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarea", "FechaCumplimiento");
        }
    }
}
