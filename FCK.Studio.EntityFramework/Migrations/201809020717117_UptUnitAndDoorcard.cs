namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptUnitAndDoorcard : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "UnitNum", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "DoorCard", c => c.Int(nullable: false));
            AlterColumn("dbo.Houses", "UnitNum", c => c.Int(nullable: false));
            AlterColumn("dbo.Houses", "DoorCard", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "DoorCard", c => c.String(maxLength: 50));
            AlterColumn("dbo.Houses", "UnitNum", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "DoorCard", c => c.String(maxLength: 20));
            AlterColumn("dbo.Members", "UnitNum", c => c.String(maxLength: 10));
        }
    }
}
