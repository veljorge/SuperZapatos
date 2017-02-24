namespace SuperZapatos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total_in_Shelf = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total_in_Vault = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Store_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id, cascadeDelete: true)
                .Index(t => t.Store_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Store_Id", "dbo.Stores");
            DropIndex("dbo.Articles", new[] { "Store_Id" });
            DropTable("dbo.Articles");
            DropTable("dbo.Stores");
        }
    }
}
