namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptTenants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenants", "AppDomain", c => c.String(maxLength: 50));
            AddColumn("dbo.Tenants", "WXAppId", c => c.String(maxLength: 50));
            AddColumn("dbo.Tenants", "WXAppSecret", c => c.String(maxLength: 50));
            AddColumn("dbo.Tenants", "CreationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenants", "CreationTime");
            DropColumn("dbo.Tenants", "WXAppSecret");
            DropColumn("dbo.Tenants", "WXAppId");
            DropColumn("dbo.Tenants", "AppDomain");
        }
    }
}
