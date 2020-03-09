namespace Autorennstall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 55),
                        LName = c.String(nullable: false, maxLength: 55),
                        Active = c.Boolean(nullable: false),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DriverID)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 55),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        RepairID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(nullable: false, maxLength: 55),
                        RepairTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepairID)
                .ForeignKey("dbo.RepairTypes", t => t.RepairTypeID, cascadeDelete: true)
                .Index(t => t.RepairTypeID);
            
            CreateTable(
                "dbo.RepairTypes",
                c => new
                    {
                        RepairTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 55),
                    })
                .PrimaryKey(t => t.RepairTypeID);
            
            CreateTable(
                "dbo.RepairSpareparts",
                c => new
                    {
                        RepairSparepartID = c.Int(nullable: false, identity: true),
                        RepairID = c.Int(nullable: false),
                        SparepartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepairSparepartID)
                .ForeignKey("dbo.Repairs", t => t.RepairID, cascadeDelete: true)
                .ForeignKey("dbo.Spareparts", t => t.SparepartID, cascadeDelete: true)
                .Index(t => t.RepairID)
                .Index(t => t.SparepartID);
            
            CreateTable(
                "dbo.Spareparts",
                c => new
                    {
                        SparepartID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 55),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SparepartID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RepairSpareparts", "SparepartID", "dbo.Spareparts");
            DropForeignKey("dbo.RepairSpareparts", "RepairID", "dbo.Repairs");
            DropForeignKey("dbo.Repairs", "RepairTypeID", "dbo.RepairTypes");
            DropForeignKey("dbo.Drivers", "TeamID", "dbo.Teams");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RepairSpareparts", new[] { "SparepartID" });
            DropIndex("dbo.RepairSpareparts", new[] { "RepairID" });
            DropIndex("dbo.Repairs", new[] { "RepairTypeID" });
            DropIndex("dbo.Drivers", new[] { "TeamID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Spareparts");
            DropTable("dbo.RepairSpareparts");
            DropTable("dbo.RepairTypes");
            DropTable("dbo.Repairs");
            DropTable("dbo.Teams");
            DropTable("dbo.Drivers");
        }
    }
}
