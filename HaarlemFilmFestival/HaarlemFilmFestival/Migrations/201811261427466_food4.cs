namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class food4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Prijs_Adult", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "Prijs_Child", c => c.Int(nullable: false));
            DropColumn("dbo.Foods", "Rang");
            DropColumn("dbo.Foods", "Rangprijs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Rangprijs", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "Rang", c => c.String());
            DropColumn("dbo.Foods", "Prijs_Child");
            DropColumn("dbo.Foods", "Prijs_Adult");
        }
    }
}
