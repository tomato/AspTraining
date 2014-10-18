namespace ASPTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchKeyCasing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Improvements", "Status_Id", "dbo.Status");
            DropIndex("dbo.Comments", new[] { "Improvement_Id" });
            DropIndex("dbo.Improvements", new[] { "Status_Id" });
            RenameColumn(table: "dbo.Improvements", name: "Status_Id", newName: "StatusID");
            AlterColumn("dbo.Improvements", "StatusID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Improvement_ID");
            CreateIndex("dbo.Improvements", "StatusID");
            AddForeignKey("dbo.Improvements", "StatusID", "dbo.Status", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Improvements", "StatusID", "dbo.Status");
            DropIndex("dbo.Improvements", new[] { "StatusID" });
            DropIndex("dbo.Comments", new[] { "Improvement_ID" });
            AlterColumn("dbo.Improvements", "StatusID", c => c.Int());
            RenameColumn(table: "dbo.Improvements", name: "StatusID", newName: "Status_Id");
            CreateIndex("dbo.Improvements", "Status_Id");
            CreateIndex("dbo.Comments", "Improvement_Id");
            AddForeignKey("dbo.Improvements", "Status_Id", "dbo.Status", "Id");
        }
    }
}
