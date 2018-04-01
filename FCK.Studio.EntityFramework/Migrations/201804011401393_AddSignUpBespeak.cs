namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSignUpBespeak : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignUpBespeak",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Telphone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        QQ = c.String(maxLength: 50),
                        IDCardNo = c.String(maxLength: 50),
                        Address = c.String(maxLength: 200),
                        IsMarry = c.Boolean(nullable: false),
                        CulturalLevel = c.String(),
                        ActvTitle = c.String(maxLength: 50),
                        ActvID = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SignUpBespeak");
        }
    }
}
