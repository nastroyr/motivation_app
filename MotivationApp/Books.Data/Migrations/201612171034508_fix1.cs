namespace Books.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MotivationEvents", "SoundRemind", c => c.Boolean(nullable: false));
            AddColumn("dbo.MotivationEvents", "VisualRemind", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MotivationEvents", "VisualRemind");
            DropColumn("dbo.MotivationEvents", "SoundRemind");
        }
    }
}
