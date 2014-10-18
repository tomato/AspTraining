namespace ASPTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addStatusTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);

            Sql("Insert into Status(Description) Values ('ToDo')");
            Sql("Insert into Status(Description) Values ('InProgress')");
            Sql("Insert into Status(Description) Values ('Done')");

            AddColumn("dbo.Improvements", "Status_ID", c => c.Int(nullable: false,defaultValue:1));
            CreateIndex("dbo.Improvements", "Status_Id");
            AddForeignKey("dbo.Improvements", "Status_Id", "dbo.Status", "Id");

            Sql("Update Improvements Set Status_Id = 1 Where Status = 0");
            Sql("Update Improvements Set Status_Id = 2 Where Status = 1");
            Sql("Update Improvements Set Status_Id = 3 Where Status = 2");

            DropColumn("dbo.Improvements", "Status");
        }

        public override void Down()
        {
            AddColumn("dbo.Improvements", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.Improvements", "Status_Id", "dbo.Status");
            DropIndex("dbo.Improvements", new[] { "Status_Id" });
            DropColumn("dbo.Improvements", "Status_ID");
            DropTable("dbo.Status");
        }
    }
}
