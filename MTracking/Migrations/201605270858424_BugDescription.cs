namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BugDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bugs", "Description", c => c.String());
            AddColumn("dbo.Bugs", "ReproductionSteps", c => c.String());
            AddColumn("dbo.Bugs", "ExpectedResult", c => c.String());
            AddColumn("dbo.Bugs", "ActualResult", c => c.String());
            DropColumn("dbo.Bugs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bugs", "Name", c => c.String());
            DropColumn("dbo.Bugs", "ActualResult");
            DropColumn("dbo.Bugs", "ExpectedResult");
            DropColumn("dbo.Bugs", "ReproductionSteps");
            DropColumn("dbo.Bugs", "Description");
        }
    }

    public partial class CopyOfBugDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bugs", "Description", c => c.String());
            AddColumn("dbo.Bugs", "ReproductionSteps", c => c.String());
            AddColumn("dbo.Bugs", "ExpectedResult", c => c.String());
            AddColumn("dbo.Bugs", "ActualResult", c => c.String());
            DropColumn("dbo.Bugs", "Name");
        }

        public override void Down()
        {
            AddColumn("dbo.Bugs", "Name", c => c.String());
            DropColumn("dbo.Bugs", "ActualResult");
            DropColumn("dbo.Bugs", "ExpectedResult");
            DropColumn("dbo.Bugs", "ReproductionSteps");
            DropColumn("dbo.Bugs", "Description");
        }
    }
}
