namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resumes", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Resumes", "Unem_Id", "dbo.Unems");
            DropIndex("dbo.Resumes", new[] { "Category_Id" });
            DropIndex("dbo.Resumes", new[] { "Unem_Id" });
            AddColumn("dbo.Resumes", "Category_Id1", c => c.Int());
            AddColumn("dbo.Resumes", "Unem_Id1", c => c.Int());
            AlterColumn("dbo.Resumes", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Resumes", "Unem_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Resumes", "Category_Id1");
            CreateIndex("dbo.Resumes", "Unem_Id1");
            AddForeignKey("dbo.Resumes", "Category_Id1", "dbo.Categories", "Id");
            AddForeignKey("dbo.Resumes", "Unem_Id1", "dbo.Unems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resumes", "Unem_Id1", "dbo.Unems");
            DropForeignKey("dbo.Resumes", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.Resumes", new[] { "Unem_Id1" });
            DropIndex("dbo.Resumes", new[] { "Category_Id1" });
            AlterColumn("dbo.Resumes", "Unem_Id", c => c.Int());
            AlterColumn("dbo.Resumes", "Category_Id", c => c.Int());
            DropColumn("dbo.Resumes", "Unem_Id1");
            DropColumn("dbo.Resumes", "Category_Id1");
            CreateIndex("dbo.Resumes", "Unem_Id");
            CreateIndex("dbo.Resumes", "Category_Id");
            AddForeignKey("dbo.Resumes", "Unem_Id", "dbo.Unems", "Id");
            AddForeignKey("dbo.Resumes", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
