namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pesYoupta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoItems",
                c => new
                    {
                        ToDoItemId = c.Int(nullable: false, identity: true),
                        ToDoContent = c.String(),
                        Priority = c.Byte(nullable: false),
                        DueDate = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        User_ApplicationUserId = c.Int(),
                    })
                .PrimaryKey(t => t.ToDoItemId)
                .ForeignKey("dbo.ApplicationUsers", t => t.User_ApplicationUserId)
                .Index(t => t.User_ApplicationUserId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        ApplicationUserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoItems", "User_ApplicationUserId", "dbo.ApplicationUsers");
            DropIndex("dbo.ToDoItems", new[] { "User_ApplicationUserId" });
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.ToDoItems");
        }
    }
}
