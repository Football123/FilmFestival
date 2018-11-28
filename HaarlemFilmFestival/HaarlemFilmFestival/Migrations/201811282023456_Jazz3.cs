namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jazz3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "JazzId", c => c.Int());
            AddColumn("dbo.Events", "Band", c => c.String());
            AddColumn("dbo.Events", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Jazzs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Jazzs",
                c => new
                    {
                        JazzId = c.Int(nullable: false, identity: true),
                        Rang = c.String(),
                        Rangprijs = c.Int(nullable: false),
                        Band = c.String(),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JazzId);
            
            DropColumn("dbo.Events", "Discriminator");
            DropColumn("dbo.Events", "Band");
            DropColumn("dbo.Events", "JazzId");
        }
    }
}
