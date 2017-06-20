namespace MaltAirAtlantique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rajoutbooldanssession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "SessionValider", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "SessionValider");
        }
    }
}
