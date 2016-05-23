namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BugStatusId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.dic_BugStatuses", t => t.BugStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.BugStatusId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.dic_BugStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projects", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "OwnerId");
            AddForeignKey("dbo.Projects", "OwnerId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Bugs", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Bugs", "BugStatusId", "dbo.dic_BugStatuses");
            DropIndex("dbo.Bugs", new[] { "ProjectId" });
            DropIndex("dbo.Bugs", new[] { "BugStatusId" });
            DropIndex("dbo.Projects", new[] { "OwnerId" });
            DropColumn("dbo.Projects", "OwnerId");
            DropTable("dbo.dic_BugStatuses");
            DropTable("dbo.Bugs");
        }
    }
}
