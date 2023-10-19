namespace clinicaveterinaria20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brand", "piva", c => c.String(maxLength: 11));
            AlterColumn("dbo.Brand", "sedelegale", c => c.String(maxLength: 56));
            AlterColumn("dbo.Brand", "recapito", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Brand", "recapito", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Brand", "sedelegale", c => c.String(nullable: false, maxLength: 56));
            AlterColumn("dbo.Brand", "piva", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
