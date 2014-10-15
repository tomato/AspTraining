namespace ASPTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 500),
                        User = c.String(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Improvement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Improvements", t => t.Improvement_Id)
                .Index(t => t.Improvement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Improvement_Id", "dbo.Improvements");
            DropIndex("dbo.Comments", new[] { "Improvement_Id" });
            DropTable("dbo.Comments");
        }
    }
}
