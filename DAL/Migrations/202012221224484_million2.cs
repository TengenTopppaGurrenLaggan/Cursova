namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class million2 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.Resumes", new[] { "Category_Id1" });
            //DropIndex("dbo.Resumes", new[] { "Unem_Id1" });
            //DropIndex("dbo.Vacs", new[] { "Category_Id1" });
            //DropIndex("dbo.Vacs", new[] { "Cust_Id1" });
            //DropColumn("dbo.Resumes", "Category_Id");
            //DropColumn("dbo.Resumes", "Unem_Id");
            //DropColumn("dbo.Vacs", "Category_Id");
            //DropColumn("dbo.Vacs", "Cust_Id");
            //RenameColumn(table: "dbo.Resumes", name: "Category_Id1", newName: "Category_Id");
            //RenameColumn(table: "dbo.Vacs", name: "Category_Id1", newName: "Category_Id");
            //RenameColumn(table: "dbo.Resumes", name: "Unem_Id1", newName: "Unem_Id");
            //RenameColumn(table: "dbo.Vacs", name: "Cust_Id1", newName: "Cust_Id");
            AlterColumn("dbo.Resumes", "Unem_Id", c => c.Int());
            AlterColumn("dbo.Resumes", "Category_Id", c => c.Int());
            AlterColumn("dbo.Vacs", "Category_Id", c => c.Int());
            AlterColumn("dbo.Vacs", "Cust_Id", c => c.Int());
            CreateIndex("dbo.Resumes", "Category_Id");
            CreateIndex("dbo.Resumes", "Unem_Id");
            CreateIndex("dbo.Vacs", "Category_Id");
            CreateIndex("dbo.Vacs", "Cust_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vacs", new[] { "Cust_Id" });
            DropIndex("dbo.Vacs", new[] { "Category_Id" });
            DropIndex("dbo.Resumes", new[] { "Unem_Id" });
            DropIndex("dbo.Resumes", new[] { "Category_Id" });
            AlterColumn("dbo.Vacs", "Cust_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Vacs", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Resumes", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Resumes", "Unem_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Vacs", name: "Cust_Id", newName: "Cust_Id1");
            RenameColumn(table: "dbo.Resumes", name: "Unem_Id", newName: "Unem_Id1");
            RenameColumn(table: "dbo.Vacs", name: "Category_Id", newName: "Category_Id1");
            RenameColumn(table: "dbo.Resumes", name: "Category_Id", newName: "Category_Id1");
            AddColumn("dbo.Vacs", "Cust_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Vacs", "Category_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Resumes", "Unem_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Resumes", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Vacs", "Cust_Id1");
            CreateIndex("dbo.Vacs", "Category_Id1");
            CreateIndex("dbo.Resumes", "Unem_Id1");
            CreateIndex("dbo.Resumes", "Category_Id1");
        }
    }
}
