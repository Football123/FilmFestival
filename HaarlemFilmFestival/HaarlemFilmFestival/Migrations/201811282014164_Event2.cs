namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Korting", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Capaciteit", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Omschrijving", c => c.String());
            AddColumn("dbo.Events", "LocatieId", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Naam");
            DropColumn("dbo.Events", "Maxaantal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Maxaantal", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Naam", c => c.String());
            DropColumn("dbo.Events", "LocatieId");
            DropColumn("dbo.Events", "Omschrijving");
            DropColumn("dbo.Events", "Capaciteit");
            DropColumn("dbo.Events", "Korting");
        }
    }
}
