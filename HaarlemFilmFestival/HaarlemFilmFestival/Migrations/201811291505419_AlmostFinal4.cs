namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlmostFinal4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StartTime = c.DateTime(nullable: false),
                    EindTime = c.DateTime(nullable: false),
                    Price = c.Double(nullable: false),
                    Discount = c.Double(),
                    Capacity = c.Int(),
                    Description = c.String(),
                    LocationId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true);
        }

        public override void Down()
        {
        }
    }
}
