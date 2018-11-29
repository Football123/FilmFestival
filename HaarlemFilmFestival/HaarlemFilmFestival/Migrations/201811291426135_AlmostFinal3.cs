namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AlmostFinal3 : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Food",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Restaurant_Id = c.Int(),
                    RestaurantId = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Restaurant_Id);

            CreateTable(
                "dbo.Dance",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Theme_Id = c.Int(),
                    ThemeId = c.String(),
                    Artist_Id = c.Int(),
                    ArtistId = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .ForeignKey("dbo.Themes", t => t.Theme_Id)
                .Index(t => t.Id);


            CreateTable(
                "dbo.Historic",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Languages = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id);

            //AlterColumn("dbo.Dance", "Id", c => c.Int(nullable: false));
            //AlterColumn("dbo.Dance", "ThemeId", c => c.Int(nullable: false));
            //AlterColumn("dbo.Dance", "ArtistId", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.Dance", "Id");
            //CreateIndex("dbo.Dance", "Id");
            //CreateIndex("dbo.Dance", "ThemeId");
            //CreateIndex("dbo.Dance", "ArtistId");
            //AddForeignKey("dbo.Dance", "Id", "dbo.Events", "Id");
            //AddForeignKey("dbo.Themes", "Dance_Id", "dbo.Dance", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Themes", "Dance_Id", "dbo.Dance");
            DropForeignKey("dbo.Historic", "Id", "dbo.Events");
            DropForeignKey("dbo.Food", "Id", "dbo.Events");
            DropForeignKey("dbo.Dance", "Id", "dbo.Events");
            DropIndex("dbo.Historic", new[] { "Id" });
            DropIndex("dbo.Food", new[] { "Restaurant_Id" });
            DropIndex("dbo.Food", new[] { "Id" });
            DropIndex("dbo.Dance", new[] { "ArtistId" });
            DropIndex("dbo.Dance", new[] { "ThemeId" });
            DropIndex("dbo.Dance", new[] { "Id" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropPrimaryKey("dbo.Dance");
            AlterColumn("dbo.Dance", "ArtistId", c => c.Int());
            AlterColumn("dbo.Dance", "ThemeId", c => c.Int());
            AlterColumn("dbo.Dance", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Historic");
            DropTable("dbo.Food");
            DropTable("dbo.Events");
            AddPrimaryKey("dbo.Dance", "Id");
            CreateIndex("dbo.Dance", "Restaurant_Id");
            CreateIndex("dbo.Dance", "ArtistId");
            CreateIndex("dbo.Dance", "ThemeId");
            CreateIndex("dbo.Dance", "LocationId");
            AddForeignKey("dbo.Jazz", "Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Themes", "Dance_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.OrderRecords", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Dance", newName: "Events");
        }
    }
}
