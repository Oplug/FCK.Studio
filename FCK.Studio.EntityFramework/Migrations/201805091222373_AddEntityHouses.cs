namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityHouses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        HouseName = c.String(maxLength: 50),
                        UnitNum = c.String(maxLength: 10),
                        DoorCard = c.String(maxLength: 20),
                        HouseType = c.String(maxLength: 8),
                        HouseArea = c.String(maxLength: 8),
                        IsSaled = c.Boolean(nullable: false),
                        HhdRegister = c.Boolean(nullable: false),
                        Owner = c.String(maxLength: 10),
                        Owner2 = c.String(maxLength: 10),
                        Owner3 = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.Members", "TrueName", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "Relations", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "Sex", c => c.String(maxLength: 2));
            AddColumn("dbo.Members", "Nation", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "Age", c => c.String());
            AddColumn("dbo.Members", "UnitNum", c => c.String(maxLength: 10));
            AddColumn("dbo.Members", "DoorCard", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "Address2", c => c.String(maxLength: 50));
            AddColumn("dbo.Members", "HhdRegister", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "ServiceAddr", c => c.String(maxLength: 50));
            AddColumn("dbo.Members", "Duties", c => c.String(maxLength: 8));
            AddColumn("dbo.Members", "PartyBranch", c => c.String(maxLength: 50));
            AddColumn("dbo.Members", "CorridorLeader", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "HouseLeader", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "ResidentRepresentative", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "ResidentLeader", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "Pipwa", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "Eira", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "Speciality", c => c.String(maxLength: 50));
            AddColumn("dbo.Members", "Phone", c => c.String(maxLength: 50));
            AddColumn("dbo.Members", "Phone2", c => c.String(maxLength: 50));
            AddColumn("dbo.Members", "UpdateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Houses", new[] { "CategoryId" });
            DropColumn("dbo.Members", "UpdateTime");
            DropColumn("dbo.Members", "Phone2");
            DropColumn("dbo.Members", "Phone");
            DropColumn("dbo.Members", "Speciality");
            DropColumn("dbo.Members", "Eira");
            DropColumn("dbo.Members", "Pipwa");
            DropColumn("dbo.Members", "ResidentLeader");
            DropColumn("dbo.Members", "ResidentRepresentative");
            DropColumn("dbo.Members", "HouseLeader");
            DropColumn("dbo.Members", "CorridorLeader");
            DropColumn("dbo.Members", "PartyBranch");
            DropColumn("dbo.Members", "Duties");
            DropColumn("dbo.Members", "ServiceAddr");
            DropColumn("dbo.Members", "HhdRegister");
            DropColumn("dbo.Members", "Address2");
            DropColumn("dbo.Members", "DoorCard");
            DropColumn("dbo.Members", "UnitNum");
            DropColumn("dbo.Members", "Age");
            DropColumn("dbo.Members", "Nation");
            DropColumn("dbo.Members", "Sex");
            DropColumn("dbo.Members", "Relations");
            DropColumn("dbo.Members", "TrueName");
            DropTable("dbo.Houses");
        }
    }
}
