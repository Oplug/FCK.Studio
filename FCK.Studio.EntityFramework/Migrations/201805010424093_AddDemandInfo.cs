namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDemandInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DemdInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Contents = c.String(unicode: false, storeType: "text"),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Intro = c.String(maxLength: 500),
                        Keywords = c.String(maxLength: 50),
                        Tags = c.String(maxLength: 50),
                        TenantId = c.Int(nullable: false),
                        Title = c.String(maxLength: 50),
                        Contactor = c.String(),
                        Phone = c.String(maxLength: 50),
                        QQ = c.String(maxLength: 50),
                        Weixin = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Hits = c.Int(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DemdInfo", "CategoryId", "dbo.Categories");
            DropIndex("dbo.DemdInfo", new[] { "CategoryId" });
            DropTable("dbo.DemdInfo");
        }
    }
}
