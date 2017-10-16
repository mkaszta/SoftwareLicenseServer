namespace SoftwareLicenseServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apps",
                c => new
                    {
                        App_Id = c.Int(nullable: false, identity: true),
                        App_Name = c.String(maxLength: 100),
                        App_Acronym = c.String(maxLength: 50),
                        App_Version = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.App_Id);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        Ctr_Id = c.Int(nullable: false, identity: true),
                        Ctr_CompanyName = c.String(maxLength: 100),
                        Ctr_NIP = c.String(maxLength: 15),
                        Ctr_Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Ctr_Id);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Lic_Id = c.Int(nullable: false, identity: true),
                        Ctr_Id = c.Int(nullable: false),
                        App_Id = c.Int(nullable: false),
                        Lic_Key = c.String(maxLength: 50),
                        Lic_ActivationStatus = c.Int(nullable: false),
                        Lic_ActivationDate = c.DateTime(nullable: false),
                        Lic_ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Lic_Id)
                .ForeignKey("dbo.Apps", t => t.App_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contractors", t => t.Ctr_Id, cascadeDelete: true)
                .Index(t => t.Ctr_Id)
                .Index(t => t.App_Id);
            
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
                "dbo.Sessions",
                c => new
                    {
                        Ses_Id = c.Int(nullable: false, identity: true),
                        Ctr_Id = c.Int(nullable: false),
                        App_id = c.Int(nullable: false),
                        Ses_StartDate = c.DateTime(nullable: false),
                        Ses_ExpirationDate = c.DateTime(nullable: false),
                        Ses_EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Ses_Id)
                .ForeignKey("dbo.Apps", t => t.App_id, cascadeDelete: true)
                .ForeignKey("dbo.Contractors", t => t.Ctr_Id, cascadeDelete: true)
                .Index(t => t.Ctr_Id)
                .Index(t => t.App_id);
            
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
            DropForeignKey("dbo.Sessions", "Ctr_Id", "dbo.Contractors");
            DropForeignKey("dbo.Sessions", "App_id", "dbo.Apps");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Licenses", "Ctr_Id", "dbo.Contractors");
            DropForeignKey("dbo.Licenses", "App_Id", "dbo.Apps");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sessions", new[] { "App_id" });
            DropIndex("dbo.Sessions", new[] { "Ctr_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Licenses", new[] { "App_Id" });
            DropIndex("dbo.Licenses", new[] { "Ctr_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sessions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Licenses");
            DropTable("dbo.Contractors");
            DropTable("dbo.Apps");
        }
    }
}
