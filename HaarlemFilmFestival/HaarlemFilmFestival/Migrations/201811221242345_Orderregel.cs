namespace HaarlemFilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orderregel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orderregels",
                c => new
                    {
                        OrderregelId = c.Int(nullable: false, identity: true),
                        Regelaantal = c.Int(nullable: false),
                        Prijs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderregelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orderregels");
        }
    }
}
