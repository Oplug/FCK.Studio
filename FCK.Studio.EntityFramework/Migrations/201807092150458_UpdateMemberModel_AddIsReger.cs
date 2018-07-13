namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberModel_AddIsReger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "IsReger", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "IsReger");
        }
    }
}
