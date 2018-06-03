namespace LinkStart.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectionModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "ChatName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Connections", "ChatName");
        }
    }
}
