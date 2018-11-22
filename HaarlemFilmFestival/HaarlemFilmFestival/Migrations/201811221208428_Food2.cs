namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Food2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Restaurant = c.String(),
                        Rang = c.String(),
                        Rangprijs = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Foods");
        }
    }
}
