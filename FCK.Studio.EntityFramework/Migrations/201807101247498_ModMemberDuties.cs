namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModMemberDuties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Duties", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Duties", c => c.String(maxLength: 8));
        }
    }
}
