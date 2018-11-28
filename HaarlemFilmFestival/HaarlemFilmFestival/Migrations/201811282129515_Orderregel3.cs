namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orderregel3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orderregels", "Tickettype", c => c.String());
            AddColumn("dbo.Orderregels", "Opmerkingen", c => c.String());
            DropColumn("dbo.Orderregels", "Prijs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orderregels", "Prijs", c => c.Int(nullable: false));
            DropColumn("dbo.Orderregels", "Opmerkingen");
            DropColumn("dbo.Orderregels", "Tickettype");
        }
    }
}
