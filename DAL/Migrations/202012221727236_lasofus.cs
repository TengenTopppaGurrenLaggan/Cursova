namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lasofus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vacs", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Vacs", "Cust_Id", "dbo.Custs");
            DropIndex("dbo.Vacs", new[] { "Category_Id" });
            DropIndex("dbo.Vacs", new[] { "Cust_Id" });
            AddColumn("dbo.Vacs", "Category_Id1", c => c.Int());
            AddColumn("dbo.Vacs", "Cust_Id1", c => c.Int());
            AlterColumn("dbo.Vacs", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Vacs", "Cust_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Vacs", "Category_Id1");
            CreateIndex("dbo.Vacs", "Cust_Id1");
            AddForeignKey("dbo.Vacs", "Category_Id1", "dbo.Categories", "Id");
            AddForeignKey("dbo.Vacs", "Cust_Id1", "dbo.Custs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacs", "Cust_Id1", "dbo.Custs");
            DropForeignKey("dbo.Vacs", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.Vacs", new[] { "Cust_Id1" });
            DropIndex("dbo.Vacs", new[] { "Category_Id1" });
            AlterColumn("dbo.Vacs", "Cust_Id", c => c.Int());
            AlterColumn("dbo.Vacs", "Category_Id", c => c.Int());
            DropColumn("dbo.Vacs", "Cust_Id1");
            DropColumn("dbo.Vacs", "Category_Id1");
            CreateIndex("dbo.Vacs", "Cust_Id");
            CreateIndex("dbo.Vacs", "Category_Id");
            AddForeignKey("dbo.Vacs", "Cust_Id", "dbo.Custs", "Id");
            AddForeignKey("dbo.Vacs", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
