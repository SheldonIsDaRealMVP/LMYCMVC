namespace LmycWebSite.Migrations.Boats
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Boats");
            AlterColumn("dbo.Boats", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Boats", "BoatId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Boats", "BoatId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Boats");
            AlterColumn("dbo.Boats", "BoatId", c => c.Int(nullable: false));
            AlterColumn("dbo.Boats", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Boats", "Id");
        }
    }
}
