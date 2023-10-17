namespace clinicaveterinaria20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animale",
                c => new
                    {
                        idanimale = c.Int(nullable: false, identity: true),
                        dataRegistrazione = c.DateTime(),
                        nome = c.String(nullable: false, maxLength: 20),
                        tipo = c.String(nullable: false, maxLength: 20),
                        coloreMantello = c.String(nullable: false, maxLength: 20),
                        dataDinascita = c.DateTime(nullable: false),
                        microchip = c.Boolean(nullable: false),
                        nmicrochip = c.String(maxLength: 50),
                        nomeProprietario = c.String(maxLength: 20),
                        cognomeProprietario = c.String(maxLength: 20),
                        datainizioricovero = c.DateTime(),
                        datafinericovero = c.DateTime(),
                        codicefiscale = c.String(maxLength: 16),
                        foto = c.String(),
                    })
                .PrimaryKey(t => t.idanimale);
            
            CreateTable(
                "dbo.Visita",
                c => new
                    {
                        idvisita = c.Int(nullable: false, identity: true),
                        datavisita = c.DateTime(),
                        esame = c.String(nullable: false),
                        cura = c.String(),
                        idanimale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idvisita)
                .ForeignKey("dbo.Animale", t => t.idanimale, cascadeDelete: true)
                .Index(t => t.idanimale);
            
            CreateTable(
                "dbo.Armadietti",
                c => new
                    {
                        idarmadietto = c.Int(nullable: false, identity: true),
                        codice = c.String(),
                    })
                .PrimaryKey(t => t.idarmadietto);
            
            CreateTable(
                "dbo.Cassetto",
                c => new
                    {
                        idcassetto = c.Int(nullable: false, identity: true),
                        ncassetto = c.Int(),
                        idarmadietto = c.Int(),
                    })
                .PrimaryKey(t => t.idcassetto)
                .ForeignKey("dbo.Armadietti", t => t.idarmadietto)
                .Index(t => t.idarmadietto);
            
            CreateTable(
                "dbo.Prodotti",
                c => new
                    {
                        idprodotto = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 200),
                        tipologia = c.Boolean(),
                        foto = c.String(maxLength: 200),
                        quantita = c.Int(),
                        costo = c.Decimal(precision: 18, scale: 2),
                        idcassetto = c.Int(),
                        idutilizzo = c.Int(),
                        idbrand = c.Int(),
                    })
                .PrimaryKey(t => t.idprodotto)
                .ForeignKey("dbo.Brand", t => t.idbrand)
                .ForeignKey("dbo.Cassetto", t => t.idcassetto)
                .ForeignKey("dbo.Utilizzi", t => t.idutilizzo)
                .Index(t => t.idcassetto)
                .Index(t => t.idutilizzo)
                .Index(t => t.idbrand);
            
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        idbrand = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        piva = c.String(nullable: false, maxLength: 11),
                        sedelegale = c.String(nullable: false, maxLength: 56),
                        recapito = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.idbrand);
            
            CreateTable(
                "dbo.Utilizzi",
                c => new
                    {
                        idutilizzo = c.Int(nullable: false, identity: true),
                        descrizioni = c.String(),
                    })
                .PrimaryKey(t => t.idutilizzo);
            
            CreateTable(
                "dbo.Vendita",
                c => new
                    {
                        idvendita = c.Int(nullable: false, identity: true),
                        costotot = c.Decimal(precision: 18, scale: 2),
                        nricetta = c.String(maxLength: 50),
                        quantita = c.Int(),
                        datavendita = c.DateTime(),
                        idprodotto = c.Int(),
                        idcliente = c.Int(),
                    })
                .PrimaryKey(t => t.idvendita)
                .ForeignKey("dbo.Cliente", t => t.idcliente)
                .ForeignKey("dbo.Prodotti", t => t.idprodotto)
                .Index(t => t.idprodotto)
                .Index(t => t.idcliente);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        idcliente = c.Int(nullable: false, identity: true),
                        codicefiscale = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.idcliente);
            
            CreateTable(
                "dbo.Utente",
                c => new
                    {
                        idutente = c.Int(nullable: false, identity: true),
                        username = c.String(maxLength: 50),
                        password = c.String(maxLength: 50),
                        role = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.idutente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendita", "idprodotto", "dbo.Prodotti");
            DropForeignKey("dbo.Vendita", "idcliente", "dbo.Cliente");
            DropForeignKey("dbo.Prodotti", "idutilizzo", "dbo.Utilizzi");
            DropForeignKey("dbo.Prodotti", "idcassetto", "dbo.Cassetto");
            DropForeignKey("dbo.Prodotti", "idbrand", "dbo.Brand");
            DropForeignKey("dbo.Cassetto", "idarmadietto", "dbo.Armadietti");
            DropForeignKey("dbo.Visita", "idanimale", "dbo.Animale");
            DropIndex("dbo.Vendita", new[] { "idcliente" });
            DropIndex("dbo.Vendita", new[] { "idprodotto" });
            DropIndex("dbo.Prodotti", new[] { "idbrand" });
            DropIndex("dbo.Prodotti", new[] { "idutilizzo" });
            DropIndex("dbo.Prodotti", new[] { "idcassetto" });
            DropIndex("dbo.Cassetto", new[] { "idarmadietto" });
            DropIndex("dbo.Visita", new[] { "idanimale" });
            DropTable("dbo.Utente");
            DropTable("dbo.Cliente");
            DropTable("dbo.Vendita");
            DropTable("dbo.Utilizzi");
            DropTable("dbo.Brand");
            DropTable("dbo.Prodotti");
            DropTable("dbo.Cassetto");
            DropTable("dbo.Armadietti");
            DropTable("dbo.Visita");
            DropTable("dbo.Animale");
        }
    }
}
