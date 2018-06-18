namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UptModelElectionHd : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Election", "ElectionHdId");
            AddForeignKey("dbo.Election", "ElectionHdId", "dbo.ElectionHead", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Election", "ElectionHdId", "dbo.ElectionHead");
            DropIndex("dbo.Election", new[] { "ElectionHdId" });
        }
    }
}
