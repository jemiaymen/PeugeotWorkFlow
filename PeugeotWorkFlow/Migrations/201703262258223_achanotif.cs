namespace PeugeotWorkFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class achanotif : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AchatInNotifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AchatID = c.Int(nullable: false),
                        NotificationID = c.Int(nullable: false),
                        DtNotif = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Achats", t => t.AchatID, cascadeDelete: true)
                .ForeignKey("dbo.Notifications", t => t.NotificationID, cascadeDelete: true)
                .Index(t => t.AchatID)
                .Index(t => t.NotificationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AchatInNotifications", "NotificationID", "dbo.Notifications");
            DropForeignKey("dbo.AchatInNotifications", "AchatID", "dbo.Achats");
            DropIndex("dbo.AchatInNotifications", new[] { "NotificationID" });
            DropIndex("dbo.AchatInNotifications", new[] { "AchatID" });
            DropTable("dbo.AchatInNotifications");
        }
    }
}
