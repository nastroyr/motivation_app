namespace Books.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quotesandimages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotivationImages",
                c => new
                    {
                        MotivationImageID = c.Int(nullable: false, identity: true),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.MotivationImageID);
            
            CreateTable(
                "dbo.MotivationQuotes",
                c => new
                    {
                        MotivationQuoteID = c.Int(nullable: false, identity: true),
                        QuoteText = c.String(),
                    })
                .PrimaryKey(t => t.MotivationQuoteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MotivationQuotes");
            DropTable("dbo.MotivationImages");
        }
    }
}
