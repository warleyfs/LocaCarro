namespace LocaCarro.Infraestructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTarifa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tarifa", "Cliente_Id", "dbo.Cliente");
            DropIndex("dbo.Tarifa", new[] { "Cliente_Id" });
            AddColumn("dbo.Tarifa", "DiaUtil", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tarifa", "Fidelizacao", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tarifa", "TarifaReduzida");
            DropColumn("dbo.Tarifa", "Cliente_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarifa", "Cliente_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Tarifa", "TarifaReduzida", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tarifa", "Fidelizacao");
            DropColumn("dbo.Tarifa", "DiaUtil");
            CreateIndex("dbo.Tarifa", "Cliente_Id");
            AddForeignKey("dbo.Tarifa", "Cliente_Id", "dbo.Cliente", "Id");
        }
    }
}
