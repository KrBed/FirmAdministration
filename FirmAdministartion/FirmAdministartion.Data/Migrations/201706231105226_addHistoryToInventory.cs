namespace FirmAdministartion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHistoryToInventory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryHistories", "InventoryId", "dbo.Inventories");
            AddColumn("dbo.Inventories", "HistoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventories", "HistoryId");
            AddForeignKey("dbo.Inventories", "HistoryId", "dbo.Histories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InventoryHistories", "InventoryId", "dbo.Inventories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryHistories", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Inventories", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Inventories", new[] { "HistoryId" });
            DropColumn("dbo.Inventories", "HistoryId");
            AddForeignKey("dbo.InventoryHistories", "InventoryId", "dbo.Inventories", "Id", cascadeDelete: true);
        }
    }
}
