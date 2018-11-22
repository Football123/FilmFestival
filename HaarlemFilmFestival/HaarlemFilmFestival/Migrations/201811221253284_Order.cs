namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Betaalmethode = c.String(),
                        Ordertijd = c.DateTime(nullable: false),
                        Betaald = c.Boolean(nullable: false),
                        Code = c.Int(nullable: false),
                        Aantal = c.Int(nullable: false),
                        Totaalprijs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
