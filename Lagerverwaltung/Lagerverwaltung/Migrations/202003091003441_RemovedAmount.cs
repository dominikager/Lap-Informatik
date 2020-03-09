namespace Lagerverwaltung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAmount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Processes", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Processes", "Amount", c => c.Int(nullable: false));
        }
    }
}
