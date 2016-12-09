namespace Books.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        NameOfBook = c.String(),
                        AuthorName = c.String(),
                        AboutAuthor = c.String(),
                        AboutBook = c.String(),
                        WhereToBuy = c.String(),
                        WhereToDownloadFree = c.String(),
                        SubjectID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Books", "GenreID", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreID" });
            DropIndex("dbo.Books", new[] { "SubjectID" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
        }
    }
}
