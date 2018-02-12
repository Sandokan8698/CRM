namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perfil", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perfil", "Email");
        }
    }
}
