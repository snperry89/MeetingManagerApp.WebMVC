namespace MeetingManagerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMuteRule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meeting", "MuteRule", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meeting", "MuteRule");
        }
    }
}
