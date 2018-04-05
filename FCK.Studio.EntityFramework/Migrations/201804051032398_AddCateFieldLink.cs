namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCateFieldLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "LinkUrl", c => c.String(maxLength: 500));
            AlterColumn("dbo.Categories", "Intro", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Intro", c => c.String(maxLength: 500));
            DropColumn("dbo.Categories", "LinkUrl");
        }
    }
}
