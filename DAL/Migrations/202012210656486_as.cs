namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _as : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Catname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Custs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Worktime = c.Int(nullable: false),
                        Unid = c.Int(nullable: false),
                        Catid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Surname = c.String(nullable: false, unicode: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Int(nullable: false),
                        Vacname = c.String(nullable: false, unicode: false),
                        Catid = c.Int(nullable: false),
                        Cusid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vacs");
            DropTable("dbo.Unems");
            DropTable("dbo.Resumes");
            DropTable("dbo.Custs");
            DropTable("dbo.Categories");
        }
    }
}
