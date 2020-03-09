namespace Lagerverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStock : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Stock", c => c.Int(nullable: false));
        }
    }
}
