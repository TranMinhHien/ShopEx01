namespace ShopEx01.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addslide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slides", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Slides", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slides", "UpdatedDate");
            DropColumn("dbo.Slides", "CreatedDate");
        }
    }
}
