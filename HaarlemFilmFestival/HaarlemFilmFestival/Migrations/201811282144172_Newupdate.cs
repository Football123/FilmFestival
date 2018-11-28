namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KoppelOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderregelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        StopsId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Omschrijving = c.String(),
                    })
                .PrimaryKey(t => t.StopsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stops");
            DropTable("dbo.KoppelOrders");
        }
    }
}
