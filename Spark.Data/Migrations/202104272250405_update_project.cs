namespace Spark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_project : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "OwnerId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "OwnerId");
        }
    }
}
