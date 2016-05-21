namespace MTracking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_fk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Users", "CountryId", "dbo.dic_Countries");
            DropForeignKey("dbo.Users", "StatusId", "dbo.dic_Statuses");
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropIndex("dbo.Users", new[] { "StatusId" });
            DropIndex("dbo.Users", new[] { "CountryId" });
            AlterColumn("dbo.Users", "CompanyId", c => c.Int());
            AlterColumn("dbo.Users", "StatusId", c => c.Int());
            AlterColumn("dbo.Users", "CountryId", c => c.Int());
            CreateIndex("dbo.Users", "CompanyId");
            CreateIndex("dbo.Users", "StatusId");
            CreateIndex("dbo.Users", "CountryId");
            AddForeignKey("dbo.Users", "CompanyId", "dbo.Companies", "Id");
            AddForeignKey("dbo.Users", "CountryId", "dbo.dic_Countries", "Id");
            AddForeignKey("dbo.Users", "StatusId", "dbo.dic_Statuses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "StatusId", "dbo.dic_Statuses");
            DropForeignKey("dbo.Users", "CountryId", "dbo.dic_Countries");
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropIndex("dbo.Users", new[] { "StatusId" });
            DropIndex("dbo.Users", new[] { "CompanyId" });
            AlterColumn("dbo.Users", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "StatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "CountryId");
            CreateIndex("dbo.Users", "StatusId");
            CreateIndex("dbo.Users", "CompanyId");
            AddForeignKey("dbo.Users", "StatusId", "dbo.dic_Statuses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "CountryId", "dbo.dic_Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
