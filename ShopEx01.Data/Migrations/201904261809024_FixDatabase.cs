namespace ShopEx01.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Errors", "StrackTrace");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Errors", "StrackTrace", c => c.String());
        }
    }
}
