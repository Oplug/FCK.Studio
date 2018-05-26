namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProdAndDemdInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DemdInfo", "CreatorUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CreatorUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.DemdInfo", "CreatorUserId");
            CreateIndex("dbo.Products", "CreatorUserId");
            AddForeignKey("dbo.DemdInfo", "CreatorUserId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CreatorUserId", "dbo.Members", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CreatorUserId", "dbo.Members");
            DropForeignKey("dbo.DemdInfo", "CreatorUserId", "dbo.Members");
            DropIndex("dbo.Products", new[] { "CreatorUserId" });
            DropIndex("dbo.DemdInfo", new[] { "CreatorUserId" });
            AlterColumn("dbo.Products", "CreatorUserId", c => c.Long());
            AlterColumn("dbo.DemdInfo", "CreatorUserId", c => c.Long());
        }
    }
}
