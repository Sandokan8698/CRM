namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perfil", "Ocupacion", c => c.String(maxLength: 15));
            AddColumn("dbo.Perfil", "Descripcion", c => c.String(maxLength: 15));
            AddColumn("dbo.Perfil", "Apellidos", c => c.String(maxLength: 15));
            AddColumn("dbo.Tarea", "Identificador", c => c.String(maxLength: 20));
            DropColumn("dbo.Vendedor", "PefilId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendedor", "PefilId", c => c.Int(nullable: false));
            DropColumn("dbo.Tarea", "Identificador");
            DropColumn("dbo.Perfil", "Apellidos");
            DropColumn("dbo.Perfil", "Descripcion");
            DropColumn("dbo.Perfil", "Ocupacion");
        }
    }
}
