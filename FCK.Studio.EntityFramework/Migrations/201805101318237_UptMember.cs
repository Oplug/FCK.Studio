namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Birthday", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Birthday");
        }
    }
}
