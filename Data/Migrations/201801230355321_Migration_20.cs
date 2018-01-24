namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oportunidad",
                c => new
                    {
                        OportunidadId = c.Int(nullable: false, identity: true),
                        AsesorId = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        ClienteId = c.Int(nullable: false),
                        TipoCartera = c.Int(nullable: false),
                        LineaNegocioId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PVU = c.Decimal(nullable: false, storeType: "money"),
                        Potencial = c.Decimal(nullable: false, storeType: "money"),
                        EtapaId = c.Int(nullable: false),
                        ExpectativaVenta = c.Decimal(nullable: false, storeType: "money"),
                        ExpectativaAsesor = c.Decimal(nullable: false, storeType: "money"),
                        FechaPrevistaCierre = c.DateTime(nullable: false, storeType: "date"),
                        TipoGestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OportunidadId)
                .ForeignKey("dbo.Vendedor", t => t.AsesorId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Etapa", t => t.EtapaId, cascadeDelete: true)
                .ForeignKey("dbo.LineaNegocio", t => t.LineaNegocioId, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoGestion", t => t.TipoGestionId, cascadeDelete: true)
                .Index(t => t.AsesorId)
                .Index(t => t.ClienteId)
                .Index(t => t.LineaNegocioId)
                .Index(t => t.ProductoId)
                .Index(t => t.EtapaId)
                .Index(t => t.TipoGestionId);
            
            CreateTable(
                "dbo.Etapa",
                c => new
                    {
                        EtapaId = c.Int(nullable: false, identity: true),
                        Porciento = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EtapaId);
            
            CreateTable(
                "dbo.LineaNegocio",
                c => new
                    {
                        LineaNegocioId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.LineaNegocioId);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductoId);
            
            CreateTable(
                "dbo.TipoGestion",
                c => new
                    {
                        TipoGestionId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TipoGestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oportunidad", "TipoGestionId", "dbo.TipoGestion");
            DropForeignKey("dbo.Oportunidad", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Oportunidad", "LineaNegocioId", "dbo.LineaNegocio");
            DropForeignKey("dbo.Oportunidad", "EtapaId", "dbo.Etapa");
            DropForeignKey("dbo.Oportunidad", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Oportunidad", "AsesorId", "dbo.Vendedor");
            DropIndex("dbo.Oportunidad", new[] { "TipoGestionId" });
            DropIndex("dbo.Oportunidad", new[] { "EtapaId" });
            DropIndex("dbo.Oportunidad", new[] { "ProductoId" });
            DropIndex("dbo.Oportunidad", new[] { "LineaNegocioId" });
            DropIndex("dbo.Oportunidad", new[] { "ClienteId" });
            DropIndex("dbo.Oportunidad", new[] { "AsesorId" });
            DropTable("dbo.TipoGestion");
            DropTable("dbo.Producto");
            DropTable("dbo.LineaNegocio");
            DropTable("dbo.Etapa");
            DropTable("dbo.Oportunidad");
        }
    }
}
