namespace PeugeotWorkFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fournisseur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom_frn = c.String(nullable: false, maxLength: 100),
                        Adress_frn = c.String(nullable: false, maxLength: 500),
                        Mail_frn = c.String(nullable: false),
                        Tel_frn = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.AspNetUsers", "Tel", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Tel", c => c.Int(nullable: false));
            DropTable("dbo.Fournisseurs");
        }
    }
}
