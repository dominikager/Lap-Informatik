namespace SkiVerleih.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsRentedStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentedArticles", "IsRented", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentedArticles", "IsRented");
        }
    }
}
