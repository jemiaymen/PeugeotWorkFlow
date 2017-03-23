namespace PeugeotWorkFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lbl = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryInFournisseurs",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        FournisseurID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryID, t.FournisseurID })
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Fournisseurs", t => t.FournisseurID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.FournisseurID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryInFournisseurs", "FournisseurID", "dbo.Fournisseurs");
            DropForeignKey("dbo.CategoryInFournisseurs", "CategoryID", "dbo.Categories");
            DropIndex("dbo.CategoryInFournisseurs", new[] { "FournisseurID" });
            DropIndex("dbo.CategoryInFournisseurs", new[] { "CategoryID" });
            DropTable("dbo.CategoryInFournisseurs");
            DropTable("dbo.Categories");
        }
    }
}
