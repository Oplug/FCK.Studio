namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptSignUpModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignUpBespeak", "MemberName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SignUpBespeak", "MemberName");
        }
    }
}
