namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Nombre", c => c.String(maxLength: 15));
            AddColumn("dbo.User", "Apellidos", c => c.String(maxLength: 15));
            AddColumn("dbo.User", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Perfil", "Nombre");
            DropColumn("dbo.Perfil", "Apellidos");
            DropColumn("dbo.Perfil", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Perfil", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Perfil", "Apellidos", c => c.String(maxLength: 15));
            AddColumn("dbo.Perfil", "Nombre", c => c.String(maxLength: 15));
            DropColumn("dbo.User", "Email");
            DropColumn("dbo.User", "Apellidos");
            DropColumn("dbo.User", "Nombre");
        }
    }
}
