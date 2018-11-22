namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocatieId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Adres = c.String(),
                        Postcode = c.String(),
                        Telefoonnummer = c.Int(nullable: false),
                        Capaciteit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocatieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
