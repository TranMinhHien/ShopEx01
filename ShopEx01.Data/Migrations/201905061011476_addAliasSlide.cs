namespace ShopEx01.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAliasSlide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slides", "Alias", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slides", "Alias");
        }
    }
}
