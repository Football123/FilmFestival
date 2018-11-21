namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jazz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jazzs",
                c => new
                    {
                        JazzId = c.Int(nullable: false, identity: true),
                        Rang = c.String(),
                        Rangprijs = c.Int(nullable: false),
                        Band = c.String(),
                    })
                .PrimaryKey(t => t.JazzId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jazzs");
        }
    }
}
