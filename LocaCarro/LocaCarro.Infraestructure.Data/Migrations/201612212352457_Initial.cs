namespace LocaCarro.Infraestructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carro",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        AlteradoEm = c.DateTime(),
                        ExcluidoEm = c.DateTime(),
                        Tipo_Id = c.Guid(nullable: false),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCarro", t => t.Tipo_Id)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.TipoCarro",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 250),
                        Capacidade = c.Int(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        AlteradoEm = c.DateTime(),
                        ExcluidoEm = c.DateTime(),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Loja",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        AlteradoEm = c.DateTime(),
                        ExcluidoEm = c.DateTime(),
                        Tipo_Id = c.Guid(),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCarro", t => t.Tipo_Id)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.Tarifa",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Valor = c.Double(nullable: false),
                        TarifaReduzida = c.Boolean(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        AlteradoEm = c.DateTime(),
                        ExcluidoEm = c.DateTime(),
                        Cliente_Id = c.Guid(nullable: false),
                        Loja_Id = c.Guid(nullable: false),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .ForeignKey("dbo.Loja", t => t.Loja_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Loja_Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false),
                        Fidelidade = c.Boolean(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        AlteradoEm = c.DateTime(),
                        ExcluidoEm = c.DateTime(),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carro", "Tipo_Id", "dbo.TipoCarro");
            DropForeignKey("dbo.Loja", "Tipo_Id", "dbo.TipoCarro");
            DropForeignKey("dbo.Tarifa", "Loja_Id", "dbo.Loja");
            DropForeignKey("dbo.Tarifa", "Cliente_Id", "dbo.Cliente");
            DropIndex("dbo.Tarifa", new[] { "Loja_Id" });
            DropIndex("dbo.Tarifa", new[] { "Cliente_Id" });
            DropIndex("dbo.Loja", new[] { "Tipo_Id" });
            DropIndex("dbo.Carro", new[] { "Tipo_Id" });
            DropTable("dbo.Cliente");
            DropTable("dbo.Tarifa");
            DropTable("dbo.Loja");
            DropTable("dbo.TipoCarro");
            DropTable("dbo.Carro");
        }
    }
}
