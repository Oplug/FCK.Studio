namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptMember2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Age", c => c.String());
        }
    }
}
