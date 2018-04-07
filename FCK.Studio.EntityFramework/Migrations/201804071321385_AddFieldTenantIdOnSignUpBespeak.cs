namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldTenantIdOnSignUpBespeak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignUpBespeak", "TenantId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SignUpBespeak", "TenantId");
        }
    }
}
