namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perfil", "ImagenUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perfil", "ImagenUrl");
        }
    }
}
