namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 15),
                        PasswordHash = c.String(nullable: false),
                        SecurityStamp = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ExternalLogin",
                c => new
                    {
                        ExternalLoginId = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ExternalLoginId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Tarea",
                c => new
                    {
                        TareaId = c.Int(nullable: false, identity: true),
                        CreadoPorId = c.Guid(nullable: false),
                        AsignadoAId = c.Guid(nullable: false),
                        AsignadoA_UserId = c.Guid(),
                        CreadoPor_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.TareaId)
                .ForeignKey("dbo.User", t => t.AsignadoA_UserId)
                .ForeignKey("dbo.User", t => t.CreadoPor_UserId)
                .ForeignKey("dbo.User", t => t.AsignadoAId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.CreadoPorId, cascadeDelete: false)
                .Index(t => t.CreadoPorId)
                .Index(t => t.AsignadoAId)
                .Index(t => t.AsignadoA_UserId)
                .Index(t => t.CreadoPor_UserId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Role_RoleId = c.Guid(nullable: false),
                        User_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId })
                .ForeignKey("dbo.Role", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Gerente",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendedor", "UserId", "dbo.User");
            DropForeignKey("dbo.Gerente", "UserId", "dbo.User");
            DropForeignKey("dbo.Group", "UserId", "dbo.User");
            DropForeignKey("dbo.Tarea", "CreadoPorId", "dbo.User");
            DropForeignKey("dbo.Tarea", "AsignadoAId", "dbo.User");
            DropForeignKey("dbo.Tarea", "CreadoPor_UserId", "dbo.User");
            DropForeignKey("dbo.Tarea", "AsignadoA_UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.ExternalLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.Claim", "UserId", "dbo.User");
            DropIndex("dbo.Vendedor", new[] { "UserId" });
            DropIndex("dbo.Gerente", new[] { "UserId" });
            DropIndex("dbo.RoleUser", new[] { "User_UserId" });
            DropIndex("dbo.RoleUser", new[] { "Role_RoleId" });
            DropIndex("dbo.Group", new[] { "UserId" });
            DropIndex("dbo.Tarea", new[] { "CreadoPor_UserId" });
            DropIndex("dbo.Tarea", new[] { "AsignadoA_UserId" });
            DropIndex("dbo.Tarea", new[] { "AsignadoAId" });
            DropIndex("dbo.Tarea", new[] { "CreadoPorId" });
            DropIndex("dbo.ExternalLogin", new[] { "UserId" });
            DropIndex("dbo.Claim", new[] { "UserId" });
            DropTable("dbo.Vendedor");
            DropTable("dbo.Gerente");
            DropTable("dbo.RoleUser");
            DropTable("dbo.Group");
            DropTable("dbo.Tarea");
            DropTable("dbo.Role");
            DropTable("dbo.ExternalLogin");
            DropTable("dbo.User");
            DropTable("dbo.Claim");
        }
    }
}
