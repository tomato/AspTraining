namespace ASPTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherhiddenchange : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "Improvement_ID" });
            AlterColumn("dbo.Comments", "CreatedDateTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Comments", "Improvement_Id");
            //CreateIndex("dbo.Improvements", "StatusID");
            //AddForeignKey("dbo.Improvements", "StatusID", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Improvements", "StatusID", "dbo.Status");
            DropIndex("dbo.Improvements", new[] { "StatusID" });
            DropIndex("dbo.Comments", new[] { "Improvement_Id" });
            AlterColumn("dbo.Comments", "CreatedDateTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Comments", "Improvement_ID");
        }
    }
}
