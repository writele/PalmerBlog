namespace PalmerBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Modified", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Modified");
        }
    }
}
