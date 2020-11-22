namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IncomingClothes", "Status", c => c.String(nullable: false));
            AddColumn("dbo.IncomingItems", "ItemAmount", c => c.String(nullable: false));
            AddColumn("dbo.Items", "ItemAmount", c => c.Double(nullable: false));
            AddColumn("dbo.OutgoingItems", "ItemAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OutgoingItems", "ItemAmount");
            DropColumn("dbo.Items", "ItemAmount");
            DropColumn("dbo.IncomingItems", "ItemAmount");
            DropColumn("dbo.IncomingClothes", "Status");
        }
    }
}
