namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trytowork : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HistoriStops", newName: "HistoricStops");
            DropForeignKey("dbo.Events", "Location_Id1", "dbo.Locations");
            DropForeignKey("dbo.HistoriStops", "Location_Id1", "dbo.Locations");
            DropForeignKey("dbo.OrderRecords", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Dances", "Id", "dbo.Events");
            DropForeignKey("dbo.Foods", "Id", "dbo.Events");
            DropForeignKey("dbo.Historics", "Id", "dbo.Events");
            DropForeignKey("dbo.Jazzs", "Id", "dbo.Events");
            DropIndex("dbo.Events", new[] { "Location_Id1" });
            DropIndex("dbo.HistoricStops", new[] { "Location_Id1" });
            DropColumn("dbo.Events", "Location_Id");
            DropColumn("dbo.HistoricStops", "Location_Id");
            RenameColumn(table: "dbo.Events", name: "Location_Id1", newName: "Location_Id");
            RenameColumn(table: "dbo.HistoricStops", name: "Location_Id1", newName: "Location_Id");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.HistoricStops");
            AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Location_Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Events", "Location_Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.HistoricStops", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.HistoricStops", "Location_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "Id");
            AddPrimaryKey("dbo.HistoricStops", "Id");
            CreateIndex("dbo.Events", "Location_Id");
            CreateIndex("dbo.HistoricStops", "Location_Id");
            AddForeignKey("dbo.Events", "Location_Id", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HistoricStops", "Location_Id", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderRecords", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Dances", "Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Foods", "Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Historics", "Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Jazzs", "Id", "dbo.Events", "Id");
        }
        
        //public override void Down()
        //{
        //    DropForeignKey("dbo.Jazzs", "Id", "dbo.Events");
        //    DropForeignKey("dbo.Historics", "Id", "dbo.Events");
        //    DropForeignKey("dbo.Foods", "Id", "dbo.Events");
        //    DropForeignKey("dbo.Dances", "Id", "dbo.Events");
        //    DropForeignKey("dbo.OrderRecords", "Event_Id", "dbo.Events");
        //    DropForeignKey("dbo.HistoricStops", "Location_Id", "dbo.Locations");
        //    DropForeignKey("dbo.Events", "Location_Id", "dbo.Locations");
        //    DropIndex("dbo.HistoricStops", new[] { "Location_Id" });
        //    DropIndex("dbo.Events", new[] { "Location_Id" });
        //    DropPrimaryKey("dbo.HistoricStops");
        //    DropPrimaryKey("dbo.Events");
        //    AlterColumn("dbo.HistoricStops", "Location_Id", c => c.Int());
        //    AlterColumn("dbo.HistoricStops", "Location_Id", c => c.Int(nullable: false));
        //    AlterColumn("dbo.HistoricStops", "Id", c => c.Int(nullable: false, identity: true));
        //    AlterColumn("dbo.Events", "Location_Id", c => c.Int());
        //    AlterColumn("dbo.Events", "Location_Id", c => c.Int(nullable: false));
        //    AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
        //    AddPrimaryKey("dbo.HistoricStops", "Id");
        //    AddPrimaryKey("dbo.Events", "Id");
        //    RenameColumn(table: "dbo.HistoricStops", name: "Location_Id", newName: "Location_Id1");
        //    RenameColumn(table: "dbo.Events", name: "Location_Id", newName: "Location_Id1");
        //    AddColumn("dbo.HistoricStops", "Location_Id", c => c.Int(nullable: false));
        //    AddColumn("dbo.Events", "Location_Id", c => c.Int(nullable: false));
        //    CreateIndex("dbo.HistoricStops", "Location_Id1");
        //    CreateIndex("dbo.Events", "Location_Id1");
        //    AddForeignKey("dbo.Jazzs", "Id", "dbo.Events", "Id");
        //    AddForeignKey("dbo.Historics", "Id", "dbo.Events", "Id");
        //    AddForeignKey("dbo.Foods", "Id", "dbo.Events", "Id");
        //    AddForeignKey("dbo.Dances", "Id", "dbo.Events", "Id");
        //    AddForeignKey("dbo.OrderRecords", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
        //    AddForeignKey("dbo.HistoriStops", "Location_Id1", "dbo.Locations", "Id");
        //    AddForeignKey("dbo.Events", "Location_Id1", "dbo.Locations", "Id");
        //    RenameTable(name: "dbo.HistoricStops", newName: "HistoriStops");
        //}
    }
}
