namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCateModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Icons", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Icons", c => c.String(maxLength: 12));
        }
    }
}
