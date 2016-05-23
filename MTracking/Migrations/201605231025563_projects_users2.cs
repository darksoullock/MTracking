namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projects_users2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "OwnerId", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "OwnerId" });
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Project_Id" });
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Project_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Project_Id);
            
            AlterColumn("dbo.Projects", "OwnerId", c => c.Int());
            CreateIndex("dbo.Projects", "OwnerId");
            AddForeignKey("dbo.Projects", "OwnerId", "dbo.Users", "Id");
            DropColumn("dbo.Projects", "User_Id");
            DropColumn("dbo.Users", "Project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Project_Id", c => c.Int());
            AddColumn("dbo.Projects", "User_Id", c => c.Int());
            DropForeignKey("dbo.Projects", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "User_Id", "dbo.Users");
            DropIndex("dbo.UserProjects", new[] { "Project_Id" });
            DropIndex("dbo.UserProjects", new[] { "User_Id" });
            DropIndex("dbo.Projects", new[] { "OwnerId" });
            AlterColumn("dbo.Projects", "OwnerId", c => c.Int(nullable: false));
            DropTable("dbo.UserProjects");
            CreateIndex("dbo.Users", "Project_Id");
            CreateIndex("dbo.Projects", "User_Id");
            CreateIndex("dbo.Projects", "OwnerId");
            AddForeignKey("dbo.Projects", "OwnerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Project_Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Projects", "User_Id", "dbo.Users", "Id");
        }
    }
}
