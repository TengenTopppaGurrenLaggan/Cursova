namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notlast : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Custs", new[] { "id" });
            DropIndex("dbo.Custs", new[] { "id" });
            DropIndex("dbo.Resumes", new[] { "id" });
            DropIndex("dbo.Resumes", new[] { "id" });
        }
        
        public override void Down()
        {
        }
    }
}
