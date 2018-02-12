namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Celular", c => c.String(maxLength: 15));
            DropColumn("dbo.Perfil", "Celular");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Perfil", "Celular", c => c.String(maxLength: 15));
            DropColumn("dbo.User", "Celular");
        }
    }
}
