namespace ASPTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class houstenproblem : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "Improvement_Id" });
            AlterColumn("dbo.Comments", "CreatedDateTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Comments", "Improvement_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "Improvement_ID" });
            AlterColumn("dbo.Comments", "CreatedDateTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Comments", "Improvement_Id");
        }
    }
}
