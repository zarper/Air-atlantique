namespace MaltAirAtlantique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Skype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organismes", "NomSkype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organismes", "NomSkype");
        }
    }
}
