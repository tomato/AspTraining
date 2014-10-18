namespace ASPTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InterfacingEverything : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Improvements", "StatusID", "dbo.Status");
            //DropIndex("dbo.Improvements", new[] { "StatusID" });
        }
        
        public override void Down()
        {
            //CreateIndex("dbo.Improvements", "StatusID");
            //AddForeignKey("dbo.Improvements", "StatusID", "dbo.Status", "ID", cascadeDelete: true);
        }
    }
}
