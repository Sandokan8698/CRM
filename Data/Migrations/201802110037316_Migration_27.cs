namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "Descripcion", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Producto", "Descripcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producto", "Descripcion", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Producto", "Descripcion");
        }
    }
}
