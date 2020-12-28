namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Resumes", "Catid");
            CreateIndex("dbo.Resumes", "Unid");
            CreateIndex("dbo.Vacs", "Cusid");
            CreateIndex("dbo.Vacs", "Catid");
        }
        
        public override void Down()
        {
        }
    }
}
