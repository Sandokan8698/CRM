namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarea", "TareaEstado", c => c.Int(nullable: false));
            DropColumn("dbo.Tarea", "TipoSeguimiento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarea", "TipoSeguimiento", c => c.Int(nullable: false));
            DropColumn("dbo.Tarea", "TareaEstado");
        }
    }
}
