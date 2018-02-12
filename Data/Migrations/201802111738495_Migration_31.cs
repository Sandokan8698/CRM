namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perfil", "Celular", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perfil", "Celular");
        }
    }
}
