namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Current : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumDataModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserDataModels", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.PhotoDataModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Datecreated = c.DateTime(),
                        Dateupdated = c.DateTime(),
                        publik = c.Boolean(nullable: false),
                        Name = c.String(),
                        Path = c.String(),
                        Description = c.String(),
                        UserID = c.Int(),
                        AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AlbumDataModels", t => t.AlbumID, cascadeDelete: true)
                .ForeignKey("dbo.UserDataModels", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.AlbumID);
            
            CreateTable(
                "dbo.CommentsDataModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Datecreated = c.DateTime(),
                        Dateupdated = c.DateTime(),
                        UserID = c.Int(),
                        PhotoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PhotoDataModels", t => t.PhotoID, cascadeDelete: true)
                .ForeignKey("dbo.UserDataModels", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.PhotoID);
            
            CreateTable(
                "dbo.UserDataModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoDataModels", "UserID", "dbo.UserDataModels");
            DropForeignKey("dbo.CommentsDataModels", "UserID", "dbo.UserDataModels");
            DropForeignKey("dbo.AlbumDataModels", "UserID", "dbo.UserDataModels");
            DropForeignKey("dbo.CommentsDataModels", "PhotoID", "dbo.PhotoDataModels");
            DropForeignKey("dbo.PhotoDataModels", "AlbumID", "dbo.AlbumDataModels");
            DropIndex("dbo.CommentsDataModels", new[] { "PhotoID" });
            DropIndex("dbo.CommentsDataModels", new[] { "UserID" });
            DropIndex("dbo.PhotoDataModels", new[] { "AlbumID" });
            DropIndex("dbo.PhotoDataModels", new[] { "UserID" });
            DropIndex("dbo.AlbumDataModels", new[] { "UserID" });
            DropTable("dbo.UserDataModels");
            DropTable("dbo.CommentsDataModels");
            DropTable("dbo.PhotoDataModels");
            DropTable("dbo.AlbumDataModels");
        }
    }
}
