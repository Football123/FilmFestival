namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Klant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        KlantId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Achternaam = c.String(),
                        Geboortedatum = c.DateTime(nullable: false),
                        Emailadres = c.String(),
                    })
                .PrimaryKey(t => t.KlantId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
