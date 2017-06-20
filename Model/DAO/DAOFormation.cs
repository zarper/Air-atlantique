using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    class DAOFormation
    {
        public static Formation ConstructeurFormation(Formation formation)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                if (formation.ListOrganismes.Count() == 0)
                {
                    var Organismes = from of in db.OrganismeFormation join o in db.Organismes on of.OrganismeConcerne.OrganismeID equals o.OrganismeID where of.FormationConcerne.FormationID == formation.FormationID select of;
                    foreach (OrganismeFormation of in Organismes)
                    {

                        var requeteOrganisme = from o in db.Organismes where o.OrganismeID == of.OrganismeConcerne.OrganismeID select o;
                        of.OrganismeConcerne = requeteOrganisme.First();
                        formation.ListOrganismes.Add(of);
                    }
                }

                if (formation.ListEmployees.Count() == 0)
                {
                    var Employees = from ef in db.EmployeeFormation where ef.FormationConcerne.FormationID == formation.FormationID select ef;
                    foreach (EmployeeFormation ef in Employees)
                    {
                        var requeteEmployee = from e in db.Employees where e.Matricule == ef.EmployeeConcerne.Matricule select e;
                        ef.EmployeeConcerne = requeteEmployee.First();
                        formation.ListEmployees.Add(ef);
                    }
                }

            }
            return formation;
        }


        public static ObservableCollection<Formation> ListerFormation()
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Formation> ListerFormationDB = new ObservableCollection<Formation>();
                var formations = from item in db.Formations orderby item.Nom select item;
                foreach (Formation formation in formations)
                {

                    ListerFormationDB.Add(formation);
                }

                return ListerFormationDB;
            }
        }

        public static ObservableCollection<Formation> ListerFormationObligatoirePoste(Poste posteConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Formation> ListerFormationDB = new ObservableCollection<Formation>();
                IQueryable<Formation> Formations = from item in db.Formations orderby item.Nom select item;
                IQueryable<Formation> FormationAcquise = from f in db.Formations join pf in db.PosteFormation on f.FormationID equals pf.FormationConcerne.FormationID where pf.PosteConcerne.PosteID == posteConcerne.PosteID select f;

                Formations = Formations.Except(FormationAcquise);
                foreach (Formation item in Formations)
                {

                    ListerFormationDB.Add(DAOFormation.ConstructeurFormation(item));
                }

                return ListerFormationDB;
            }


        }

        public static ObservableCollection<Formation> ListerFormationPourUnEmployee(Employee employeeConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Formation> ListerFormationDB = new ObservableCollection<Formation>();
                IQueryable<Formation> FormationManquante = from item in db.Formations select item;
                IQueryable<Formation> FormationsDejaObtenu = from f in db.Formations join ef in db.EmployeeFormation on f.FormationID equals ef.FormationConcerne.FormationID where ef.EmployeeConcerne.Matricule == employeeConcerne.Matricule select f;

                FormationManquante = FormationManquante.Except(FormationsDejaObtenu);
                foreach (Formation item in FormationManquante)
                {
                    ListerFormationDB.Add(item);
                }

                return ListerFormationDB;
            }
        }

        public static void AjouterFormationDB(Formation formationNouveau)
        {
            using (var db = new DBAirAtlantiqueContext())
            {

                db.Formations.Add(formationNouveau);

                db.SaveChanges();

            }
        }


    }
}
