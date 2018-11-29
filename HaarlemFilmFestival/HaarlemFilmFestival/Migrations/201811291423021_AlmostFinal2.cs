namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlmostFinal2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jazz",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Band = c.String(),
                        JazzDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("dbo.Events", "Discriminator", c => c.String(maxLength: 128));
            DropColumn("dbo.Events", "Band");
            DropColumn("dbo.Events", "JazzDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "JazzDescription", c => c.String());
            AddColumn("dbo.Events", "Band", c => c.String());
            DropForeignKey("dbo.Jazz", "Id", "dbo.Events");
            DropIndex("dbo.Jazz", new[] { "Id" });
            AlterColumn("dbo.Events", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Jazz");
        }
    }
}
