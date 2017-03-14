namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedguid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDataModels", "Idguid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDataModels", "Idguid");
        }
    }
}
