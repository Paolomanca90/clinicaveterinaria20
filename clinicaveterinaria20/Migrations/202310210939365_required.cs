namespace clinicaveterinaria20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prodotti", "invendita", c => c.Boolean());
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prodotti", "invendita", c => c.Boolean(nullable: false));
        }
    }
}
