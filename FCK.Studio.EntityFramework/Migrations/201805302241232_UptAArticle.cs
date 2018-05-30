namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptAArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "LimitSignUp", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "SignUpNums", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "SignUpEndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "SignUpEndTime");
            DropColumn("dbo.Articles", "SignUpNums");
            DropColumn("dbo.Articles", "LimitSignUp");
        }
    }
}
