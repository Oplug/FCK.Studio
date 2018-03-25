namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptAdmin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Powers", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Powers", c => c.String(nullable: false));
        }
    }
}
