namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class theLast : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoItems", "User_ApplicationUserId", "dbo.ApplicationUsers");
            DropIndex("dbo.ToDoItems", new[] { "User_ApplicationUserId" });
            DropColumn("dbo.ToDoItems", "UserId");
            RenameColumn(table: "dbo.ToDoItems", name: "User_ApplicationUserId", newName: "UserId");
            AlterColumn("dbo.ToDoItems", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ToDoItems", "UserId");
            AddForeignKey("dbo.ToDoItems", "UserId", "dbo.ApplicationUsers", "ApplicationUserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoItems", "UserId", "dbo.ApplicationUsers");
            DropIndex("dbo.ToDoItems", new[] { "UserId" });
            AlterColumn("dbo.ToDoItems", "UserId", c => c.Int());
            RenameColumn(table: "dbo.ToDoItems", name: "UserId", newName: "User_ApplicationUserId");
            AddColumn("dbo.ToDoItems", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ToDoItems", "User_ApplicationUserId");
            AddForeignKey("dbo.ToDoItems", "User_ApplicationUserId", "dbo.ApplicationUsers", "ApplicationUserId");
        }
    }
}
