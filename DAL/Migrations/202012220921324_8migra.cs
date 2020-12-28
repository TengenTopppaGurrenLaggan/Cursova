namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8migra : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Unems", new[] { "Resume_Id" });
            DropIndex("dbo.Categorys", new[] { "Vac_Id" });
            DropIndex("dbo.Categorys", new[] { "Resume_Id" });
            DropIndex("dbo.Custs", new[] { "Vac_Id" });
        }
    }
}
