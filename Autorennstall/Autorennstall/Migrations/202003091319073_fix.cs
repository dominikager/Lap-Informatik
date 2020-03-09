namespace Autorennstall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Repairs", "DriverID", c => c.Int(nullable: false));
            CreateIndex("dbo.Repairs", "DriverID");
            AddForeignKey("dbo.Repairs", "DriverID", "dbo.Drivers", "DriverID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "DriverID", "dbo.Drivers");
            DropIndex("dbo.Repairs", new[] { "DriverID" });
            DropColumn("dbo.Repairs", "DriverID");
        }
    }
}
