namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarea", "TareaTipo", c => c.Int(nullable: false));
            AddColumn("dbo.Tarea", "ProximaTarea", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarea", "ProximaTarea");
            DropColumn("dbo.Tarea", "TareaTipo");
        }
    }
}
