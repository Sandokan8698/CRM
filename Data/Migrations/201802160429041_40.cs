namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _40 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tarea", "Descripcion", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarea", "Descripcion", c => c.String(maxLength: 255));
        }
    }
}
