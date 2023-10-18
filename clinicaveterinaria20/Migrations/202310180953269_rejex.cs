namespace clinicaveterinaria20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rejex : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Armadietti", "codice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Armadietti", "codice", c => c.String(nullable: false));
        }
    }
}
