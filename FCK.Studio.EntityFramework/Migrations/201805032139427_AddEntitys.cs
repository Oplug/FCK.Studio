namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntitys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Contents = c.String(unicode: false, storeType: "text"),
                        Images = c.String(maxLength: 500),
                        Points = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Election",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voter = c.String(unicode: false, storeType: "text"),
                        CreationTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Intro = c.String(maxLength: 500),
                        Photo = c.String(maxLength: 500),
                        TenantId = c.Int(nullable: false),
                        Candidate = c.String(nullable: false, maxLength: 50),
                        NumOfVote = c.Int(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "CreditRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditRecords", "MemberId", "dbo.Members");
            DropIndex("dbo.CreditRecords", new[] { "MemberId" });
            DropColumn("dbo.Members", "CreditRate");
            DropTable("dbo.Election");
            DropTable("dbo.CreditRecords");
        }
    }
}
