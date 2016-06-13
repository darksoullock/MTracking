namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectUsers", newName: "UserProjects");
            DropForeignKey("dbo.Comments", "BugId", "dbo.Bugs");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "BugId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropPrimaryKey("dbo.UserProjects");
            AddColumn("dbo.Users", "Token", c => c.String());
            AddPrimaryKey("dbo.UserProjects", new[] { "User_Id", "Project_Id" });
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropPrimaryKey("dbo.UserProjects");
            DropColumn("dbo.Users", "Token");
            AddPrimaryKey("dbo.UserProjects", new[] { "Project_Id", "User_Id" });
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Comments", "BugId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "BugId", "dbo.Bugs", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.UserProjects", newName: "ProjectUsers");
        }
    }
}
