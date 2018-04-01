namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModSignUpBespeak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignUpBespeak", "PoliticalStatus", c => c.String(maxLength: 10));
            AlterColumn("dbo.SignUpBespeak", "CulturalLevel", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SignUpBespeak", "CulturalLevel", c => c.String());
            DropColumn("dbo.SignUpBespeak", "PoliticalStatus");
        }
    }
}
