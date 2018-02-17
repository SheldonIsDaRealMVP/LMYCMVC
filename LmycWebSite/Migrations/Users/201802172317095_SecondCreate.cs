namespace LmycWebSite.Migrations.Users
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondCreate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Boats", name: "CreatedBy_Id", newName: "CreatedBy");
            RenameIndex(table: "dbo.Boats", name: "IX_CreatedBy_Id", newName: "IX_CreatedBy");
            DropColumn("dbo.Boats", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boats", "Id", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Boats", name: "IX_CreatedBy", newName: "IX_CreatedBy_Id");
            RenameColumn(table: "dbo.Boats", name: "CreatedBy", newName: "CreatedBy_Id");
        }
    }
}
