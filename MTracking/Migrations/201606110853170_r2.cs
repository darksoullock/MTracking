namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserProjects", newName: "ProjectUsers");
            DropPrimaryKey("dbo.ProjectUsers");
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        BugId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bugs", t => t.BugId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BugId)
                .Index(t => t.UserId);
            
            AddPrimaryKey("dbo.ProjectUsers", new[] { "Project_Id", "User_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "BugId", "dbo.Bugs");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "BugId" });
            DropPrimaryKey("dbo.ProjectUsers");
            DropTable("dbo.Comments");
            AddPrimaryKey("dbo.ProjectUsers", new[] { "User_Id", "Project_Id" });
            RenameTable(name: "dbo.ProjectUsers", newName: "UserProjects");
        }
    }
}
