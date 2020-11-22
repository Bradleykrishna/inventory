namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncomingItems",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemType = c.String(nullable: false),
                        ItemName = c.String(nullable: false),
                        ItemDescription = c.String(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemType = c.String(nullable: false),
                        ItemName = c.String(nullable: false),
                        ItemDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.OutgoingItems",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemType = c.String(nullable: false),
                        ItemName = c.String(nullable: false),
                        ItemDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OutgoingItems");
            DropTable("dbo.Items");
            DropTable("dbo.IncomingItems");
        }
    }
}
