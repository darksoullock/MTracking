namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BugsAssignment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bugs", "UserId", c => c.Int());
            CreateIndex("dbo.Bugs", "UserId");
            AddForeignKey("dbo.Bugs", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bugs", "UserId", "dbo.Users");
            DropIndex("dbo.Bugs", new[] { "UserId" });
            DropColumn("dbo.Bugs", "UserId");
        }
    }
}
