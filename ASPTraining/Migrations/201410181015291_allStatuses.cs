namespace ASPTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allStatuses : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Improvements", new[] { "Status_Id" });
            AlterColumn("dbo.Improvements", "Status_Id", c => c.Int());
            AlterColumn("dbo.Improvements", "Status_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Improvements", "Status_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Improvements", new[] { "Status_Id" });
            AlterColumn("dbo.Improvements", "Status_ID", c => c.Int());
            AlterColumn("dbo.Improvements", "Status_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Improvements", "Status_Id");
        }
    }
}
