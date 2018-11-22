namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Food3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "EventId");
        }
    }
}
