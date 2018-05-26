namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "State", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "District", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "Community", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "Apartment", c => c.String(maxLength: 20));
            AddColumn("dbo.Products", "UpdateTime", c => c.DateTime());
            AddColumn("dbo.Products", "Country", c => c.String(maxLength: 20));
            AddColumn("dbo.Products", "State", c => c.String(maxLength: 20));
            AddColumn("dbo.Products", "City", c => c.String(maxLength: 20));
            AddColumn("dbo.Products", "District", c => c.String(maxLength: 20));
            AddColumn("dbo.Products", "Community", c => c.String(maxLength: 20));
            AddColumn("dbo.Products", "Address", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "Contactor", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "Phone", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "QQ", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "Weixin", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "Longitude", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "Latitude", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "Address", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Intro", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Keywords", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Tags", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Tags", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Keywords", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Intro", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Members", "Address", c => c.String(maxLength: 100));
            DropColumn("dbo.Products", "Latitude");
            DropColumn("dbo.Products", "Longitude");
            DropColumn("dbo.Products", "Email");
            DropColumn("dbo.Products", "Weixin");
            DropColumn("dbo.Products", "QQ");
            DropColumn("dbo.Products", "Phone");
            DropColumn("dbo.Products", "Contactor");
            DropColumn("dbo.Products", "Address");
            DropColumn("dbo.Products", "Community");
            DropColumn("dbo.Products", "District");
            DropColumn("dbo.Products", "City");
            DropColumn("dbo.Products", "State");
            DropColumn("dbo.Products", "Country");
            DropColumn("dbo.Products", "UpdateTime");
            DropColumn("dbo.Members", "Apartment");
            DropColumn("dbo.Members", "Community");
            DropColumn("dbo.Members", "District");
            DropColumn("dbo.Members", "State");
        }
    }
}
