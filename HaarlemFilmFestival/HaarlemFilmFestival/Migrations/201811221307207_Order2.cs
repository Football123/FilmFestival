namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "KlantId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderregelId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderregelId");
            DropColumn("dbo.Orders", "KlantId");
        }
    }
}
