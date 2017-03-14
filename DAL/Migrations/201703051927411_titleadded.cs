namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class titleadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentsDataModels", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommentsDataModels", "Title");
        }
    }
}
