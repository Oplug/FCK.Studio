namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptEntitySignUpBespeakAddSignIn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignUpBespeak", "SignIn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SignUpBespeak", "SignIn");
        }
    }
}
