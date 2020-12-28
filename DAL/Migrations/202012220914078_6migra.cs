namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6migra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Resume_Id", c => c.Int());
            AddColumn("dbo.Categories", "Vac_Id", c => c.Int());
            AddColumn("dbo.Custs", "Vac_Id", c => c.Int());
            AddColumn("dbo.Unems", "Resume_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Resume_Id");
            CreateIndex("dbo.Categories", "Vac_Id");
            CreateIndex("dbo.Unems", "Resume_Id");
            CreateIndex("dbo.Custs", "Vac_Id");
            AddForeignKey("dbo.Categories", "Resume_Id", "dbo.Resumes", "Id");
            AddForeignKey("dbo.Unems", "Resume_Id", "dbo.Resumes", "Id");
            AddForeignKey("dbo.Categories", "Vac_Id", "dbo.Vacs", "Id");
            AddForeignKey("dbo.Custs", "Vac_Id", "dbo.Vacs", "Id");
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
