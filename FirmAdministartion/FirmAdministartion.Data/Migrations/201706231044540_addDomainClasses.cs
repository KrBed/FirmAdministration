namespace FirmAdministartion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDomainClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignDate = c.DateTime(),
                        RemoveDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Type_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InventoryTypes", t => t.Type_Id, cascadeDelete: true)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.InventoryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InventoryHistories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false),
                        HistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InventoryId, t.HistoryId })
                .ForeignKey("dbo.Histories", t => t.HistoryId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.HistoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryHistories", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.InventoryHistories", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Inventories", "Type_Id", "dbo.InventoryTypes");
            DropIndex("dbo.InventoryHistories", new[] { "HistoryId" });
            DropIndex("dbo.InventoryHistories", new[] { "InventoryId" });
            DropIndex("dbo.Inventories", new[] { "Type_Id" });
            DropTable("dbo.InventoryHistories");
            DropTable("dbo.InventoryTypes");
            DropTable("dbo.Inventories");
            DropTable("dbo.Histories");
        }
    }
}
