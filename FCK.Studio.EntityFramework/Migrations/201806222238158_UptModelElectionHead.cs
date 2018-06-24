namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptModelElectionHead : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ElectionHead", "Intro", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ElectionHead", "Intro", c => c.String(maxLength: 500));
        }
    }
}
