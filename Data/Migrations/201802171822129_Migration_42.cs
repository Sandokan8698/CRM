namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_42 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cliente", "Ruc", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cliente", new[] { "Ruc" });
        }
    }
}
