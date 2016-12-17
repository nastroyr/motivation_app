namespace Books.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class events : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotivationEvents",
                c => new
                    {
                        MotivationEventID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateDue = c.DateTime(nullable: false),
                        Description = c.String(),
                        Place = c.String(),
                        RepeatSeconds = c.Int(nullable: false),
                        LastRemind = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MotivationEventID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MotivationEvents");
        }
    }
}
