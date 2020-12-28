namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {

            // DropIndex("dbo.Categories", new[] { "Resume_Id" });
            //DropIndex("dbo.Categories", new[] { "Vac_Id" });
            //DropIndex("dbo.Unems", new[] { "Resume_Id" });
            //DropIndex("dbo.Custs", new[] { "Vac_Id" });
            //CreateIndex("dbo.Resumes", "Catid");
            //CreateIndex("dbo.Vacs", "Catid");
            //CreateIndex("dbo.Vacs", "Cusid");
            //CreateIndex("dbo.Resumes", "Unid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Custs", "Vac_Id", c => c.Int());
            AddColumn("dbo.Unems", "Resume_Id", c => c.Int());
            AddColumn("dbo.Categories", "Vac_Id", c => c.Int());
            AddColumn("dbo.Categories", "Resume_Id", c => c.Int());
            DropForeignKey("dbo.UnemResumes", "Resume_Id", "dbo.Resumes");
            DropForeignKey("dbo.UnemResumes", "Unem_Id", "dbo.Unems");
            DropIndex("dbo.UnemResumes", new[] { "Resume_Id" });
            DropIndex("dbo.UnemResumes", new[] { "Unem_Id" });
            DropIndex("dbo.Vacs", new[] { "Cust_Id" });
            DropIndex("dbo.Vacs", new[] { "Category_Id" });
            DropIndex("dbo.Resumes", new[] { "Category_Id" });
            DropTable("dbo.UnemResumes");
            RenameColumn(table: "dbo.Vacs", name: "Cust_Id", newName: "Vac_Id");
            RenameColumn(table: "dbo.Vacs", name: "Category_Id", newName: "Vac_Id");
            RenameColumn(table: "dbo.Resumes", name: "Category_Id", newName: "Resume_Id");
            CreateIndex("dbo.Custs", "Vac_Id");
            CreateIndex("dbo.Unems", "Resume_Id");
            CreateIndex("dbo.Categories", "Vac_Id");
            CreateIndex("dbo.Categories", "Resume_Id");
            AddForeignKey("dbo.Unems", "Resume_Id", "dbo.Resumes", "Id");
        }
    }
}
