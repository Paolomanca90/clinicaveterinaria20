namespace clinicaveterinaria20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Armadietti", "codice", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Armadietti", "codice", c => c.String());
        }
    }
}
