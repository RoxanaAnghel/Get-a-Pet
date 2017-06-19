namespace Pet.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtexttoMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Text");
        }
    }
}
