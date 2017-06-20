using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    public class DAOEmploye
    {
       

        public static Employee ConctructeurEmploye(Employee employee)
        {
            using (var db = new DBAirAtlantiqueContext())
            {


                if (employee.CesSessions.Count == 0)
                {
                    var sessions = from es in db.SessionEmployees where es.EmployeeConcerne.Matricule == employee.Matricule select es;
                    foreach (SessionEmployee es in sessions)
                    {
                        var requeteS = from s in db.Sessions where s.SessionID == es.SessionConcerne.SessionID select s;
                        es.SessionConcerne = requeteS.First();
                        employee.CesSessions.Add(es);
                    }

                }

                if (employee.CesFormations.Count() == 0)
                {
                    var formations = from ef in db.EmployeeFormation where ef.EmployeeConcerne.Matricule == employee.Matricule select ef;
                    foreach (EmployeeFormation ef in formations)
                    {
                        var requeteF = from f in db.Formations where f.FormationID == ef.FormationConcerne.FormationID select f;
                        ef.FormationConcerne = requeteF.First();
                        employee.CesFormations.Add(ef);
                    }

                }
                return employee;
            }



        }

        public static ObservableCollection<Employee> ListerEmployes()
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Employee> ListerEmployeeDB = new ObservableCollection<Employee>();
                var Employes = from item in db.Employees orderby item.Matricule select item;
                foreach (Employee item in Employes)
                {
                    ListerEmployeeDB.Add(item);
                }

                return ListerEmployeeDB;
            }
        }

        public static ObservableCollection<Employee> ListerEmployeeManquantAUneSession(Session sessionConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Employee> ListerEmployeeManquantDB = new ObservableCollection<Employee>();

                IQueryable<Employee> employeesDejaFormerDB = from e in db.Employees join ef in db.EmployeeFormation on e.Matricule equals ef.EmployeeConcerne.Matricule where ef.FormationConcerne.FormationID == sessionConcerne.OrganismeFomationConcerne.FormationConcerne.FormationID select e;
                IQueryable<Employee> employeesTotalDB = from e in db.Employees select e;
                IQueryable<Employee> employeesDejaSessionDB = from e in db.Employees join se in db.SessionEmployees on e.Matricule equals se.EmployeeConcerne.Matricule join s in db.Sessions on se.SessionConcerne.SessionID equals s.SessionID where sessionConcerne.OrganismeFomationConcerne.FormationConcerne.FormationID == s.OrganismeFomationConcerne.FormationConcerne.FormationID select e;
                IQueryable<Employee> employeeManquant = employeesTotalDB.Except(employeesDejaFormerDB);
                employeeManquant = employeeManquant.Except(employeesDejaSessionDB);


                foreach (Employee employee in employeeManquant)
                {

                    ListerEmployeeManquantDB.Add(employee);
                }



                return ListerEmployeeManquantDB;
            }
        }

        public static void AjouterEmployeBDD(Employee employeeNouveau, Poste posteConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                var requettePoste = from p in db.Postes where posteConcerne.PosteID == p.PosteID select p;
                employeeNouveau.PosteAttribuer = requettePoste.First();


                db.Employees.Add(employeeNouveau);

                db.SaveChanges();

            }
        }

    }
}
