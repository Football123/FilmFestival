namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Aantal");
            DropColumn("dbo.Orders", "Totaalprijs");
            DropColumn("dbo.Orders", "OrderregelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderregelId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Totaalprijs", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Aantal", c => c.Int(nullable: false));
        }
    }
}
