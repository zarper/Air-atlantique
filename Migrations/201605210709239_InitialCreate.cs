namespace MaltAirAtlantique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeFormations",
                c => new
                    {
                        EmployeeFormationID = c.Int(nullable: false, identity: true),
                        EmployeeConcerne_Matricule = c.String(maxLength: 128),
                        FormationConcerne_FormationID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeFormationID)
                .ForeignKey("dbo.Employees", t => t.EmployeeConcerne_Matricule)
                .ForeignKey("dbo.Formations", t => t.FormationConcerne_FormationID)
                .Index(t => t.EmployeeConcerne_Matricule)
                .Index(t => t.FormationConcerne_FormationID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Matricule = c.String(nullable: false, maxLength: 128),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                        PosteAttribuer_PosteID = c.Int(),
                    })
                .PrimaryKey(t => t.Matricule)
                .ForeignKey("dbo.Postes", t => t.PosteAttribuer_PosteID)
                .Index(t => t.PosteAttribuer_PosteID);
            
            CreateTable(
                "dbo.SessionEmployees",
                c => new
                    {
                        SessionEmployeesID = c.Int(nullable: false, identity: true),
                        EmployeeConcerne_Matricule = c.String(maxLength: 128),
                        SessionConcerne_SessionID = c.Int(),
                    })
                .PrimaryKey(t => t.SessionEmployeesID)
                .ForeignKey("dbo.Employees", t => t.EmployeeConcerne_Matricule)
                .ForeignKey("dbo.Sessions", t => t.SessionConcerne_SessionID)
                .Index(t => t.EmployeeConcerne_Matricule)
                .Index(t => t.SessionConcerne_SessionID);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        NbrPlaceTotal = c.Int(nullable: false),
                        Lieu = c.String(nullable: false, maxLength: 30),
                        OrganismeFomationConcerne_ID = c.Int(),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.OrganismeFormations", t => t.OrganismeFomationConcerne_ID)
                .Index(t => t.OrganismeFomationConcerne_ID);
            
            CreateTable(
                "dbo.OrganismeFormations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Prix = c.Double(nullable: false),
                        FormationConcerne_FormationID = c.Int(),
                        OrganismeConcerne_OrganismeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Formations", t => t.FormationConcerne_FormationID)
                .ForeignKey("dbo.Organismes", t => t.OrganismeConcerne_OrganismeID)
                .Index(t => t.FormationConcerne_FormationID)
                .Index(t => t.OrganismeConcerne_OrganismeID);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        FormationID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                        DureeEnHeure = c.Single(nullable: false),
                        DureeDeValidite = c.Int(),
                    })
                .PrimaryKey(t => t.FormationID);
            
            CreateTable(
                "dbo.Organismes",
                c => new
                    {
                        OrganismeID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        ContactNom = c.String(),
                        ContactMail = c.String(),
                        LienInternet = c.String(),
                    })
                .PrimaryKey(t => t.OrganismeID);
            
            CreateTable(
                "dbo.Postes",
                c => new
                    {
                        PosteID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PosteID);
            
            CreateTable(
                "dbo.PosteFormations",
                c => new
                    {
                        PosteFormationID = c.Int(nullable: false, identity: true),
                        FormationConcerne_FormationID = c.Int(),
                        PosteConcerne_PosteID = c.Int(),
                    })
                .PrimaryKey(t => t.PosteFormationID)
                .ForeignKey("dbo.Formations", t => t.FormationConcerne_FormationID)
                .ForeignKey("dbo.Postes", t => t.PosteConcerne_PosteID)
                .Index(t => t.FormationConcerne_FormationID)
                .Index(t => t.PosteConcerne_PosteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PosteFormations", "PosteConcerne_PosteID", "dbo.Postes");
            DropForeignKey("dbo.PosteFormations", "FormationConcerne_FormationID", "dbo.Formations");
            DropForeignKey("dbo.Employees", "PosteAttribuer_PosteID", "dbo.Postes");
            DropForeignKey("dbo.Sessions", "OrganismeFomationConcerne_ID", "dbo.OrganismeFormations");
            DropForeignKey("dbo.OrganismeFormations", "OrganismeConcerne_OrganismeID", "dbo.Organismes");
            DropForeignKey("dbo.OrganismeFormations", "FormationConcerne_FormationID", "dbo.Formations");
            DropForeignKey("dbo.EmployeeFormations", "FormationConcerne_FormationID", "dbo.Formations");
            DropForeignKey("dbo.SessionEmployees", "SessionConcerne_SessionID", "dbo.Sessions");
            DropForeignKey("dbo.SessionEmployees", "EmployeeConcerne_Matricule", "dbo.Employees");
            DropForeignKey("dbo.EmployeeFormations", "EmployeeConcerne_Matricule", "dbo.Employees");
            DropIndex("dbo.PosteFormations", new[] { "PosteConcerne_PosteID" });
            DropIndex("dbo.PosteFormations", new[] { "FormationConcerne_FormationID" });
            DropIndex("dbo.OrganismeFormations", new[] { "OrganismeConcerne_OrganismeID" });
            DropIndex("dbo.OrganismeFormations", new[] { "FormationConcerne_FormationID" });
            DropIndex("dbo.Sessions", new[] { "OrganismeFomationConcerne_ID" });
            DropIndex("dbo.SessionEmployees", new[] { "SessionConcerne_SessionID" });
            DropIndex("dbo.SessionEmployees", new[] { "EmployeeConcerne_Matricule" });
            DropIndex("dbo.Employees", new[] { "PosteAttribuer_PosteID" });
            DropIndex("dbo.EmployeeFormations", new[] { "FormationConcerne_FormationID" });
            DropIndex("dbo.EmployeeFormations", new[] { "EmployeeConcerne_Matricule" });
            DropTable("dbo.PosteFormations");
            DropTable("dbo.Postes");
            DropTable("dbo.Organismes");
            DropTable("dbo.Formations");
            DropTable("dbo.OrganismeFormations");
            DropTable("dbo.Sessions");
            DropTable("dbo.SessionEmployees");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeFormations");
        }
    }
}
