using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    public class DAOEmployeeFormation
    {
        public static ObservableCollection<EmployeeFormation> ListerEmployeeFormationManquante()
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<EmployeeFormation> listerEmployeeFormationDB = new ObservableCollection<EmployeeFormation>();
                IQueryable<Poste> requettePoste = from p in db.Postes select p;

                foreach (Poste poste in requettePoste)
                {
                    var requetteFormationPoste = from f in db.Formations join pf in db.PosteFormation on f.FormationID equals pf.FormationConcerne.FormationID where pf.PosteConcerne.PosteID == poste.PosteID select f;

                    var requetteEmployeePoste = from e in db.Employees where e.PosteAttribuer.PosteID == poste.PosteID select e;

                    foreach (Employee employee in requetteEmployeePoste)
                    {
                        var requetteFormationEmployee = from f in db.Formations join ef in db.EmployeeFormation on f.FormationID equals ef.FormationConcerne.FormationID where ef.EmployeeConcerne.Matricule == employee.Matricule select f;

                        IQueryable<Formation> FormationManquante = requetteFormationPoste.Except(requetteFormationEmployee);
                        foreach (Formation formation in FormationManquante)
                        {
                            EmployeeFormation employeeformation = new EmployeeFormation
                            {
                                FormationConcerne = formation,
                                EmployeeConcerne = employee,
                            };

                            listerEmployeeFormationDB.Add(employeeformation);
                        }
                    }
                }

                return listerEmployeeFormationDB;
            }


        }


        public static void AjouterEmployeeFormation(EmployeeFormation employeeFormationNouveau)
        {
            {


                using (var db = new DBAirAtlantiqueContext())
                {

                    var requetteFormation = from f in db.Formations where f.FormationID == employeeFormationNouveau.FormationConcerne.FormationID select f;
                    var requetteEmployee = from e in db.Employees where e.Matricule == employeeFormationNouveau.EmployeeConcerne.Matricule select e;

                    employeeFormationNouveau.EmployeeConcerne = requetteEmployee.First();
                    employeeFormationNouveau.FormationConcerne = requetteFormation.First();

                    db.EmployeeFormation.Add(employeeFormationNouveau);

                    db.SaveChanges();

                }
            }
        }
    }
}
