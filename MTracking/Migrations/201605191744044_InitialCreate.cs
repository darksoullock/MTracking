namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Picture = c.String(),
                        CountryId = c.Int(nullable: false),
                        Info = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.dic_Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.dic_Statuses", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.CompanyId)
                .Index(t => t.StatusId)
                .Index(t => t.CountryId)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.dic_Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.dic_Statuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Users", "StatusId", "dbo.dic_Statuses");
            DropForeignKey("dbo.Users", "CountryId", "dbo.dic_Countries");
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "Project_Id" });
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropIndex("dbo.Users", new[] { "StatusId" });
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropTable("dbo.Projects");
            DropTable("dbo.dic_Statuses");
            DropTable("dbo.dic_Countries");
            DropTable("dbo.Users");
            DropTable("dbo.Companies");
        }
    }
}
