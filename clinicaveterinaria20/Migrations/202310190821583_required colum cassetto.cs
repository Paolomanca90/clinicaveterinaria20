namespace clinicaveterinaria20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredcolumcassetto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Armadietti", "codice", c => c.String(nullable: false));
            AddColumn("dbo.Prodotti", "invendita", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Prodotti", "nome", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Prodotti", "tipologia", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Prodotti", "quantita", c => c.Int(nullable: false));
            AlterColumn("dbo.Prodotti", "costo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prodotti", "costo", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Prodotti", "quantita", c => c.Int());
            AlterColumn("dbo.Prodotti", "tipologia", c => c.Boolean());
            AlterColumn("dbo.Prodotti", "nome", c => c.String(maxLength: 200));
            DropColumn("dbo.Prodotti", "invendita");
            DropColumn("dbo.Armadietti", "codice");
        }
    }
}
