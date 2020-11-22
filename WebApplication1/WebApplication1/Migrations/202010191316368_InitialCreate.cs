namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clothes",
                c => new
                    {
                        ClothesID = c.Int(nullable: false, identity: true),
                        ClothingType = c.String(nullable: false),
                        ClothingAmount = c.Double(nullable: false),
                        Size = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClothesID);
            
            CreateTable(
                "dbo.IncomingClothes",
                c => new
                    {
                        ClothesID = c.Int(nullable: false, identity: true),
                        ClothingType = c.String(nullable: false),
                        ClothingAmount = c.Double(nullable: false),
                        Size = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClothesID);
            
            CreateTable(
                "dbo.OutgoingClothes",
                c => new
                    {
                        ClothesID = c.Int(nullable: false, identity: true),
                        ClothingType = c.String(nullable: false),
                        ClothingAmount = c.Double(nullable: false),
                        Size = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClothesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OutgoingClothes");
            DropTable("dbo.IncomingClothes");
            DropTable("dbo.Clothes");
        }
    }
}
