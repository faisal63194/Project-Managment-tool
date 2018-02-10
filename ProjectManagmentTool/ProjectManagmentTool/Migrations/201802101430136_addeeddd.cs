namespace ProjectManagmentTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeeddd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "Designation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserModels", "Designation", c => c.String());
            AlterColumn("dbo.UserModels", "Status", c => c.String());
            AlterColumn("dbo.UserModels", "Password", c => c.String());
            AlterColumn("dbo.UserModels", "Email", c => c.String());
            AlterColumn("dbo.UserModels", "Name", c => c.String());
        }
    }
}
