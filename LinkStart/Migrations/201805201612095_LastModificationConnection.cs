namespace LinkStart.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastModificationConnection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Connections", "UserId");
            AddForeignKey("dbo.Connections", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connections", "UserId", "dbo.User");
            DropIndex("dbo.Connections", new[] { "UserId" });
            DropColumn("dbo.Connections", "UserId");
        }
    }
}
