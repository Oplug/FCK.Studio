namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptHouses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "UnitNum", c => c.String(maxLength: 50));
            AlterColumn("dbo.Houses", "DoorCard", c => c.String(maxLength: 50));
            AlterColumn("dbo.Houses", "Owner", c => c.String(maxLength: 50));
            AlterColumn("dbo.Houses", "Owner2", c => c.String(maxLength: 50));
            AlterColumn("dbo.Houses", "Owner3", c => c.String(maxLength: 50));
            AlterColumn("dbo.Houses", "Owner4", c => c.String(maxLength: 50));
            AlterColumn("dbo.Houses", "Owner5", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "Owner5", c => c.String(maxLength: 10));
            AlterColumn("dbo.Houses", "Owner4", c => c.String(maxLength: 10));
            AlterColumn("dbo.Houses", "Owner3", c => c.String(maxLength: 10));
            AlterColumn("dbo.Houses", "Owner2", c => c.String(maxLength: 10));
            AlterColumn("dbo.Houses", "Owner", c => c.String(maxLength: 10));
            AlterColumn("dbo.Houses", "DoorCard", c => c.String(maxLength: 20));
            AlterColumn("dbo.Houses", "UnitNum", c => c.String(maxLength: 10));
        }
    }
}
