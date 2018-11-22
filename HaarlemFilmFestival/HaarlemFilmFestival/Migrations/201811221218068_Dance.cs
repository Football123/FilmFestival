namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dances",
                c => new
                    {
                        DanceId = c.Int(nullable: false, identity: true),
                        Artist = c.String(),
                        Session = c.String(),
                    })
                .PrimaryKey(t => t.DanceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dances");
        }
    }
}
