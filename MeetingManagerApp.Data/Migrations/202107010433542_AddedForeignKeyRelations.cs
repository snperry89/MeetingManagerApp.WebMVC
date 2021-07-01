namespace MeetingManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meeting", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Meeting", "OrganizationId");
            AddForeignKey("dbo.Meeting", "OrganizationId", "dbo.Organization", "OrganizationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meeting", "OrganizationId", "dbo.Organization");
            DropIndex("dbo.Meeting", new[] { "OrganizationId" });
            DropColumn("dbo.Meeting", "OrganizationId");
        }
    }
}
