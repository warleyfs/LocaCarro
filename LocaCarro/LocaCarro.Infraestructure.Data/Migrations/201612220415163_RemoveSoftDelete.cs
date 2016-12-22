namespace LocaCarro.Infraestructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSoftDelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carro", "ExcluidoEm");
            DropColumn("dbo.Carro", "Excluido");
            DropColumn("dbo.TipoCarro", "ExcluidoEm");
            DropColumn("dbo.TipoCarro", "Excluido");
            DropColumn("dbo.Loja", "ExcluidoEm");
            DropColumn("dbo.Loja", "Excluido");
            DropColumn("dbo.Tarifa", "ExcluidoEm");
            DropColumn("dbo.Tarifa", "Excluido");
            DropColumn("dbo.Cliente", "ExcluidoEm");
            DropColumn("dbo.Cliente", "Excluido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "Excluido", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cliente", "ExcluidoEm", c => c.DateTime());
            AddColumn("dbo.Tarifa", "Excluido", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tarifa", "ExcluidoEm", c => c.DateTime());
            AddColumn("dbo.Loja", "Excluido", c => c.Boolean(nullable: false));
            AddColumn("dbo.Loja", "ExcluidoEm", c => c.DateTime());
            AddColumn("dbo.TipoCarro", "Excluido", c => c.Boolean(nullable: false));
            AddColumn("dbo.TipoCarro", "ExcluidoEm", c => c.DateTime());
            AddColumn("dbo.Carro", "Excluido", c => c.Boolean(nullable: false));
            AddColumn("dbo.Carro", "ExcluidoEm", c => c.DateTime());
        }
    }
}
