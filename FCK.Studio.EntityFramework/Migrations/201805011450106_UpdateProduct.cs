namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Apartment", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Apartment");
        }
    }
}
