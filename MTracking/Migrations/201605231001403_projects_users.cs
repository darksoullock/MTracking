namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projects_users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "User_Id", c => c.Int());
            CreateIndex("dbo.Projects", "User_Id");
            AddForeignKey("dbo.Projects", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "User_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropColumn("dbo.Projects", "User_Id");
        }
    }
}
