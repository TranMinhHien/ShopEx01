namespace ShopEx01.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Errors", "StackTrace", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Errors", "StackTrace");
        }
    }
}
