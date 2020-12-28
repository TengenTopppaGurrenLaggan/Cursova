namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zasd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "Resname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "Resname");
        }
    }
}
