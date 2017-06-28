namespace FirmAdministartion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityUserProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.Inventories", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Inventories", "ApplicationUserId");
            AddForeignKey("dbo.Inventories", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Inventories", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Inventories", "ApplicationUserId", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
