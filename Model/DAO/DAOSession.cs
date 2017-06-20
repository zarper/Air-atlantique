using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    public class DAOSession
    {


        public static Session ConstructeurSession(Session session)
        {
            using (var db = new DBAirAtlantiqueContext())
            {

                if (session.ListeEmployeeConcernees.Count() == 0)
                {

                    var employees = from es in db.SessionEmployees where es.SessionConcerne.SessionID == session.SessionID select es;
                    foreach (SessionEmployee es in employees)
                    {
                        var requeteE = from e in db.Employees where e.Matricule == es.EmployeeConcerne.Matricule select e;
                        es.EmployeeConcerne = requeteE.First();
                        session.ListeEmployeeConcernees.Add(es);
                    }
                }

                var requetteOrganismeFormation = from of in db.OrganismeFormation where of.ID == session.OrganismeFomationConcerne.ID select of;
                session.OrganismeFomationConcerne = requetteOrganismeFormation.First();

                var requetteFormation = from f in db.Formations where session.OrganismeFomationConcerne.FormationConcerne.FormationID == f.FormationID select f;
                session.OrganismeFomationConcerne.FormationConcerne = requetteFormation.First();
                var requetteOrganisme = from o in db.Organismes where o.OrganismeID == session.OrganismeFomationConcerne.OrganismeConcerne.OrganismeID select o;
                session.OrganismeFomationConcerne.OrganismeConcerne = requetteOrganisme.First();

                return session;

            }

        }



        public static ObservableCollection<Session> ListerSession()
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Session> ListerSessionDB = new ObservableCollection<Session>();
                var Sessions = from session in db.Sessions orderby session.DateDebut where session.SessionValider == false select session;
                foreach (Session session in Sessions)
                {
                    var requeteOF = from of in db.OrganismeFormation where of.ID == session.OrganismeFomationConcerne.ID select of;


                    session.OrganismeFomationConcerne = requeteOF.First();
                    var requeteO = from o in db.Organismes where session.OrganismeFomationConcerne.OrganismeConcerne.OrganismeID == o.OrganismeID select o;

                    session.OrganismeFomationConcerne.OrganismeConcerne = requeteO.First();

                    var requetteF = from f in db.Formations where f.FormationID == session.OrganismeFomationConcerne.FormationConcerne.FormationID select f;

                    session.OrganismeFomationConcerne.FormationConcerne = requetteF.First();
                    ListerSessionDB.Add(session);
                }

                return ListerSessionDB;
            }
        }

        public static ObservableCollection<Session> ListerSessionFinisNonValider()
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Session> ListerSessionDB = new ObservableCollection<Session>();
                var Sessions = from session in db.Sessions orderby session.DateDebut where session.DateFin < DateTime.Now where session.SessionValider == false select session;
                foreach (Session session in Sessions)
                {

                    ListerSessionDB.Add(DAOSession.ConstructeurSession(session));

                }

                return ListerSessionDB;
            }
        }

        public static ObservableCollection<Session> ListerSessionPourUneFormation(Formation formationConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Session> ListerSessionDB = new ObservableCollection<Session>();
                var sessions = from s in db.Sessions where s.OrganismeFomationConcerne.FormationConcerne.FormationID == formationConcerne.FormationID select s;
                foreach (Session session in sessions)
                {
                    var requeteOrganisme = from o in db.Organismes where o.OrganismeID == session.OrganismeFomationConcerne.OrganismeConcerne.OrganismeID select o;
                    session.OrganismeFomationConcerne.OrganismeConcerne = requeteOrganisme.First();
                    ListerSessionDB.Add(session);
                }

                return ListerSessionDB;
            }
        }

        public static ObservableCollection<Session> ListerSessionPourUnOrganisme(Organisme organismeConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Session> ListerSessionDB = new ObservableCollection<Session>();
                var sessions = from s in db.Sessions where s.OrganismeFomationConcerne.OrganismeConcerne.OrganismeID == organismeConcerne.OrganismeID select s;
                foreach (Session session in sessions)
                {
                    var requeteFormation = from f in db.Formations where f.FormationID == session.OrganismeFomationConcerne.FormationConcerne.FormationID select f;
                    session.OrganismeFomationConcerne.FormationConcerne = requeteFormation.First();
                    ListerSessionDB.Add(session);
                }

                return ListerSessionDB;
            }
        }



        public static void AjouterSession(Session sessionNouvelle, OrganismeFormation organismeFormationConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {

                var requetteOF = from of in db.OrganismeFormation where of.OrganismeConcerne.OrganismeID == organismeFormationConcerne.OrganismeConcerne.OrganismeID where of.FormationConcerne.FormationID == LaNavigation.Formation.FormationID select of;

                if (sessionNouvelle.Lieu == null)
                {
                    sessionNouvelle.Lieu = "Nantes";
                }
                sessionNouvelle.OrganismeFomationConcerne = requetteOF.First();


                db.Sessions.Add(sessionNouvelle);

                db.SaveChanges();

            }
        }


        public static void ValiderSession(Session sessionConcernee)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                foreach (SessionEmployee employee in sessionConcernee.ListeEmployeeConcernees)
                {
                    var requetteE = from e in db.Employees where e.Matricule == employee.EmployeeConcerne.Matricule select e;
                    var requetteF = from f in db.Formations where f.FormationID == sessionConcernee.OrganismeFomationConcerne.FormationConcerne.FormationID select f;
                    EmployeeFormation employeeFormationNew = new EmployeeFormation
                    {

                        EmployeeConcerne = requetteE.First(),
                        FormationConcerne = requetteF.First()

                    };

                    db.EmployeeFormation.Add(employeeFormationNew);
                }

                var requetteS = from s in db.Sessions where sessionConcernee.SessionID == s.SessionID select s;
                requetteS.First().SessionValider = true;
                db.SaveChanges();
            }

            

        }
    }

    }

