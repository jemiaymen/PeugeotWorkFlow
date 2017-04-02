namespace PeugeotWorkFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notiffixed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AchatInNotifications", "State", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AchatInNotifications", "State");
        }
    }
}
