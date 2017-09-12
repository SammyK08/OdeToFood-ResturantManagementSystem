namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resturants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResturantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        ResturantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resturants", t => t.ResturantId, cascadeDelete: true)
                .Index(t => t.ResturantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResturantReviews", "ResturantId", "dbo.Resturants");
            DropIndex("dbo.ResturantReviews", new[] { "ResturantId" });
            DropTable("dbo.ResturantReviews");
            DropTable("dbo.Resturants");
        }
    }
}
