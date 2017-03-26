namespace PeugeotWorkFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class depacha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        Des = c.String(nullable: false, maxLength: 500),
                        Categ = c.String(nullable: false, maxLength: 500),
                        DtAcha = c.DateTime(nullable: false),
                        Creation = c.Boolean(nullable: false),
                        LieuLiv = c.String(nullable: false, maxLength: 500),
                        Imp = c.String(nullable: false, maxLength: 500),
                        Qte = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Dep = c.String(nullable: false, maxLength: 100),
                        Budget = c.Single(nullable: false),
                        Depense = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Achats", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Achats", new[] { "DepartmentID" });
            DropTable("dbo.Departments");
            DropTable("dbo.Achats");
        }
    }
}
