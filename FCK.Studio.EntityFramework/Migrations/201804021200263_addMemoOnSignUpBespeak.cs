namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMemoOnSignUpBespeak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignUpBespeak", "Memo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SignUpBespeak", "Memo");
        }
    }
}
