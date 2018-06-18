namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelElectionHd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElectionHead",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        CreationTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        CandiNum = c.Int(nullable: false),
                        VoteNum = c.Int(nullable: false),
                        Intro = c.String(maxLength: 500),
                        TenantId = c.Int(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Election", "ElectionHdId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Election", "ElectionHdId");
            DropTable("dbo.ElectionHead");
        }
    }
}
