namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orderregel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orderregels", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orderregels", "EventId");
        }
    }
}
