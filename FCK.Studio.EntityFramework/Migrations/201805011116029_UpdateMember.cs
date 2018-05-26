namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "UserID", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "UserID");
        }
    }
}
