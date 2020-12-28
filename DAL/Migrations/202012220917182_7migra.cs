namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7migra : DbMigration
    {
        public override void Up()
        {
           
            
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Custs", "Vac_Id", "dbo.Vacs");
            DropForeignKey("dbo.Categories", "Vac_Id", "dbo.Vacs");
            DropForeignKey("dbo.Unems", "Resume_Id", "dbo.Resumes");
            DropForeignKey("dbo.Categories", "Resume_Id", "dbo.Resumes");
            DropIndex("dbo.Custs", new[] { "Vac_Id" });
            DropIndex("dbo.Unems", new[] { "Resume_Id" });
            DropIndex("dbo.Categories", new[] { "Vac_Id" });
            DropIndex("dbo.Categories", new[] { "Resume_Id" });
            DropColumn("dbo.Unems", "Resume_Id");
            DropColumn("dbo.Custs", "Vac_Id");
            DropColumn("dbo.Categories", "Vac_Id");
            DropColumn("dbo.Categories", "Resume_Id");
        }
    }
}
