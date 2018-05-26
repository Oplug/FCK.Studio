namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityHouses1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "SaleStatus", c => c.String(maxLength: 8));
            AddColumn("dbo.Houses", "BuildStatus", c => c.String(maxLength: 8));
            AddColumn("dbo.Houses", "Owner4", c => c.String(maxLength: 10));
            AddColumn("dbo.Houses", "Owner5", c => c.String(maxLength: 10));
            AddColumn("dbo.Houses", "Memo", c => c.String(maxLength: 50));
            AddColumn("dbo.Houses", "ShortChar1", c => c.String(maxLength: 50));
            AddColumn("dbo.Houses", "ShortChar2", c => c.String(maxLength: 50));
            DropColumn("dbo.Houses", "IsSaled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "IsSaled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Houses", "ShortChar2");
            DropColumn("dbo.Houses", "ShortChar1");
            DropColumn("dbo.Houses", "Memo");
            DropColumn("dbo.Houses", "Owner5");
            DropColumn("dbo.Houses", "Owner4");
            DropColumn("dbo.Houses", "BuildStatus");
            DropColumn("dbo.Houses", "SaleStatus");
        }
    }
}
