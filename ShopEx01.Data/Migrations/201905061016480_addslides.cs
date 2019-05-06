namespace ShopEx01.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addslides : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slides", "Alias", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slides", "Alias", c => c.String(maxLength: 256));
        }
    }
}
