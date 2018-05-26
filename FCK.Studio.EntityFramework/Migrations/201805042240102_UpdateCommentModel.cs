namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCommentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ModelId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "ModelId");
        }
    }
}
