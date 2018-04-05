namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdminAndTenant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ControlTenants", c => c.String(maxLength: 200));
            AddColumn("dbo.Tenants", "TenantIntro", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenants", "TenantIntro");
            DropColumn("dbo.Admins", "ControlTenants");
        }
    }
}
