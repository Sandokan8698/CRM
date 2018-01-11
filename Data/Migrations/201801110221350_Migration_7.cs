namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarea", "Fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tarea", "Descripcion", c => c.String(maxLength: 255));
            AddColumn("dbo.Tarea", "TipoSeguimiento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarea", "TipoSeguimiento");
            DropColumn("dbo.Tarea", "Descripcion");
            DropColumn("dbo.Tarea", "Fecha");
        }
    }
}
