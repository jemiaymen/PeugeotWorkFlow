namespace PeugeotWorkFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class avis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AchatID = c.Int(nullable: false),
                        Lbl = c.String(nullable: false, maxLength: 500),
                        Code = c.Int(nullable: false),
                        Accept = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Achats", t => t.AchatID, cascadeDelete: true)
                .Index(t => t.AchatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avis", "AchatID", "dbo.Achats");
            DropIndex("dbo.Avis", new[] { "AchatID" });
            DropTable("dbo.Avis");
        }
    }
}
