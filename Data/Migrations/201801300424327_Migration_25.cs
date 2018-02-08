namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarea", "Prioridad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarea", "Prioridad");
        }
    }
}
