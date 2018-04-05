namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Icons", c => c.String(maxLength: 12));
            AddColumn("dbo.Categories", "Intro", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Intro");
            DropColumn("dbo.Categories", "Icons");
        }
    }
}
